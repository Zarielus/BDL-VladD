using UnityEngine;

[RequireComponent (typeof(PlayerController))]
public class Pawn : MonoBehaviour
{
    private PlayerController _controller;

    //-------------------------------------------------------------
    void Start()
    {
        _controller = GetComponent<PlayerController>();
    }

    void Update()
    {
        _controller.Move(Input.GetAxis("Horizontal"));
        _controller.Jump();
    }
}
