using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    // Components
    public Image[] HealthPoints;
    public Sprite EnabledHP;

    // Regeneration
    public float HealingDelay = 15f;
    public float ResetDelay;

    private PlayerController _playerController;

    //-------------------------------------------------------------
    void Start()
    {
        _playerController = GetComponent<PlayerController>();
        ResetDelay = HealingDelay;
    }

    void Update()
    {
        for(int i = 0; i < HealthPoints.Length; i++)
        {
            if(i < _playerController._healthPoints)
            {
                HealthPoints[i].gameObject.SetActive(true);
                //HealthPoints[i].transform.GetChild(0).gameObject.SetActive(true);
            } else
            {
                HealthPoints[i].gameObject.SetActive(false);
                //HealthPoints[i].transform.GetChild(0).gameObject.SetActive(false);
            }
        }

        if (ResetDelay <= 0)
        {
            if (_playerController._healthPoints < _playerController._fullHP)
                _playerController._healthPoints++;
            ResetDelay = HealingDelay;
        }
        else ResetDelay -= Time.deltaTime;
    }
}
