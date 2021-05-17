using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public Texture[] bgImages;
    public Texture[] specBgImages;
    public Material bgMat;

    private int bgIndex;

    void Start()
    {
        SelectBackground(0);
    }

    public void SelectBackground(int index)
    {
        if(index < bgImages.Length)
        {
            bgMat.mainTexture = bgImages[index];
            bgIndex = index;
        }
    }

    public void SelectSpecialBackground(int index)
    {
        if(index < specBgImages.Length)
        {
            bgMat.mainTexture = specBgImages[index];
        }
    }

    public void ResetToNomalBackground()
    {
        SelectBackground(bgIndex);
    }
}
