using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    public GameObject treePrefab;
    public int numberOfTrees = 10;  // Adjust this to control the number of trees to spawn
    public float spawnY = 1f;  // Set the Y coordinate where you want the trees to spawn
    public Vector2 randomRange;


    void Start()
    {
        SpawnTrees();
    }

    void SpawnTrees()
    {
        for (int i = 0; i < numberOfTrees; i++)
        {
            float randomX = Random.Range(randomRange.x, randomRange.y);  // Adjust the range based on your scene
            Vector2 spawnPosition = new Vector2(randomX, spawnY);
            Instantiate(treePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
