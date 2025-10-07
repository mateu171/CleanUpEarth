using System;
using Unity.VisualScripting;
using UnityEngine;

public class HoverInteraction : MonoBehaviour
{
    public static event Action OnChangeScore;
    [SerializeField] private float distance;

    private int _layerMask;

    private void Awake()
    {
        _layerMask = LayerMask.GetMask("Garbage");
    }

    void Update()
    {
        Debug.DrawRay(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.main.transform.up * distance, Color.blue);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.main.transform.up, distance, _layerMask);

            if (hit.collider != null)
            {
                if (hit.collider.TryGetComponent<Garbage>(out Garbage garbage))
                {
                    OnChangeScore?.Invoke();
                    Destroy(hit.collider.gameObject);
                }
            }
           
        }
    }
}
