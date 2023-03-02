using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// The logic managing the animal counts is encapsulated in the simulation manager
public class SimulationManager : MonoBehaviour
{
    public static SimulationManager Instance { get; private set; }

    public static float xrange = 20f;
    public static float yrange = 18f;

    public static int currentSimulationSpeed = 1;

    public static UnityEvent countChanged = new UnityEvent();

    private static int _initialBunnyCount = 10;
    private static int _bunnyCount = 0;
    public static int InitialBunnyCount {
        get { return _initialBunnyCount; }
        set
        {
            // verify user inputs are within range
            if (value <= 10 && value >= 0)
            {
                _initialBunnyCount = value;
            }
        }
    }

    public static int CurrentBunnyCount
    {
        get { return _bunnyCount; }
        set
        {
            if (value >= 0)
            {
                _bunnyCount = value;
                countChanged.Invoke();
            }
        }
    }

    private static int _initialFoxCount = 6;
    private static int _foxCount = 0;
    public static int InitialFoxCount
    {
        get { return _initialFoxCount; }
        set
        {
            // verify user inputs are within range
            if (value <= 6 && value >= 0)
            {
                _initialFoxCount = value;
            }
        }
    }

    public static int CurrentFoxCount
    {
        get { return _foxCount; }
        set
        {
            if (value >= 0)
            {
                _foxCount = value;
                countChanged.Invoke();
            }
        }
    }

    private static int _initialBearCount = 3;
    private static int _bearCount = 0;
    public static int InitialBearCount
    {
        get { return _initialBearCount; }
        set
        {
            // verify user inputs are within range
            if (value <= 3 && value >= 0)
            {
                _initialBearCount = value;
            }
        }
    }

    public static int CurrentBearCount
    {
        get { return _bearCount; }
        set
        {
            if (value >= 0)
            {
                _bearCount = value;
                countChanged.Invoke();
            }
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
