using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class SpineSprites : MonoBehaviour
{
    public bool autoPlay;
    public float playTime = 3;
    private float curTime;
    private List<GameObject> children;
    private int curIndex;
    private string[] animNames;
    private int animIndex;

    // Start is called before the first frame update
    void Start()
    {
        children = new List<GameObject>();
        foreach (Transform child in transform)
        {
            children.Add(child.gameObject);
        }
        EnableCurrent();
        animNames = GetAllAnimNames();
    }

    // Update is called once per frame
    void Update()
    {
        if(autoPlay)
        {
            curTime += Time.deltaTime;
            if(curTime >= playTime)
            {
                NextCharacter();
                curTime = 0;
            }
        }
    }

    void OnGUI()
    {
        if(autoPlay) return;
        if(GUILayout.Button("Previous"))
        {
            PreviousCharacter();
        }
        if(GUILayout.Button("Next"))
        {
            NextCharacter();
        }
        if(GUILayout.Button("<"))
        {
            PreviousAnime();
        }
        if(GUILayout.Button(">"))
        {
            NextAnime();
        }
    }

    private void PreviousCharacter()
    {
        DisableCurrent();
        curIndex--;
        if(curIndex < 0)
        {
            curIndex = children.Count - 1;
        }
        EnableCurrent();
        animNames = GetAllAnimNames();
    }

    private void NextCharacter()
    {
        DisableCurrent();
        curIndex++;
        if(curIndex > children.Count - 1)
        {
            curIndex = 0;
        }
        EnableCurrent();
        animNames = GetAllAnimNames();
    }

    private void PreviousAnime()
    {
        animIndex--;
        if(animIndex < 0)
        {
            animIndex = animNames.Length - 1;
        }
        var go = children[curIndex].gameObject;
        var anim = go.GetComponent<SkeletonAnimation>();
        anim.AnimationName = animNames[animIndex];
    }

    private void NextAnime()
    {
        animIndex++;
        if(animIndex > animNames.Length - 1)
        {
            animIndex = 0;
        }
        var go = children[curIndex].gameObject;
        var anim = go.GetComponent<SkeletonAnimation>();
        anim.AnimationName = animNames[animIndex];
    }

    private string[] GetAllAnimNames()
    {
        List<string> names = new List<string>();
        var go = children[curIndex].gameObject;
        var anim = go.GetComponent<SkeletonAnimation>();
        var anims = anim.skeleton.Data.Animations;
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

    private void DisableCurrent()
    {
        children[curIndex].gameObject.SetActive(false);
    }

    private void EnableCurrent()
    {
        var go = children[curIndex].gameObject;
        go.SetActive(true);
        var anim = go.GetComponent<SkeletonAnimation>();
        anim.AnimationName = "01_wait";
        // anim.loop = false;
    }
}
