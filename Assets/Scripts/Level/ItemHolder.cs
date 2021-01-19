using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    public Transform HolderPoint;
    public float Distance = 5f;

    private bool _isHolding;
    private RaycastHit2D _raycastHit;

    //-------------------------------------------------------------
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!_isHolding)
            {
                Physics2D.queriesStartInColliders = false;
                if (transform.localScale.x < 0)
                    _raycastHit = Physics2D.Raycast(transform.position, Vector2.right * transform.position.x, Distance);
                else _raycastHit = Physics2D.Raycast(transform.position, -Vector2.right * transform.position.x, Distance);
                if (_raycastHit.collider != null && _raycastHit.collider.tag == "Box")
                    _isHolding = true;
            }
            else 
            {
                _raycastHit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                _isHolding = false; 
            }
        }

        if (_isHolding)
        {
            _raycastHit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            _raycastHit.collider.gameObject.transform.position = Vector2.Lerp(_raycastHit.collider.gameObject.transform.position, HolderPoint.position, 5f * Time.deltaTime);
        }
    }
    //-------------------------------------------------------------

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * Distance);
    }
}
