using UnityEngine;

public class Options : MonoBehaviour
{
    public GameObject Menu, On, Off;

    private AudioSource _click;

    void Start()
    {
        if (AudioListener.volume == 0)
        {
            Off.SetActive(false);
            On.SetActive(true);
        } else
        {
            Off.SetActive(true);
            On.SetActive(false);
        }

        _click = GetComponent<AudioSource>();
            
    }

    public void SoundOn()
    {
        _click.Play();
        On.SetActive(true);
        Off.SetActive(false);
        AudioListener.volume = 0;
    }

    public void SoundOff()
    {
        _click.Play();
        Off.SetActive(true);
        On.SetActive(false);
        AudioListener.volume = 1;
    }

    public void Back()
    {
        _click.Play();
        Menu.SetActive(true);
        gameObject.SetActive(false);
    }
}
