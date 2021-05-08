using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private Texture[] charImages;
    private Texture[] bgImages;

    void Awake()
    {
        charImages = LoadAllCharacterImages();
        bgImages = LoadAllBackgroundImages();
    }

    private Texture[] LoadAllCharacterImages()
    {
        return Resources.LoadAll<Texture>("Images/Character");
    }

    private Texture[] LoadAllBackgroundImages()
    {
        return Resources.LoadAll<Texture>("Images/Background");
    }

    public Texture GetCharacterImage(int index)
    {
        if(index < charImages.Length)
        {
            return charImages[index];
        }
        return null;
    }

    public Texture GetBackgroundImage(int index)
    {
        if(index < bgImages.Length)
        {
            return bgImages[index];
        }
        return null;
    }
}
