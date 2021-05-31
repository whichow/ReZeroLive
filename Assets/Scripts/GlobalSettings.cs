
using UnityEngine;

public class GlobalSettings
{
    private static readonly string PLAY_VOICE = "VOICE";
    private static readonly string SPRITE_INDEX = "SPRITE";
    private static readonly string BG_INDEX = "BACKGROUND";

    public static bool IsShowingPanel = false;

    public static bool PlayVoice
    {
        get
        {
            if(PlayerPrefs.HasKey(PLAY_VOICE))
            {
                return PlayerPrefs.GetInt(PLAY_VOICE) == 1;
            }
            else
            {
                return true;
            }
        }
        set
        {
            if(value)
            {
                AudioListener.volume = 1;
                PlayerPrefs.SetInt(PLAY_VOICE, 1);
            }
            else
            {
                AudioListener.volume = 0;
                PlayerPrefs.SetInt(PLAY_VOICE, 0);
            }
            PlayerPrefs.Save();
        }
    }

    public static int SpriteIndex
    {
        get
        {
            return PlayerPrefs.GetInt(SPRITE_INDEX, 0);
        }
        set
        {
            PlayerPrefs.SetInt(SPRITE_INDEX, value);
            PlayerPrefs.Save();
        }
    } 

    public static int BgIndex
    {
        get
        {
            return PlayerPrefs.GetInt(BG_INDEX, 0);
        }
        set
        {
            PlayerPrefs.SetInt(BG_INDEX, value);
            PlayerPrefs.Save();
        }
    } 
}