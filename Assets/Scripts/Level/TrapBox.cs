using UnityEngine;

public class TrapBox : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    //-------------------------------------------------------------
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    //-------------------------------------------------------------

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _rigidbody.constraints = RigidbodyConstraints2D.None;
        }
    }
}
