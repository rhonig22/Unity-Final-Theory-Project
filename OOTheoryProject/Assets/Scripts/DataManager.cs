using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }
    public List<Goal> Goals = new List<Goal>();
    public Goal ActiveGoal { get; private set; }
    public UnityEvent goalCompleted = new UnityEvent();
    public UnityEvent goalFailed = new UnityEvent();

    void Awake()
    {
        // Set up singleton
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Populate Goals
        PopulateGoals();
        SetActiveGoal();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (SceneManager.GetActiveScene().name == "Simulation")
        {
            int time = Timekeeper.GetTime();
            AnimalCounts counts = new AnimalCounts
            {
                BunnyCount = SimulationManager.CurrentBunnyCount,
                FoxCount = SimulationManager.CurrentFoxCount,
                BearCount = SimulationManager.CurrentBearCount
            };

            if (ActiveGoal.CheckFailure(time, counts))
            {
                Timekeeper.StopTime();
                goalFailed.Invoke();
            }
            else if (ActiveGoal.CheckRequirements(time, counts))
            {
                Timekeeper.StopTime();
                goalCompleted.Invoke();
            }
        }
    }

    public void SetActiveGoal()
    {
        foreach (Goal goal in Goals)
        {
            if (!goal.IsComplete)
            {
                ActiveGoal = goal;
                break;
            }
        }
    }

    private void PopulateGoals()
    {
        // Initial goal population
        Goal initial = new Goal("Hit a population of 500 Bunnies!",
            new GoalRequirements
            {
                MinAnimalCount = new AnimalCounts { BunnyCount = 500, FoxCount = 0, BearCount = 0 }
            }, null);
        Goals.Add(initial);

        Goal second = new Goal("Keep the bunny population below 100 for 60 seconds!",
            new GoalRequirements
            {
                MinTime = 60
            },
            new GoalRequirements
            {
                MaxAnimalCount = new AnimalCounts { BunnyCount = 100, FoxCount = 100, BearCount = 100 },
                MinAnimalCount = new AnimalCounts { BunnyCount = 0, FoxCount = -1, BearCount = -1 }
            });
        Goals.Add(second);

    }
}
