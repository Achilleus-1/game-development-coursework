using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject pillarPrefab;
    public GameObject debrisPrefab;
    public float spawnInterval = 2f;
    public float spawnZOffset = 50f;
    public Transform player;
    private float timer;
    private int[] lanes = new int[] { -1, 0, 1 };
    private float laneWidth = 4f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    
    void SpawnObstacle()
    {
        int lane = lanes[Random.Range(0, lanes.Length)];
        float x = lane * laneWidth;
        Vector3 spawnPos = new Vector3(x, 1, player.position.z + spawnZOffset);
        GameObject prefab = Random.value > 0.5f ? pillarPrefab : debrisPrefab;
        GameObject obs = Instantiate(prefab, spawnPos, Quaternion.identity);

        obs.AddComponent<Obstacle>().lane = lane;
    }
}
