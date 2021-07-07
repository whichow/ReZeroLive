using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public CustomSprite[] sprites;
    public CustomSpriteGroup[] spriteGroups;
    public bool getSpritesInChildren;
    private CustomSprite currentSprite;
    private CustomSpriteGroup currentspriteGroup;
    private BackgroundManager bgMgr;

    void Awake()
    {
        bgMgr = FindObjectOfType<BackgroundManager>();
        
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
        if(!GlobalSettings.IsSpriteGroup)
        {
            SelectSprite(GlobalSettings.SpriteIndex);
        }
        else
        {
            SelectSpriteGroup(GlobalSettings.SpriteGroupIndex);
        }
    }

    public CustomSpriteGroup[] GetAllSpriteGroups()
    {
        return spriteGroups;
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
            if(index == 15 || index == 22 || index == 24 || index == 27 || index == 30)
            {
                bgMgr.SelectSpecialBackground(0);
            }
            else
            {
                bgMgr.ResetToNomalBackground();
            }
            var sprite = sprites[index];
            if(currentSprite != null)
            {
                currentSprite.Activate(false);
            }
            if(currentspriteGroup != null)
            {
                currentspriteGroup.Activate(false);
            }
            currentSprite = sprite;
            currentSprite.Activate(true);

            GlobalSettings.SpriteIndex = index;
        }
    }

    public void SelectSpriteGroup(int index)
    {
        if(index < spriteGroups.Length)
        {
            if(index == 1)
            {
                bgMgr.SelectSpecialBackground(0);
            }
            else
            {
                bgMgr.ResetToNomalBackground();
            }
        }
        var spriteGroup = spriteGroups[index];
        if(currentSprite != null)
        {
            currentSprite.Activate(false);
        }
        if(currentspriteGroup != null)
        {
            currentspriteGroup.Activate(false);
        }
        currentspriteGroup = spriteGroup;
        currentspriteGroup.Activate(true);

        GlobalSettings.SpriteGroupIndex = index;
    }
}
