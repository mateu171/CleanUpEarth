using UnityEngine;

public class EarthController : MonoBehaviour
{
    [SerializeField] private float speedRotation = 0.02f;
    [SerializeField] private int rotationSpeedZ = 10;

    private void Update()
    {
        transform.Rotate(0,0,rotationSpeedZ * speedRotation * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);  
    }
}
