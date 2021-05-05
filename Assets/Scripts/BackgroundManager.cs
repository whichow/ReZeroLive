using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject[] backgrounds;
    public bool getBackgroundsInChildren;
    private GameObject currentBackground;
    
    void Awake()
    {
        if(getBackgroundsInChildren)
        {
            List<GameObject> gos = new List<GameObject>();
            foreach(Transform trans in transform)
            {
                GameObject go = trans.gameObject;
                gos.Add(go);
            }
            backgrounds = gos.ToArray();
        }
    }

    void Start()
    {
        SelectBackground(0);
    }

    public void SelectBackground(int index)
    {
        if(index <= backgrounds.Length - 1)
        {
            var background = backgrounds[index];
            if(currentBackground != null)
            {
                currentBackground.SetActive(false);
            }
            currentBackground = background;
            currentBackground.SetActive(true);
        }
    }
}
