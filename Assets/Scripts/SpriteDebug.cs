using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDebug : MonoBehaviour
{
    private SpriteManager manager;
    private int animeIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<SpriteManager>();
    }

    void OnGUI()
    {
        if(GUILayout.Button("Play"))
        {
            var sprite = manager.GetCurrentSprite();
            PlayAnimAndAudio(sprite);
        }
        if(GUILayout.Button("<"))
        {
            var sprite = manager.GetCurrentSprite();
            if(--animeIndex == 0)
            {
                animeIndex = sprite.GetAllAnimNames().Length - 1;
            }
            PlayAnimAndAudio(sprite);
        }
        if(GUILayout.Button(">"))
        {
            var sprite = manager.GetCurrentSprite();
            if(++animeIndex == sprite.GetAllAnimNames().Length)
            {
                animeIndex = 0;
            }
            PlayAnimAndAudio(sprite);
        }
    }
    
    private void PlayAnimAndAudio(CustomSprite sprite)
    {
        sprite.PlayAnimation(animeIndex);
        int voiceIndex = sprite.GetVoiceByAnime(animeIndex);
        sprite.PlayVoice(voiceIndex);
    }
}
