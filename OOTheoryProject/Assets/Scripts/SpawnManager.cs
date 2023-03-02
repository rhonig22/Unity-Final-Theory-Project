using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get; private set; }

    [SerializeField] private GameObject bunnyPrefab;
    [SerializeField] private GameObject foxPrefab;
    [SerializeField] private GameObject bearPrefab;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        SpawnBunnies(SimulationManager.InitialBunnyCount);
        SpawnFoxes(SimulationManager.InitialFoxCount);
        SpawnBears(SimulationManager.InitialBearCount);
    }

    public void SpawnBunnies(int bunnyCount)
    {
        SimulationManager.CurrentBunnyCount += bunnyCount;
        for (int i = 0; i < bunnyCount; i++)
        {
            Vector3 newPos = GetRandomPosition();
            newPos.y = bunnyPrefab.transform.localScale.y/2;
            Instantiate(bunnyPrefab, newPos, bunnyPrefab.transform.rotation);
        }
    }

    public void SpawnFoxes(int foxCount)
    {
        SimulationManager.CurrentFoxCount += foxCount;
        for (int i = 0; i < foxCount; i++)
        {
            Vector3 newPos = GetRandomPosition();
            newPos.y = foxPrefab.transform.localScale.y / 2;
            Instantiate(foxPrefab, newPos, foxPrefab.transform.rotation);
        }
    }

    public void SpawnBears(int bearCount)
    {
        SimulationManager.CurrentBearCount += bearCount;
        for (int i = 0; i < bearCount; i++)
        {
            Vector3 newPos = GetRandomPosition();
            newPos.y = bearPrefab.transform.localScale.y / 2;
            Instantiate(bearPrefab, newPos, bearPrefab.transform.rotation);
        }
    }

    private Vector3 GetRandomPosition()
    {
        float spawnPosX = Random.Range(-SimulationManager.xrange, SimulationManager.xrange);
        float spawnPosZ = Random.Range(-SimulationManager.yrange, SimulationManager.yrange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
