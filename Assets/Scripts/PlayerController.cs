using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
	[SerializeField] private float jumpForce = 10;
	[SerializeField] private float speed = 10;

	private new Rigidbody2D rigidbody;

	private bool canMove = true;

	private void Start()
	{
		rigidbody = GetComponent<Rigidbody2D>();

		List<DestructibleObstacles> obstacles = FindObjectsOfType<DestructibleObstacles>().ToList();
		obstacles.ForEach(x => x.PlayerEntered += PlayerEntered);
	}

	private void PlayerEntered(object sender, System.EventArgs e)
	{
		canMove = false;
		rigidbody.velocity = Vector2.zero;
		StartCoroutine(RestartGame());
	}

	private void Update()
	{
		if (!canMove) return;

		Jump();
		Move();
	}

	private void Jump()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
	}

	private void Move()
	{
		float horizontal = Input.GetAxis("Horizontal");
		Vector2 velocity = new Vector2(horizontal * speed, rigidbody.velocity.y);

		rigidbody.velocity = velocity;
	}

	private IEnumerator RestartGame()
	{
		yield return new WaitForSeconds(3);
		SceneManager.LoadScene(0);
	}
}
