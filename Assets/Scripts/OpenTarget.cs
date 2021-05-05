using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenTarget : MonoBehaviour
{
    public GameObject target;
    private Button openButton;
    // Start is called before the first frame update
    void Start()
    {
        openButton = GetComponent<Button>();
        openButton.onClick.AddListener(()=>{
            target.SetActive(true);
        });
    }
}
