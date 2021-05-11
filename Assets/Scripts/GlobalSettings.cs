
using UnityEngine;

public class GlobalSettings
{
    public static bool IsShowingPanel = false;

    private static bool playVoice = true;
    public static bool PlayVoice
    {
        get
        {
            return playVoice;
        }
        set
        {
            if(value)
            {
                AudioListener.volume = 1;
                playVoice = true;
            }
            else
            {
                AudioListener.volume = 0;
                playVoice = false;
            }
        }
    } 
}