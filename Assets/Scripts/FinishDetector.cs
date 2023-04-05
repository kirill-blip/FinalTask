using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishDetector : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out PlayerController _))
		{
			SceneManager.LoadScene(0);
		}
	}
}
