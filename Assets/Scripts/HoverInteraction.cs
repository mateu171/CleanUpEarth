using System;
using Unity.VisualScripting;
using UnityEngine;

public class HoverInteraction : MonoBehaviour
{
    public static event Action OnChangeScore;
    public static event Action<Transform> OnSpawnCoin;

    private Camera _mainCamera;

    private int _layerMask;

    private void Awake()
    {
        _layerMask = LayerMask.GetMask("Iteraction");
        _mainCamera = Camera.main;
    }

    void Update()
    {
        
        Debug.DrawRay(_mainCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Color.blue);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(_mainCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,Mathf.Infinity, _layerMask);

            if (hit.collider != null)
            {
                if (hit.collider.TryGetComponent<Garbage>(out Garbage garbage))
                {
                    OnChangeScore?.Invoke();
                    OnSpawnCoin?.Invoke(hit.collider.transform);
                    garbage.DestroyGarbage();
                }

                if (hit.collider.TryGetComponent<IBoost>(out IBoost boost))
                {
                    boost.ActiveBoost();
                }
            }
           
        }
    }
}
