using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class CustomSprite : MonoBehaviour
{
    private string[] animationNames;
    private string[] voiceNames;
    private SkeletonAnimation skAnime;

    void Awake()
    {
        skAnime = gameObject.GetComponent<SkeletonAnimation>();
        animationNames = GetAllAnimNames();
        GetComponentInChildren<HotArea>().onTouch.AddListener(()=>{
            RandomPlay();
        });
    }

    public void PlayAnimation(int animeIndex)
    {
        if(animeIndex < animationNames.Length - 1)
        {
            skAnime.AnimationName = animationNames[animeIndex];
        }
    }

    public void StopAnimation()
    {

    }

    public void PlayVoice(int voiceIndex)
    {

    }

    public void StopVoice()
    {

    }

    public void RandomPlay()
    {
        int animeIndex = Random.Range(0, animationNames.Length);
        PlayAnimation(animeIndex);
        // int voiceIndex = GetVoiceByAnime(animeIndex);
        // if(voiceIndex < voiceNames.Length)
        // {
        //     PlayVoice(voiceIndex);
        // }
    }

    public int GetVoiceByAnime(int animeIndex)
    {
        return 0;
    }

    public void Activate(bool activate)
    {
        gameObject.SetActive(activate);
    }

    private string[] GetAllAnimNames()
    {
        List<string> names = new List<string>();
        var anims = skAnime.Skeleton.Data.Animations;
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
        return names.ToArray();
    }
}