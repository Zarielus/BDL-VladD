using UnityEngine;

public class Blaze : MonoBehaviour
{
    // Objects
    public Transform WeaponPosition;
    public Transform ShotDirection;
    public GameObject FireBall;

    // Attack
    public float startAtack;
    private float _attackDelay;

    // Other
    public float MoveSpeed = 3.4f;
    public float Offset;

    //-------------------------------------------------------------
    void Start()
    {

    }

    void Update()
    {
        BlazeMove();
        Attack();
    }
    //-------------------------------------------------------------

    void BlazeMove()
    {
            transform.position = Vector2.Lerp(transform.position, WeaponPosition.transform.position, MoveSpeed * Time.deltaTime);
    }

    void Attack()
    {
        if (_attackDelay <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                FindDirection();
                Instantiate(FireBall, ShotDirection.position, transform.rotation);
                _attackDelay = startAtack;
            }
        }
        else _attackDelay -= Time.deltaTime;
    }

    void FindDirection()
    {
        Vector2 Difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float Rotate = Mathf.Atan2(Difference.y, Difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, Rotate + Offset);
    }

}
