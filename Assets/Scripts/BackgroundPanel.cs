using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundPanel : MonoBehaviour
{
    public Transform contentNode;
    public GameObject bgItemPrefab;

    private BackgroundManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<BackgroundManager>();
        int count = manager.bgImages.Length;
        var resMgr = FindObjectOfType<ResourceManager>();
        for(int i = 0; i < count; i++)
        {
            GameObject item = Instantiate<GameObject>(bgItemPrefab);
            item.transform.SetParent(contentNode, false);
            var img = item.GetComponentInChildren<RawImage>();
            var tex = resMgr.GetBackgroundImage(i);
            img.texture = tex;
            int index = i;
            item.GetComponent<Button>().onClick.AddListener(()=>{
                manager.SelectBackground(index);
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
