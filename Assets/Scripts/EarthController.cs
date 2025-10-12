using UnityEngine;

public class EarthController : MonoBehaviour
{
    [SerializeField] private float speedRotation = 0.02f;

    private void Update()
    {
        transform.Rotate(0,0,10 * speedRotation * Time.deltaTime);
    }
}
