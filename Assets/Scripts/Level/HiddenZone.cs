using UnityEngine;

public class HiddenZone : MonoBehaviour
{
    private Renderer _renderer;
    private Color _firstColor;

    //-------------------------------------------------------------
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _firstColor = _renderer.material.color;
    }
    //-------------------------------------------------------------

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            _renderer.material.color = new Color(0, 0, 0, 0f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            _renderer.material.color = _firstColor;
    }
}
