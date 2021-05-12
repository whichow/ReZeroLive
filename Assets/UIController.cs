using System.Collections;
using System.Collections.Generic;
using LostPolygon.uLiveWallpaper;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject uiPanel;

#if UNITY_ANDROID && !UNITY_EDITOR
    void Start()
    {
        if(LiveWallpaper.IsPreview)
        {
			uiPanel.SetActive(true);
		}
		else
		{
			uiPanel.SetActive(false);
		}
    }

	void OnEnable() {
		LiveWallpaper.IsPreviewChanged += OnPreviewChanged;
	}

	void OnDisable() {
		LiveWallpaper.IsPreviewChanged -= OnPreviewChanged;
	}

	private void OnPreviewChanged(bool isPreview)
	{
		if(isPreview)
		{
			uiPanel.SetActive(true);
		}
		else
		{
			uiPanel.SetActive(false);
		}
	}
#endif
}
