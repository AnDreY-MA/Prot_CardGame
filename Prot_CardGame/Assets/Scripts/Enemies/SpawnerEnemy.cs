using UnityEngine;
using System.Collections.Generic;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] _placeForEnemy;
    [SerializeField] private Enemy[] _enemies;

    private List<GameObject> _spawnedPlace = new List<GameObject>();

    private void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        //var countEnemy = Random.Range(1, 3);
        for(int i = 0; i < 3; i++)
        {
            var prefabEnemy = _enemies[Random.Range(0, _enemies.Length)];
            GameObject randomPlace = RandomSpawnPlace();

            if (_spawnedPlace.Contains(randomPlace) == false)
            {
                Enemy newEnemy = Instantiate(prefabEnemy);
                newEnemy.transform.position = randomPlace.transform.position;
                newEnemy.transform.rotation = randomPlace.transform.rotation;
                _spawnedPlace.Add(randomPlace);
            }
        }
    }

    private GameObject RandomSpawnPlace()
    {
        return _placeForEnemy[Random.Range(0, _placeForEnemy.Length)];
    }
}
