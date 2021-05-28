using UnityEngine;
using System.Collections;

public class BgCapBot : MonoBehaviour
{
    public PhotoCamera capCam;
    public BackgroundManager bgMgr;

    IEnumerator Start()
    {
        capCam.gameObject.SetActive(true);
        // capCam.GetComponent<Camera>().cullingMask = LayerMask.NameToLayer("Background");
        int index = 50;
        while(index < bgMgr.bgImages.Length)
        {
            bgMgr.SelectBackground(index);
            capCam.TakePhoto();
            index++;
            yield return new WaitForSeconds(1f);
        }
        capCam.gameObject.SetActive(false);
    }
}