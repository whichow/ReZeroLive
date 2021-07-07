using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPanel : MonoBehaviour
{
    public Transform contentNode;
    public GameObject spriteItemPrefab;

    private SpriteManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<SpriteManager>();
        int count = manager.sprites.Length + manager.spriteGroups.Length;
        var resMgr = FindObjectOfType<ResourceManager>();
        for(int i = 0; i < count; i++)
        {
            GameObject item = Instantiate<GameObject>(spriteItemPrefab);
            item.transform.SetParent(contentNode, false);
            var img = item.GetComponentInChildren<RawImage>();
            var tex = resMgr.GetCharacterImage(i);
            img.texture = tex;
            int index = i;
            item.GetComponent<Button>().onClick.AddListener(()=>{
                if(index < manager.sprites.Length) 
                {
                    manager.SelectSprite(index);
                }
                else
                {
                    manager.SelectSpriteGroup(index - manager.sprites.Length);
                }
                gameObject.SetActive(false);
            });
        }
    }

    void OnEnable()
    {
        GlobalSettings.IsShowingPanel = true;
    }

    void OnDisable()
    {
        GlobalSettings.IsShowingPanel = false;
    }
}
