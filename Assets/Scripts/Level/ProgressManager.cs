using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public Transform[] CheckPoints;
    public Transform Player;

    //-------------------------------------------------------------
    void Start()
    {
        if (PlayerPrefs.HasKey("CheckPoints"))
            Player.position = CheckPoints[PlayerPrefs.GetInt("CheckPoints")].position;
    }
}
