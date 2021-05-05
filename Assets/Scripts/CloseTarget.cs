using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseTarget : MonoBehaviour
{
    public GameObject target;
    private Button closeButton;
    // Start is called before the first frame update
    void Start()
    {
        closeButton = GetComponent<Button>();
        closeButton.onClick.AddListener(()=>{
            target.SetActive(false);
        });
    }
}
