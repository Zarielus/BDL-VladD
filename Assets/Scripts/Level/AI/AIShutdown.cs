using UnityEngine;

public class AIShutdown : MonoBehaviour
{
    private AIController _controller;
    private LightlessZombie _pawn;
    private Animator _animator;

    private void Start()
    {
        _controller = GetComponent<AIController>();
        _pawn = GetComponent<LightlessZombie>();
        _animator = GetComponent<Animator>();

        _controller.enabled = false;
        _pawn.enabled = false;
        _animator.enabled = false;
    }
    void OnBecameInvisible()
    {
        _controller.enabled = false;
        _pawn.enabled = false;
        _animator.enabled = false;
    }

    void OnBecameVisible()
    {
        _controller.enabled = true;
        _pawn.enabled = true;
        _animator.enabled = true;
    }

}
