using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnManagerLeft : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public InputAction spawnAction;

    private float spawnRangeZMax = 18.0f;
    private float spawnRangeZMin = -4.0f;
    private float spawnPosX = -23.0f;

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
        //랜덤 범위에서 최대 범위는 동물배열(animalPrefabs)의 길이.
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        //스폰 위치 설정.
        Vector3 spawnPos = new Vector3(spawnPosX, 0, Random.Range(spawnRangeZMin,spawnRangeZMax));

        // 복제할 오브젝트, 스폰 위치, 회전
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
        
        //스폰 시간 랜덤(최소, 최대 사이)
        float randomSpawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
        Invoke("SpawnRandomAnimal", randomSpawnInterval);
    }
}