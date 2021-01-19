using UnityEngine;

public class Smasher : MonoBehaviour
{
    public float GetUpSpeed = 5f;
    public float GetDownSpeed = 10f;
    public float StartDelay = 0f;

    private bool _getUp;
    private Vector2 _startPosition;

    //-------------------------------------------------------------
    void Start()
    {
        _startPosition = transform.position;
    }

    void Update()
    {
        if (_getUp)
        {
            if (transform.position.y < _startPosition.y)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + GetUpSpeed * Time.deltaTime);
            }
            else _getUp = false;
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - GetDownSpeed * Time.deltaTime);
        }
    }
    //-------------------------------------------------------------

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            _getUp = true;
        }
    }
}
