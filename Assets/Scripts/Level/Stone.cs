using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Del());
    }
    //-------------------------------------------------------------

    IEnumerator Del()
    {
        yield return new WaitForSeconds(25f);
        Debug.Log("Hehe");
        Destroy(gameObject);
    }
    //-------------------------------------------------------------

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
            Destroy(gameObject);
    }
}
