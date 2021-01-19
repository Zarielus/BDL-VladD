using UnityEngine;

public class EnemyFireBall : MonoBehaviour
{
    public float Speed;
    public float ExistTime = 3f;

    //-------------------------------------------------------------
    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
        Destroy(gameObject, ExistTime);
    }
    //-------------------------------------------------------------

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
            Debug.Log("Player shoted!");
        }
    }
}
