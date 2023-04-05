using UnityEngine;

public class Gear : MonoBehaviour
{
    [SerializeField] private float speed = 10;

    private void Update()
    {
        Vector3 eulers = new Vector3(0, 0, speed * Time.deltaTime);
        transform.Rotate(eulers);
    }
}
