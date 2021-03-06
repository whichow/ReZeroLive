using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject uiPanel;

#if UNITY_ANDROID && !UNITY_EDITOR
    private AndroidJavaClass appClass;
    private AndroidJavaClass activityClass;
    private AndroidJavaClass wrapperClass;
    private AndroidJavaObject wrapperObject;

    private string activity = "ulw.ulw.ulw.UnityPlayerActivity";
    private string wrapper = "ulw.ulw.ulw.Wrapper";
	private string app = "ulw.ulw.ulw.App";

    void Awake()
    {
		appClass = new AndroidJavaClass(app);
        activityClass = new AndroidJavaClass(activity);
        wrapperClass = new AndroidJavaClass(wrapper);
        wrapperObject = wrapperClass.CallStatic<AndroidJavaObject>("instance");
    }

    public void PreviewWallpaper()
    {
        activityClass.CallStatic("StartService");
    }

    public void Wrapper()
    {
        wrapperObject.Call("Start");
    }

    void OnApplicationFocus(bool hasFocus)
    {
        bool active = appClass.GetStatic<bool>("ACT");
        if(active)
		{
			uiPanel.SetActive(true);
		}
		else
		{
			uiPanel.SetActive(false);
		}
    }
#endif


//     private bool _isPreview;
//     private bool _isUnityPlayer;

// #if UNITY_ANDROID && !UNITY_EDITOR

//     void Awake()
//     {
//         uiPanel.SetActive(false);
//     }

//     public void PreviewWallpaper()
//     {
//         LiveWallpaper.OpenPreviewScreen();
//     }

//     // void Start()
//     // {
//     //     if(LiveWallpaper.IsPreview)
//     //     {
// 	// 		uiPanel.SetActive(true);
// 	// 	}
// 	// 	else
// 	// 	{
// 	// 		uiPanel.SetActive(false);
// 	// 	}
//     // }

// 	void OnEnable() {
// 		LiveWallpaper.IsPreviewChanged += OnPreviewChanged;
//         LiveWallpaper.CustomEventReceived += OnCustomEventReceived;
// 	}

// 	void OnDisable() {
// 		LiveWallpaper.IsPreviewChanged -= OnPreviewChanged;
//         LiveWallpaper.CustomEventReceived -= OnCustomEventReceived;
// 	}

// 	private void OnPreviewChanged(bool isPreview)
// 	{
//         Debug.Log("OnPreviewChanged: " + isPreview);
//         // _isPreview = isPreview;
// 		// if(isPreview)
// 		// {
// 		// 	uiPanel.SetActive(false);
// 		// }
// 		// else if(_isUnityPlayer)
// 		// {
// 		// 	uiPanel.SetActive(true);
// 		// }
// 	}

//     private void OnCustomEventReceived(string eventName, string eventData)
//     {
//         Debug.Log("OnCustomEventReceived: " + eventName);
//         // if(eventName == "UnityPlayerResumed")
//         // {
//         //     _isUnityPlayer = true;
//         //     if(_isPreview)
//         //     {
//         //         uiPanel.SetActive(false);
//         //     }
//         //     else
//         //     {
//         //         uiPanel.SetActive(true);
//         //     }
//         // }
//         // if(eventName == "UnityPlayerPaused")
//         // {
//         //     _isUnityPlayer = false;
//         //     uiPanel.SetActive(false);
//         // }
//         if(eventName == "UnityActivityOnResume")
//         {
//             uiPanel.SetActive(true);
//         }
//         if(eventName == "UnityActivityOnPause")
//         {
//             uiPanel.SetActive(false);
//         }
//     }
// #endif
}
