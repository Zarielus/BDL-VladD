using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	private Transform _player;
	public float Damping = 1.5f;
	public Vector2 Offset = new Vector2(7f, 1f);
	public bool FaceLeft;

	private int _lastPositionX;

	//-------------------------------------------------------------
	void Start()
	{
		_player = GameObject.FindGameObjectWithTag("Player").transform;
		Offset = new Vector2(Mathf.Abs(Offset.x), Offset.y);
		FindPlayer(FaceLeft);
	}
	
	void Update()
	{
		Follow();
	}
	//-------------------------------------------------------------

	public void FindPlayer(bool playerFaceLeft)
	{
		_lastPositionX = Mathf.RoundToInt(_player.position.x);
		if (playerFaceLeft)
		{
			transform.position = new Vector3(_player.position.x - Offset.x, _player.position.y + Offset.y, transform.position.z);
		}
		else
		{
			transform.position = new Vector3(_player.position.x + Offset.x, _player.position.y + Offset.y, transform.position.z);
		}
	}

	void Follow()
	{
		if (_player)
		{
			int currentPositionX = Mathf.RoundToInt(_player.position.x);
			if (currentPositionX > _lastPositionX) FaceLeft = false; else if (currentPositionX < _lastPositionX) FaceLeft = true;
			_lastPositionX = Mathf.RoundToInt(_player.position.x);

			Vector3 target;
			if (FaceLeft)
			{
				target = new Vector3(_player.position.x - Offset.x, _player.position.y + Offset.y, transform.position.z);
			}
			else
			{
				target = new Vector3(_player.position.x + Offset.x, _player.position.y + Offset.y, transform.position.z);
			}
			Vector3 currentPosition = Vector3.Lerp(transform.position, target, Damping * Time.deltaTime);
			transform.position = currentPosition;
		}
	}
}