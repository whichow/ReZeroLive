using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HotArea : MonoBehaviour
{
    public UnityEvent onTouch;

    private float mouseDownTime;
    private Vector3 mousePos;

    void OnMouseDown()
    {
        Debug.Log("On mouse down");
        if (!GlobalSettings.IsShowingPanel)
        {
            mouseDownTime = Time.time;
            mousePos = Input.mousePosition;
        }
    }

    void OnMouseUp()
    {
        Debug.Log("On mouse up");
        if (Time.time - mouseDownTime > 0.5f)
        {
            return;
        }
        var deltaPos = Vector3.Distance(Input.mousePosition, mousePos);
        if (deltaPos > 0.1f)
        {
            return;
        }
        Debug.Log("On mouse click");
        onTouch.Invoke();
    }
}
