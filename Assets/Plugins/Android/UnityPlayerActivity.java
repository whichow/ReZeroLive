package ulw.ulw.ulw;
import android.app.Activity;
import android.app.WallpaperManager;
import android.content.ComponentName;
import android.content.Intent;
import android.content.res.Configuration;
import android.graphics.Color;
import android.os.Build;
import android.os.Bundle;
import android.os.Handler;
import android.os.PowerManager;
import android.view.Gravity;
import android.view.KeyEvent;
import android.view.MotionEvent;
import android.view.SurfaceHolder;
import android.view.SurfaceView;
import android.view.ViewGroup;
import android.view.Window;
import android.widget.FrameLayout;
import android.widget.ImageView;

public class UnityPlayerActivity extends Activity implements SurfaceHolder.Callback
{

    static UnityPlayerActivity activity;
    static SurfaceView view;
    private final int SPLASH_DISPLAY_LENGHT = 3000;

    public static void StartService()
    {
        view.getHolder().removeCallback((SurfaceHolder.Callback) activity);
        Intent intent = new Intent(WallpaperManager.ACTION_CHANGE_LIVE_WALLPAPER);
        intent.putExtra(WallpaperManager.EXTRA_LIVE_WALLPAPER_COMPONENT, new ComponentName(activity, UnityWallpaperService.class));
        activity.startActivity(intent);
    }

    // Setup activity layout
    @Override protected void onCreate(Bundle savedInstanceState)
    {
        requestWindowFeature(Window.FEATURE_NO_TITLE);
        super.onCreate(savedInstanceState);

        activity = this;
        view = new SurfaceView(this);
        view.getHolder().addCallback(this);
        setContentView(view);

        ImageView splashImageView = new ImageView(this);
        int splash = getResources().getIdentifier("unity_static_splash", "drawable", getPackageName());
        splashImageView.setImageResource(splash);
        splashImageView.setScaleType(ImageView.ScaleType.FIT_XY);
        splashImageView.setAdjustViewBounds(true);

        FrameLayout.LayoutParams frameLayoutParams = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.WRAP_CONTENT, ViewGroup.LayoutParams.WRAP_CONTENT);
        frameLayoutParams.gravity = Gravity.BOTTOM;

        FrameLayout splashView = new FrameLayout(this);
        splashView.setBackgroundColor(Color.WHITE);
        splashView.addView(splashImageView, frameLayoutParams);

        ViewGroup.LayoutParams layoutParams = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT, ViewGroup.LayoutParams.MATCH_PARENT);
        addContentView(splashView, layoutParams);

        Handler handler = new Handler();
        handler.postDelayed(new Runnable() {
            @Override
            public void run() {
                ((ViewGroup)splashView.getParent()).removeView(splashView);
            }
        }, SPLASH_DISPLAY_LENGHT);
    }

    // SURFACE VIEW ZONE START
    @Override
    public void surfaceCreated(SurfaceHolder holder) {

    }


    @Override
    public void surfaceChanged(SurfaceHolder holder, int format, int width, int height) {

        App.mUnityPlayer.displayChanged(0, holder.getSurface());
        App.mUnityPlayer.resume();
    }

    @Override
    public void surfaceDestroyed(SurfaceHolder holder) {

        if (!WallpaperUtility.isULWActive(activity.getApplicationContext()))
        {
            App.mUnityPlayer.pause();
            App.mUnityPlayer.displayChanged(0, null);
        }
    }
    // SURFACE VIEW ZONE END

    @Override protected void onNewIntent(Intent intent)
    {
        // To support deep linking, we need to make sure that the client can get access to
        // the last sent intent. The clients access this through a JNI api that allows them
        // to get the intent set on launch. To update that after launch we have to manually
        // replace the intent with the one caught here.
        setIntent(intent);
    }

    // Quit Unity
    @Override protected void onDestroy ()
    {
        //App.mUnityPlayer.destroy();
        super.onDestroy();
    }

    // Pause Unity
    @Override protected void onPause()
    {
        super.onPause();
        PowerManager powerManager = (PowerManager)getSystemService(POWER_SERVICE);
        boolean isScreenOn;
        if(Build.VERSION.SDK_INT >= 20) {
            isScreenOn = powerManager.isInteractive();
        } else {
            isScreenOn = powerManager.isScreenOn();
        }
        if(!isScreenOn) {
            moveTaskToBack(true);
        }
        App.mUnityPlayer.pause();
    }

    // Resume Unity
    @Override protected void onResume()
    {
        super.onResume();
        App.mUnityPlayer.resume();
        view.getHolder().addCallback((SurfaceHolder.Callback) activity);

        if(view.getHolder().getSurface().isValid())
        {
            App.mUnityPlayer.pause();
            App.mUnityPlayer.displayChanged(0, view.getHolder().getSurface());
            App.mUnityPlayer.resume();
        }
    }

    @Override protected void onStart()
    {
        super.onStart();
        App.mUnityPlayer.start();
    }

    @Override protected void onStop()
    {
        super.onStop();
        App.mUnityPlayer.stop();
    }

    // Low Memory Unity
    @Override public void onLowMemory()
    {
        super.onLowMemory();
        App.mUnityPlayer.lowMemory();
    }

    // Trim Memory Unity
    @Override public void onTrimMemory(int level)
    {
        super.onTrimMemory(level);
        if (level == TRIM_MEMORY_RUNNING_CRITICAL)
        {
            App.mUnityPlayer.lowMemory();
        }
    }

    // This ensures the layout will be correct.
    @Override public void onConfigurationChanged(Configuration newConfig)
    {
        super.onConfigurationChanged(newConfig);
        App.mUnityPlayer.configurationChanged(newConfig);
    }

    // Notify Unity of the focus change.
    @Override public void onWindowFocusChanged(boolean hasFocus)
    {
        super.onWindowFocusChanged(hasFocus);
        App.ACT = hasFocus;
        App.mUnityPlayer.windowFocusChanged(hasFocus);
    }

    // For some reason the multiple keyevent type is not supported by the ndk.
    // Force event injection by overriding dispatchKeyEvent().
    @Override public boolean dispatchKeyEvent(KeyEvent event)
    {
        if (event.getAction() == KeyEvent.ACTION_MULTIPLE)
            return App.mUnityPlayer.injectEvent(event);
        return super.dispatchKeyEvent(event);
    }

    // Pass any events not handled by (unfocused) views straight to UnityPlayer
    @Override public boolean onKeyUp(int keyCode, KeyEvent event)     { return App.mUnityPlayer.injectEvent(event); }
    @Override public boolean onKeyDown(int keyCode, KeyEvent event)   {
        switch(keyCode)
        {
            case KeyEvent.KEYCODE_BACK:
                moveTaskToBack(true);
        }
        return App.mUnityPlayer.injectEvent(event);
    }
    @Override public boolean onTouchEvent(MotionEvent event)          { return App.mUnityPlayer.injectEvent(event); }
    /*API12*/ public boolean onGenericMotionEvent(MotionEvent event)  { return App.mUnityPlayer.injectEvent(event); }

}
