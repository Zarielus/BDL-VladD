using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float Speed;

    private AudioSource _burst;

    //-------------------------------------------------------------
    void Start()
    {
        _burst = GetComponent<AudioSource>();
        if (AudioListener.volume != 0)
            _burst.Play();
    }

    void Update()
    {
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
        Destroy(gameObject, 0.5f);
    }
    //-------------------------------------------------------------

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);
            Debug.Log("Enemy shoted!");
        }
    }
}
