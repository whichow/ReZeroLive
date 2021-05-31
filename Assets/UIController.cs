using System.Collections;
using System.Collections.Generic;
using LostPolygon.uLiveWallpaper;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject uiPanel;

    private bool _isPreview;
    private bool _isUnityPlayer;

#if UNITY_ANDROID && !UNITY_EDITOR

    void Awake()
    {
        uiPanel.SetActive(false);
    }

    public void PreviewWallpaper()
    {
        LiveWallpaper.OpenPreviewScreen();
    }

    // void Start()
    // {
    //     if(LiveWallpaper.IsPreview)
    //     {
	// 		uiPanel.SetActive(true);
	// 	}
	// 	else
	// 	{
	// 		uiPanel.SetActive(false);
	// 	}
    // }

	void OnEnable() {
		LiveWallpaper.IsPreviewChanged += OnPreviewChanged;
        LiveWallpaper.CustomEventReceived += OnCustomEventReceived;
	}

	void OnDisable() {
		LiveWallpaper.IsPreviewChanged -= OnPreviewChanged;
        LiveWallpaper.CustomEventReceived -= OnCustomEventReceived;
	}

	private void OnPreviewChanged(bool isPreview)
	{
        Debug.Log("OnPreviewChanged: " + isPreview);
        // _isPreview = isPreview;
		// if(isPreview)
		// {
		// 	uiPanel.SetActive(false);
		// }
		// else if(_isUnityPlayer)
		// {
		// 	uiPanel.SetActive(true);
		// }
	}

    private void OnCustomEventReceived(string eventName, string eventData)
    {
        Debug.Log("OnCustomEventReceived: " + eventName);
        // if(eventName == "UnityPlayerResumed")
        // {
        //     _isUnityPlayer = true;
        //     if(_isPreview)
        //     {
        //         uiPanel.SetActive(false);
        //     }
        //     else
        //     {
        //         uiPanel.SetActive(true);
        //     }
        // }
        // if(eventName == "UnityPlayerPaused")
        // {
        //     _isUnityPlayer = false;
        //     uiPanel.SetActive(false);
        // }
        if(eventName == "UnityActivityOnResume")
        {
            uiPanel.SetActive(true);
        }
        if(eventName == "UnityActivityOnPause")
        {
            uiPanel.SetActive(false);
        }
    }
#endif
}
