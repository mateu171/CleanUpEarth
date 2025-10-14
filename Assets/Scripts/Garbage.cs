using UnityEngine;

public class Garbage : MonoBehaviour
{
    [SerializeField] private float destroyY = -5.7f;
    private void Update()
    {
        if (transform.position.y < destroyY)
            Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       Destroy(gameObject);
    }
}
