using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataManager : MonoBehaviour
{
    public List<Goal> Goals = new List<Goal>();
    public UnityEvent goalCompleted = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        Goal initial = new Goal("Hit a population of 500 Bunnies!",
            new GoalRequirements
            {
                MinAnimalCount = new AnimalCounts { BunnyCount = 500, FoxCount = 0, BearCount = 0 }
            });
        Goals.Add(initial);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        int time = Timekeeper.GetTime();
        AnimalCounts counts = new AnimalCounts { 
            BunnyCount = SimulationManager.CurrentBunnyCount,
            FoxCount= SimulationManager.CurrentFoxCount,
            BearCount= SimulationManager.CurrentBearCount
        };

        foreach (Goal goal in Goals)
        {
            if (goal.CheckRequirements(time, counts))
            {
                Timekeeper.StopTime();
                goalCompleted.Invoke();
            }
        }
    }
}
