using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    public GameObject slimePrefab;
    public float spawnInterval = 3f;

    void Start()
    {
        InvokeRepeating("SpawnSlime", 0f, spawnInterval);
    }

    void SpawnSlime()
    {
        Instantiate(slimePrefab, transform.position, Quaternion.identity);
    }
}
