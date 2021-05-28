using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class CustomSprite : MonoBehaviour
{
    private string[] animationNames;
    private SkeletonAnimation skAnim;
    private int curAnimIndex;
    private VoicePlayer voicePlayer;

    void Awake()
    {
        skAnim = gameObject.GetComponent<SkeletonAnimation>();
        voicePlayer = gameObject.GetComponent<VoicePlayer>();
        animationNames = GetAllAnimNames();
        GetComponentInChildren<HotArea>().onTouch.AddListener(()=>{
            RandomPlay();
        });
        skAnim.state.Complete += (trackEntry)=>{
            PlayIdle();
        };
    }

    public void PlayAnimation(int animIndex)
    {
        Debug.Log("Anim index: " + animIndex);
        if(animIndex >= 0 && animIndex < animationNames.Length)
        {
            skAnim.AnimationName = animationNames[animIndex];
            curAnimIndex = animIndex;
            Debug.Log("Play anim: " + skAnim.AnimationName);
        }
    }

    public void StopAnimation()
    {

    }

    public void PlayVoice(int voiceIndex)
    {
        voicePlayer.Play(voiceIndex);
    }

    public void StopVoice()
    {

    }

    public void PlayIdle()
    {
        PlayAnimation(0);
    }

    public void RandomPlay()
    {
        int animeIndex = Random.Range(1, animationNames.Length);
        if(animeIndex == curAnimIndex)
        {
            RandomPlay();
        }
        else
        {
            PlayAnimation(animeIndex);
            int voiceIndex = GetVoiceByAnime(animeIndex);
            PlayVoice(voiceIndex);
        }
    }

    public int GetVoiceByAnime(int animeIndex)
    {
        return animeIndex - 1;
    }

    public void Activate(bool activate)
    {
        gameObject.SetActive(activate);
    }

    public string[] GetAllAnimNames()
    {
        if(animationNames == null)
        {
            List<string> names = new List<string>();
            var anims = skAnim.Skeleton.Data.Animations;
            anims.ForEach((a)=>{
                var sp = a.Name.Split('_');
                int result;
                int.TryParse(sp[0], out result);
                if(sp.Length == 2 && result != 0)
                {
                    names.Add(a.Name);
                    Debug.Log(a.Name);
                }
            });
            animationNames = names.ToArray();
        }

        return animationNames;
    }
}