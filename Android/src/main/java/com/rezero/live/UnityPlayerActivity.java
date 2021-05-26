package com.rezero.live;

import android.graphics.Color;
import android.os.Bundle;
import android.os.Handler;
import android.view.Gravity;
import android.view.SurfaceView;
import android.view.View;
import android.view.ViewGroup;
import android.widget.FrameLayout;
import android.widget.ImageView;

import com.lostpolygon.unity.livewallpaper.activities.LiveWallpaperCompatibleUnityPlayerActivity;

public class UnityPlayerActivity extends LiveWallpaperCompatibleUnityPlayerActivity {
    private final int SPLASH_DISPLAY_LENGHT = 5000;//启屏显示时间ms单位

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        ImageView splashView = new ImageView(this);
        int splash = getResources().getIdentifier("splash_normal", "drawable", getPackageName());
        splashView.setImageResource(splash);
        splashView.setScaleType(ImageView.ScaleType.FIT_XY);
        splashView.setAdjustViewBounds(true);

        FrameLayout.LayoutParams frameLayoutParams = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.WRAP_CONTENT, ViewGroup.LayoutParams.WRAP_CONTENT);
        frameLayoutParams.gravity = Gravity.BOTTOM;

        FrameLayout frameLayout = new FrameLayout(this);
        frameLayout.setBackgroundColor(Color.WHITE);
        frameLayout.addView(splashView, frameLayoutParams);

        ViewGroup.LayoutParams layoutParams = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT, ViewGroup.LayoutParams.MATCH_PARENT);
        addContentView(frameLayout, layoutParams);

        Handler handler = new Handler();
        handler.postDelayed(new Runnable() {
            @Override
            public void run() {
                ((ViewGroup)frameLayout.getParent()).removeView(frameLayout);
            }
        }, SPLASH_DISPLAY_LENGHT);
    }

    /**
     * Override this method to implement custom layout.
     * @return the {@code SurfaceView} that will contain the Unity player.
     */
    protected SurfaceView onCreateLayout() {
        return super.onCreateLayout();
    }

    /**
     * Determines the event at which the Unity player must be resumed.
     */
    protected UnityPlayerResumeEventType getUnityPlayerResumeEvent() {
        return UnityPlayerResumeEventType.OnActivityStart;
    }

    /**
     * Determines the event at which the Unity player must be paused.
     */
    protected UnityPlayerPauseEventType getUnityPlayerPauseEvent() {
        return UnityPlayerPauseEventType.OnActivityStop;
    }
}