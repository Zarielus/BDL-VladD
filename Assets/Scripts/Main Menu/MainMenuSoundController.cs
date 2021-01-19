using UnityEngine;

public class MainMenuSoundController : MonoBehaviour
{
    public AudioSource[] Sound;

    private void FixedUpdate()
    {
        if (PlayerPrefs.HasKey("Sound") && PlayerPrefs.GetInt("Sound") == 0)
            for (int i = 0; i < Sound.Length; i++)
                Sound[i].mute = true;
        else for (int i = 0; i < Sound.Length; i++)
                Sound[i].mute = false;
    }
}
