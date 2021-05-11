using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleVoice : MonoBehaviour
{
    public Text buttonText;
    private Button toggleButton;
    
    // Start is called before the first frame update
    void Start()
    {
        toggleButton = GetComponent<Button>();
        buttonText = GetComponentInChildren<Text>();
        toggleButton.onClick.AddListener(()=>{
            GlobalSettings.PlayVoice = !GlobalSettings.PlayVoice;
            buttonText.text = GlobalSettings.PlayVoice ? "声音开" : "声音关";
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
