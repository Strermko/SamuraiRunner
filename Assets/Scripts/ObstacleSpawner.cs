using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] Vector3 spawnPosition;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] float defaultSpawnDelay = 2f;
    [Range(0.1f, 2f)]
    [SerializeField] float spawnDelayRandomizer = 0.5f;

    private float _timer;
    private float _spawnDelay;
    void Start()
    {
        _timer = 0f;
        _spawnDelay = defaultSpawnDelay;
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _spawnDelay)
        {
            SpawnObstacle();
            _spawnDelay = defaultSpawnDelay + Random.Range(0, spawnDelayRandomizer);
            _timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}