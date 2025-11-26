using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject obstaclePrefab;
    public float platformLength = 10f;
    public int initialPlatforms = 5;

    private float zSpawn = 0;

    void Start()
    {
        for (int i = 0; i < initialPlatforms; i++)
        {
            SpawnPlatform();
        }
    }

    void Update()
    {
        // genera plataformas infinitas
        if (Camera.main.transform.position.z > zSpawn - initialPlatforms * platformLength)
        {
            SpawnPlatform();
        }
    }

    void SpawnPlatform()
    {
        GameObject platform = Instantiate(platformPrefab, new Vector3(0, 0, zSpawn), Quaternion.identity);

        // 30% de probabilidad de obstáculo
        if (Random.value > 0.4f)
{
    Vector3 obstaclePos = new Vector3(Random.Range(-2f, 2f), 1, zSpawn + 3);
    Instantiate(obstaclePrefab, obstaclePos, Quaternion.identity);
}

        zSpawn += platformLength;
    }
}
