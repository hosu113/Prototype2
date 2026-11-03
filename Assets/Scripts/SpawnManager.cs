using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public InputAction spawnAction;

    private float spawnRangeX = 20.0f;
    private float spawnPosZ = 20.0f;

    public float startDelay = 2.0f;

    public float spawnIntervalMin = 2.0f;
    public float spawnIntervalMax = 5.0f;

    //public float spawnInterval = 2.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        Invoke("SpawnRandomAnimal", startDelay);
        spawnAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        Instantiate(animalPrefabs[animalIndex], spawnPos,
            animalPrefabs[animalIndex].transform.rotation);
        
        float randomSpawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);

        //Debug.Log("생성까지" + randomSpawnInterval + "초");

        Invoke("SpawnRandomAnimal", randomSpawnInterval);
    }
}