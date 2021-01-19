using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    public GameObject ProgressSaved;
    public int Checkpoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            PlayerPrefs.SetInt("CheckPoints", Checkpoint);
            ProgressSaved.GetComponent<Animation>().Play();
            Debug.Log("Progress Saved!");
        }
    }
}
