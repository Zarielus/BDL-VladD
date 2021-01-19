using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent (typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    // Components
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Renderer _renderer;
    private AudioSource _walk, _jump, _hit, _addHP;

    // Jump
    public Transform GroundCheck;
    public LayerMask WhatIsGround;
    public float JumpForce = 5f;
    public int ExtraJumps = 1;

    private float _groundRadius = 0.2f;
    private float _jumpDelay;

    // Other
    public bool IsWhite;
    public float RunSpeed = 5f;
    public int _fullHP = 5;
    public int _healthPoints;

    private Animator _transition;

    //-------------------------------------------------------------
    void Start()
    {
        _healthPoints = _fullHP;
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _jump = transform.GetChild(0).gameObject.GetComponent<AudioSource>();
        _walk = GetComponent<AudioSource>();
        _renderer = GetComponent<Renderer>();
        _animator.SetBool("isWhite", IsWhite);
        _hit = transform.GetChild(3).gameObject.GetComponent<AudioSource>();
        _transition = GameObject.Find("Transition").GetComponent<Animator>();
        _addHP = transform.GetChild(1).gameObject.GetComponent<AudioSource>();
    }
    //-------------------------------------------------------------

    public void Move(float arrow)
    {
        if (arrow == 0)
        {
            _animator.SetBool("Walk", false);
        }
        else
        {
            _animator.SetBool("Walk", true);
            if(!_walk.isPlaying)
                _walk.Play();
        }

        Vector3 direction = transform.right * arrow;
        transform.position = Vector2.Lerp(transform.position, transform.position + direction, RunSpeed * Time.deltaTime);

        if ((arrow > 0 && transform.localScale.x < 0) || (arrow < 0 && transform.localScale.x > 0))
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, _groundRadius, WhatIsGround);
    }

    public void Jump()
    {
        if (IsGrounded() && _rigidbody.velocity.y < 3f)
        {
            ExtraJumps = 1;
            _animator.SetBool("Jump", false);
        }
        else
        {
            _animator.SetBool("Jump", true);
            _walk.Stop();
        }
        if (Input.GetButtonDown("Jump") && ExtraJumps >= 0)
        {
            _jump.Play();
            _rigidbody.velocity = Vector2.up * JumpForce;
            ExtraJumps--;
        } 
    }

    void HitHero(GameObject collision)
    {
        GetComponent<HealthUI>().ResetDelay = GetComponent<HealthUI>().HealingDelay;
        _renderer.material.color = Color.red;
        _hit.Play();

        Debug.Log(_healthPoints);
        if (_healthPoints != 0)
            _healthPoints--;
        else StartCoroutine(Die());

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

        Invoke("ReturnNormalColor", 0.1f);
    }

    public void ReturnNormalColor()
    {
        _renderer.material.color = Color.white;
    }

    IEnumerator Die()
    {
        _transition.SetBool("GetNextScene", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    //-------------------------------------------------------------
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Enemy":
                HitHero(collision.gameObject);
                break;
            case "SpringBoard":
                _rigidbody.velocity = Vector2.up * 30f;
                collision.GetComponent<AudioSource>().Play();
                break;
            case "AdditionalHP":
                _fullHP++;
                _healthPoints = _fullHP;
                _addHP.Play();
                Destroy(collision.gameObject);
                break;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                HitHero(collision.gameObject);
                break;
            case "Dynamic":
                transform.parent = collision.transform;
                break;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Dynamic")
            transform.parent = null;
    }
}
