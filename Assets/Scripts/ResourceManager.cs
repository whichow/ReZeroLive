using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private Texture[] charImages;

    void Awake()
    {
        charImages = LoadAllCharacterImages();
    }

    private Texture[] LoadAllCharacterImages()
    {
        return Resources.LoadAll<Texture>("Images/Character");
    }

    public Texture GetCharacterImage(int index)
    {
        if(index < charImages.Length)
        {
            return charImages[index];
        }
        return null;
    }
}
