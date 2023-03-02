using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject bunnyPrefab;
    [SerializeField] private GameObject foxPrefab;
    [SerializeField] private GameObject bearPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBunnies(SimulationManager.InitialBunnyCount);
        SpawnFoxes(SimulationManager.InitialFoxCount);
        SpawnBears(SimulationManager.InitialBearCount);
    }

    private void SpawnBunnies(int bunnyCount)
    {
        for (int i = 0; i < bunnyCount; i++)
        {
            Vector3 newPos = GetRandomPosition();
            newPos.y = bunnyPrefab.transform.localScale.y/2;
            Instantiate(bunnyPrefab, newPos, bunnyPrefab.transform.rotation);
        }
    }

    private void SpawnFoxes(int foxCount)
    {
        for (int i = 0; i < foxCount; i++)
        {
            Vector3 newPos = GetRandomPosition();
            newPos.y = foxPrefab.transform.localScale.y / 2;
            Instantiate(foxPrefab, newPos, foxPrefab.transform.rotation);
        }
    }

    private void SpawnBears(int bearCount)
    {
        for (int i = 0; i < bearCount; i++)
        {
            Vector3 newPos = GetRandomPosition();
            newPos.y = bearPrefab.transform.localScale.y / 2;
            Instantiate(bearPrefab, newPos, bearPrefab.transform.rotation);
        }
    }

    private Vector3 GetRandomPosition()
    {
        float spawnPosX = Random.Range(-SimulationManager.range, SimulationManager.range);
        float spawnPosZ = Random.Range(-SimulationManager.range, SimulationManager.range);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
