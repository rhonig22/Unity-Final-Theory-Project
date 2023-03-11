using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Goal
{
    public string GoalText { get; private set; }
    public bool IsComplete { get; private set; }
    public GoalRequirements Requirements { get; private set; }

    public Goal (string text, GoalRequirements requirements)
    {
        GoalText = text;
        IsComplete = false;
        Requirements = requirements;
    }

    public bool CheckRequirements(int time, AnimalCounts counts)
    {
        if (IsComplete)
        {
            return true;
        }

        bool completed = false;
        if (Requirements.MinTime != null)
        {
            
        }
        else if (Requirements.MaxTime != null)
        {

        }
        else if (Requirements.MinAnimalCount!= null)
        {
            if (Requirements.MinAnimalCount.BunnyCount <= counts.BunnyCount &&
                Requirements.MinAnimalCount.FoxCount <= counts.FoxCount &&
                Requirements.MinAnimalCount.BearCount <= counts.BearCount)
                completed= true;
        }

        if (completed)
        {
            IsComplete = true;
            return true;
        }

        return false;
    }
}
