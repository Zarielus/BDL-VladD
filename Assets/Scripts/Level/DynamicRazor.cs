using UnityEngine;

[RequireComponent (typeof(AIController))]
public class DynamicRazor : MonoBehaviour
{
    public bool isX, isAgressive;

    private AIController _controller;

    //-------------------------------------------------------------
    void Start()
    {
        _controller = GetComponent<AIController>();
    }

    void Update()
    {
        _controller.Move(isX, isAgressive);
    }

}
