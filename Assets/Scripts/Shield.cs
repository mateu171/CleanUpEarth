using System.Collections;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private float shieldDuration = 5;
    public static Shield Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    public void ActiveShield()
    {
        GetComponent<Animator>().Play("ShieldAnimation", -1, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
