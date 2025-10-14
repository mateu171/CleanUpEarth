using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    [SerializeField] private GameObject coin;

    private void Spawn(Transform whereSpawn)
    {
        Instantiate(coin,whereSpawn.position,new Quaternion(0,0,0,0));
    }

    private void OnDisable()
    {
        HoverInteraction.OnDestroyGarbage -= Spawn;
    }

    private void OnEnable()
    {
        HoverInteraction.OnDestroyGarbage += Spawn;
    }
}
