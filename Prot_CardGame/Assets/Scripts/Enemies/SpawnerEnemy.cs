using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] _placeForEnemy;
    [SerializeField] private Enemy[] _enemies;

    private void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        for(int i = 0; i < _placeForEnemy.Length; i++)
        {
            var prefab = _enemies[Random.Range(0, _enemies.Length)];
            
            Instantiate(prefab, RandomSpawnPlace().transform);
        }
    }

    private GameObject RandomSpawnPlace()
    {
        return _placeForEnemy[Random.Range(0, _placeForEnemy.Length)];
    }
}
