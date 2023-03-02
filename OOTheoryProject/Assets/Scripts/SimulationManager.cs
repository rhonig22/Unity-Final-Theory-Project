using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimulationManager : MonoBehaviour
{
    public static SimulationManager Instance { get; private set; }

    public static float range = 20f;

    public static UnityEvent countChanged = new UnityEvent();

    private static int _initialBunnyCount = 10;
    private static int _bunnyCount = 10;
    public static int InitialBunnyCount {
        get { return _initialBunnyCount; }
        set
        {
            if (value <= 10 && value >= 0)
            {
                _initialBunnyCount = value;
                _bunnyCount = _initialBunnyCount;
            }
        }
    }

    public static int CurrentBunnyCount
    {
        get { return _bunnyCount; }
        set
        {
            if (value <= 10 && value >= 0)
            {
                _bunnyCount = value;
                countChanged.Invoke();
            }
        }
    }

    private static int _initialFoxCount = 6;
    private static int _foxCount = 6;
    public static int InitialFoxCount
    {
        get { return _initialFoxCount; }
        set
        {
            if (value <= 6 && value >= 0)
            {
                _initialFoxCount = value;
                _foxCount = _initialFoxCount;
            }
        }
    }

    public static int CurrentFoxCount
    {
        get { return _foxCount; }
        set
        {
            if (value <= 6 && value >= 0)
            {
                _foxCount = value;
                countChanged.Invoke();
            }
        }
    }

    private static int _initialBearCount = 3;
    private static int _bearCount = 3;
    public static int InitialBearCount
    {
        get { return _initialBearCount; }
        set
        {
            if (value <= 3 && value >= 0)
            {
                _initialBearCount = value;
                _bearCount = _initialBearCount;
            }
        }
    }

    public static int CurrentBearCount
    {
        get { return _bearCount; }
        set
        {
            if (value <= 3 && value >= 0)
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
