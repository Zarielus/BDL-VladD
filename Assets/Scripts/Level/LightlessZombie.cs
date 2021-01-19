using UnityEngine;

[RequireComponent (typeof(AIController))]
public class LightlessZombie : MonoBehaviour
{
    private AIController _controller;
    private AudioSource _hit;
    private Animator _animator;

    //-------------------------------------------------------------
    void Start()
    {
        _controller = GetComponent<AIController>();
        _hit = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _controller.Move(true, true);
    }
    //-------------------------------------------------------------

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("FireBall"))
        {
            _hit.Play();
            _controller.Hit(collision);
        }
    }

    /*void OnBecameInvisible()
    {
        Debug.Log("IM INVISIBLE SUKA");
        _animator.enabled = false;
    }

    void OnBecameVisible()
    {
        Debug.Log("BLET...");
        _animator.enabled = true;
    }*/
}
