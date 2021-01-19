using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject options;

    private GameObject _transition;
    private Animator _animator;
    private AudioSource _click;

    //-------------------------------------------------------------
    void Start()
    {
        _click = GetComponent<AudioSource>();
        _transition = GameObject.Find("Transition");
        _animator = _transition.GetComponent<Animator>();
        StartCoroutine(MoveTransitionLayer());
    }
    //-------------------------------------------------------------

    public void NewGame()
    {
        _click.Play();
        _transition.transform.SetAsLastSibling();
        _animator.SetBool("GetNextScene", true);
        PlayerPrefs.DeleteKey("CheckPoints");
        Invoke("LoadLevel", 2f);
    }

    public void LoadGame()
    {
        _click.Play();
        _transition.transform.SetAsLastSibling();
        _animator.SetBool("GetNextScene", true);
        Invoke("LoadLevel", 2f);
    }

    public void Options()
    {
        _click.Play();
        options.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Quit()
    {
        _click.Play();
        _transition.transform.SetAsLastSibling();
        _animator.SetBool("GetNextScene", true);
        Debug.Log("Quit");
        Application.Quit();
    }

    IEnumerator MoveTransitionLayer()
    {
        yield return new WaitForSeconds(1.8f);
        _transition.transform.SetAsFirstSibling();
    }
    
    void LoadLevel()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
