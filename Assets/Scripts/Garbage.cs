using UnityEngine;

public class Garbage : MonoBehaviour
{
    [SerializeField] private GameObject coin;
    private void Update()
    {
        if (transform.position.y < -5.70)
            Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       Destroy(gameObject);
    }

    public void SpawnCoin()
    {
        Instantiate(coin, transform.position, new Quaternion(0,0,0,0));
    }
}
