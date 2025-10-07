using UnityEngine;

public class Garbage : MonoBehaviour
{
    private void Start()
    {
       // transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 180));
    }
    private void Update()
    {
        if (transform.position.y < -5.70)
            Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       Destroy(gameObject);
    }
}
