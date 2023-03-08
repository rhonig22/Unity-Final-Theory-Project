using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timekeeper : MonoBehaviour
{
    public static Timekeeper Instance { get; private set; }

    private static int time;
    private static IEnumerator passTime;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        time = 0;
        passTime = PassTime();
        StartCoroutine(passTime);
    }

    public static int GetTime()
    {
        return time;
    }

    private IEnumerator PassTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1 / SimulationManager.currentSimulationSpeed);
            time++;
        }
    }

    public static void StopTime()
    {
        Instance.StopCoroutine(passTime);
    }
}
