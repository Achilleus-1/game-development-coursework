using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Treasure Settings")] //looks pretty
    public GameObject treasurePrefab;
    public int totalTreasures = 3;
    public Vector3 spawnAreaCenter;
    public Vector3 spawnAreaSize;
    public float treasureSpawnYOffset = 0.5f;
    [Header("Audio")] //looks pretty too
    public AudioClip winSound;
    public AudioSource backgroundMusic;
    public AudioSource winMusicSource;

    private int treasuresCollected = 0;

    
    
    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        backgroundMusic?.Play();
        SpawnTreasures();
    }

    void SpawnTreasures()
    {
        for (int i = 0; i < totalTreasures; i++)
        {
            Vector3 randomPos = GetRandomPositionInArea();
            Instantiate(treasurePrefab, randomPos, Quaternion.identity);
        } 
    }

    Vector3 GetRandomPositionInArea()
    
    {
        Vector3 halfSize = spawnAreaSize * 0.5f;
        float x = Random.Range(-halfSize.x, halfSize.x);
        float z = Random.Range(-halfSize.z, halfSize.z);
        float y = spawnAreaCenter.y + treasureSpawnYOffset;
        return spawnAreaCenter + new Vector3(x, y, z);
    } 

    public void TreasureCollected()
    {
        treasuresCollected++;
        if (treasuresCollected >= totalTreasures)
        {
            StartCoroutine(WinSequence());
        }
        
    }

    System.Collections.IEnumerator WinSequence()
    {
        backgroundMusic?.Stop();
        if (winMusicSource != null && winSound != null)
        {
            winMusicSource.clip = winSound;
            winMusicSource.Play();
        }
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
