using UnityEngine;

public class CirclePlatform : MonoBehaviour
{
    public Transform Center;
    public float Radius = 2f, AngularSpeed = 2f, Angle = 0f;

    private float _positionX, _positionY;

    //-------------------------------------------------------------
    void Update()
    {
        _positionX = Center.position.x + Mathf.Cos(Angle) * Radius;
        _positionY = Center.position.y + Mathf.Sin(Angle) * Radius;
        transform.position = new Vector2(_positionX, _positionY);
        Angle = Angle + Time.deltaTime * AngularSpeed;

        if(Angle >= 360f)
        {
            Angle = 0f;
        }
    }
}
