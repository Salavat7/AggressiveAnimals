using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]private GameObject[] _animalPrefabs;
    private float _xSpawnRangeTop = 20;
    private float _zSpawnPosTop = 20;
    private float _ySpawnPos = 0;
    private Quaternion _directionOfAnimalTop = Quaternion.Euler(0, 180, 0);

    private float _xSpawnPosRight = 20;
    private float _zSpawnRangeRight = 20;
    private Quaternion _directionOfAnimalRight = Quaternion.Euler(0, -90, 0);

    private float _xSpawnPosLeft = -20;
    private float _zSpawnRangeLeft = 20;
    private Quaternion _directionOfAnimalLeft = Quaternion.Euler(0, 90, 0);

    private float _startDelay = 2;
    private float _spawnInterval = 1.5f;

    private void Start()
    {
        InvokeRepeating("SpawnRandomAnimalTop", _startDelay, _spawnInterval);
        InvokeRepeating("SpawnRandomAnimalLeft", _startDelay, _spawnInterval);
        InvokeRepeating("SpawnRandomAnimalRight", _startDelay, _spawnInterval);
    }

    private void SpawnRandomAnimalTop()
    {
        float randomPosX = Random.Range(-_xSpawnRangeTop, _xSpawnRangeTop);
        Vector3 spawnPos = new Vector3(randomPosX, _ySpawnPos, _zSpawnPosTop);
        int animalIndex = Random.Range(0, _animalPrefabs.Length);
        Instantiate(_animalPrefabs[animalIndex], spawnPos, _directionOfAnimalTop);
    }

    private void SpawnRandomAnimalLeft()
    {
        float randomPosZ = Random.Range(-_zSpawnRangeLeft, _zSpawnRangeLeft);
        Vector3 spawnPos = new Vector3(_xSpawnPosLeft, _ySpawnPos, randomPosZ);
        int animalIndex = Random.Range(0, _animalPrefabs.Length);
        Instantiate(_animalPrefabs[animalIndex], spawnPos, _directionOfAnimalLeft);
    }

    private void SpawnRandomAnimalRight()
    {
        float randomPosZ = Random.Range(-_zSpawnRangeRight, _zSpawnRangeRight);
        Vector3 spawnPos = new Vector3(_xSpawnPosRight, _ySpawnPos, randomPosZ);
        int animalIndex = Random.Range(0, _animalPrefabs.Length);
        Instantiate(_animalPrefabs[animalIndex], spawnPos, _directionOfAnimalRight);
    }
}
