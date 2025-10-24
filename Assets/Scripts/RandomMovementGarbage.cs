using System.Collections;
using UnityEngine;

public class RandomMovementGarbage : Garbage
{
    [SerializeField] private float amplitude = 1f;
    [SerializeField] private float frequency = 2f;

    private float startX;
    private float time;

    private void Start()
    {
        base.Start();
        startX = transform.position.x;
    }

    private void Update()
    {
        time += Time.deltaTime;

        float x = startX + Mathf.Sin(time * frequency) * amplitude;
        float y = transform.position.y - 2f * Time.deltaTime;

        transform.position = new Vector3(x, y, transform.position.z);
    }
}
