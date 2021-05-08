using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public Texture[] bgImages;
    public Material bgMat;

    void Start()
    {
        SelectBackground(0);
    }

    public void SelectBackground(int index)
    {
        if(index < bgImages.Length)
        {
            bgMat.mainTexture = bgImages[index];
        }
    }
}
