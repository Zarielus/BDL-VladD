using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject Menu;

    private bool _isPaused = false;
    private Animator _animator;
    private AudioSource _click;

    //-------------------------------------------------------------
    void Start()
    {
        _click = GetComponent<AudioSource>();
        _animator = GameObject.Find("Transition").GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
            {
                Resume();
            }
            else Pause();
        }
    }
    //-------------------------------------------------------------

    public void Pause()
    {
        Menu.SetActive(true);
        Time.timeScale = 0f;
        _isPaused = true;
    }

    public void Resume()
    {
        _click.Play();
        Menu.SetActive(false);
        Time.timeScale = 1f;
        _isPaused = false;
    }

    public void MainMenu()
    {
        _click.Play();
        Menu.SetActive(false);
        Time.timeScale = 1f;
        _animator.SetBool("GetNextScene", true);
        StartCoroutine(LoadMainMenu());
    }

    public void Quit()
    {
        _click.Play();
        Menu.SetActive(false);
        Time.timeScale = 1f;
        _animator.SetBool("GetNextScene", true);
        StartCoroutine(QuitGame());
    }

    IEnumerator LoadMainMenu()
    {
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator QuitGame()
    {
        yield return new WaitForSeconds(2f);
        Application.Quit();
    }
}
