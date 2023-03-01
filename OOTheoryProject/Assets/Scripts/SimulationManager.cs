using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    public static SimulationManager Instance { get; private set; }

    private static int _bunnyCount = 10;
    public static int InitialBunnyCount {
        get { return _bunnyCount; }
        set
        {
            if (value <= 10 && value >= 0)
                _bunnyCount = value;
        }
    }

    private static int _foxCount = 6;
    public static int InitialFoxCount
    {
        get { return _foxCount; }
        set
        {
            if (value <= 6 && value >= 0)
                _foxCount = value;
        }
    }

    private static int _bearCount = 3;
    public static int InitialBearCount
    {
        get { return _bearCount; }
        set
        {
            if (value <= 3 && value >= 0)
                _bearCount = value;
        }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
