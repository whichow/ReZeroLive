using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HotArea : MonoBehaviour
{
    public UnityEvent onTouch;

    void OnMouseDown()
    {
        Debug.Log("On mouse down");
        if(!GlobalSettings.IsShowingPanel)
        {
            onTouch.Invoke();
        }
    }
}
