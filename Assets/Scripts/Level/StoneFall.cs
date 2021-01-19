using System.Collections;
using UnityEngine;

public class StoneFall : MonoBehaviour
{
    public GameObject[] Stones;
    public float SpawnTime = 2f;

    private int _r = 0;

    //-------------------------------------------------------------
    void Start()
    {
        StartCoroutine(StoneSpawn());
    }
    //-------------------------------------------------------------

    IEnumerator StoneSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnTime);
            _r = Random.Range(0, Stones.Length);
            Instantiate(Stones[_r], transform.position, transform.rotation);
        }
    }
}
