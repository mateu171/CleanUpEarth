using System.Collections;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public static Shield Instance { get; private set; }

    protected  void Awake()
    {
        Instance = this;
    }
    public void ActiveShield()
    {
        GetComponent<Animator>().Play("ShieldAnimation", -1, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      collision.gameObject.SetActive(false);
    }
}
