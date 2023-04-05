using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DestructibleObstacles : MonoBehaviour
{
	public event EventHandler PlayerEntered;

	private new Rigidbody2D rigidbody;
	private BoxCollider2D boxCollider;

	private void Start()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		boxCollider = GetComponent<BoxCollider2D>();

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out PlayerController _))
		{
			PlayerEntered?.Invoke(this, null);
			Fall();
		}
	}

	private void Fall()
	{
		rigidbody.gravityScale = 1;
		boxCollider.isTrigger = false;
	}
}