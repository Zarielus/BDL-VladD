using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector2 _startPosition;
    private bool _getBack;

    //-------------------------------------------------------------
    void Start()
    {
        _startPosition = transform.position;
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        _rigidbody.gravityScale = 0;
    }

    void Update()
    {
        if (_getBack)
        {
            transform.position = Vector2.MoveTowards(transform.position, _startPosition, 10f * Time.deltaTime);
        }
        if(transform.position.y == _startPosition.y)
        {
            _getBack = false;
        }
    }
    //-------------------------------------------------------------

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(0.1f);
        _rigidbody.constraints = RigidbodyConstraints2D.None;
        _rigidbody.gravityScale = 1f;
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(10f);
        _rigidbody.gravityScale = 0;
        _rigidbody.velocity = Vector2.zero;
        _getBack = true;
    }
    //-------------------------------------------------------------

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && !_getBack)
        {
            StartCoroutine(Fall());
            Debug.Log("Yay");
        }
    }
}
