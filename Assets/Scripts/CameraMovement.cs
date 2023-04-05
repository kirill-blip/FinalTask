using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	[SerializeField] private Transform target;
	[SerializeField] private float dampTime = 0.15f;
	
	private Vector3 _velocity;

	private void Update()
	{
		Vector3 point = Camera.main.WorldToViewportPoint(target.position);
		Vector3 delta = target.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
		Vector3 destination = transform.position + delta;
		destination.y = 0;
		transform.position = Vector3.SmoothDamp(transform.position, destination, ref _velocity, dampTime);
	}
}