using UnityEngine;

public class Button : MonoBehaviour
{
    // Button
    private float _startButtonPosition;
    private bool _isTriggered = false;

    // Gate
    public GameObject Gate;
    public float OpenGateSpeed = 3f;
    public float CloseGateSpeed = 3f;

    private float _startGatePosition;

    // In case of connected buttons
    public Button[] ConnectedButtons;
    public bool IsMainButton;

    //-------------------------------------------------------------
    void Start()
    {
        _startButtonPosition = transform.position.y;
        _startGatePosition = Gate.transform.position.y;

    }

    void Update()
    {
        if (!_isTriggered)
            if (transform.position.y < _startButtonPosition)
                transform.Translate(Vector2.up * Time.deltaTime);
            else if (IsMainButton && Gate.transform.position.y > _startGatePosition)
                Gate.transform.Translate(Vector2.down * CloseGateSpeed * Time.deltaTime);
    }
    //-------------------------------------------------------------

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.tag == "Player" || collision.tag == "Box") && transform.position.y > _startButtonPosition - 0.2f)
        {
            _isTriggered = true;
            transform.Translate(Vector2.down * Time.deltaTime);
        }
        else if ((collision.tag == "Player" || collision.tag == "Box") && Gate.transform.position.y < _startGatePosition + 10f)
        {
            IsMainButton = true;
            for (int i = 0; i < ConnectedButtons.Length; i++)
                ConnectedButtons[i].IsMainButton = false;
            Gate.transform.Translate(Vector2.up * OpenGateSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isTriggered = false;
    }
}
