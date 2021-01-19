using UnityEngine;

public class AIController : MonoBehaviour
{
    public int Health = 5;
    public float Edge = 10f;
    public float MovingSpeed = 2f;
    public bool ChangeDirection = true;

    private float _startX, _startY;
    private float _startSpeed;

    private Transform _player;
    private Rigidbody2D _rigidbody;

    //-------------------------------------------------------------
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _startX = GetComponent<Transform>().position.x;
        _startY = GetComponent<Transform>().position.y;
        _player = GameObject.Find("Character").GetComponent<Transform>();
        _startSpeed = MovingSpeed;
    }
    //-------------------------------------------------------------

    public void Move(bool isX, bool isAgressive)
    {
        if (isX)
        {
            if (Vector2.Distance(_player.position, transform.position) < 10f && isAgressive)
                MovingSpeed = _startSpeed + 3f;

            if (transform.position.x > _startX + Edge)
            {
                ChangeDirection = false;
            }
            else if (transform.position.x < _startX - Edge)
            {
                ChangeDirection = true;
            }

            if ((!ChangeDirection && transform.localScale.x < 0) || (ChangeDirection && transform.localScale.x > 0))
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

            if (ChangeDirection)
            {
                transform.position = new Vector2(transform.position.x + MovingSpeed * Time.deltaTime, transform.position.y);
            }
            else
            {
                transform.position = new Vector2(transform.position.x - MovingSpeed * Time.deltaTime, transform.position.y);
            }
        }
        else
        {
            if (transform.position.y > _startY + Edge)
            {
                ChangeDirection = false;
            }
            else if (transform.position.y < _startY - Edge)
            {
                ChangeDirection = true;
            }

            if (ChangeDirection)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + MovingSpeed * Time.deltaTime);
            }
            else transform.position = new Vector2(transform.position.x, transform.position.y - MovingSpeed * Time.deltaTime);
        }
    }

    public void Hit(Collider2D collision)
    {
        if (Health > 0)
            Health--;
        else Destroy(gameObject);

        if (collision.transform.position.x > transform.position.x)
        {
            _rigidbody.velocity = Vector2.up * 15f;
            _rigidbody.AddForce(transform.right * -7f, ForceMode2D.Impulse);
        }
        else
        {
            _rigidbody.velocity = Vector2.up * 15f;
            _rigidbody.AddForce(transform.right * 7f, ForceMode2D.Impulse);
        }
    }
    //-------------------------------------------------------------

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FireBall")
        {
            Hit(collision);
        }
    }

}
