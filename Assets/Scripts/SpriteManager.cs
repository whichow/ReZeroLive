using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public CustomSprite[] sprites;
    public bool getSpritesInChildren;
    private CustomSprite currentSprite;

    void Awake()
    {
        if(getSpritesInChildren)
        {
            List<CustomSprite> sps = new List<CustomSprite>();
            foreach(Transform trans in transform)
            {
                CustomSprite sp = trans.gameObject.GetComponent<CustomSprite>();
                sps.Add(sp);
            }
            sprites = sps.ToArray();
        }
    }

    void Start()
    {
        SelectSprite(0);
    }

    public CustomSprite[] GetAllSprites()
    {
        return sprites;
    }
    
    public CustomSprite GetSprite(int index)
    {
        if(index < sprites.Length)
        {
            return sprites[index];
        }
        return null;
    }

    public CustomSprite GetCurrentSprite()
    {
        return currentSprite;
    }

    public void SelectSprite(int index)
    {
        if(index < sprites.Length)
        {
            var sprite = sprites[index];
            if(currentSprite != null)
            {
                currentSprite.Activate(false);
            }
            currentSprite = sprite;
            currentSprite.Activate(true);
            currentSprite.PlayAnimation(0);
        }
    }
}
