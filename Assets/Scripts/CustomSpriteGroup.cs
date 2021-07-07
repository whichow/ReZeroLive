using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class CustomSpriteGroup : MonoBehaviour
{
    public void Activate(bool activate)
    {
        gameObject.SetActive(activate);
    }
}