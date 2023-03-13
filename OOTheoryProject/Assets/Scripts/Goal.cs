using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Goal
{
    public string GoalText { get; private set; }
    public bool IsComplete { get; private set; }
    public GoalRequirements Requirements { get; private set; }
    public GoalRequirements FailCondition { get; private set; }

    public Goal (string text, GoalRequirements requirements, GoalRequirements failCondition)
    {
        GoalText = text;
        IsComplete = false;
        Requirements = requirements;
        FailCondition = failCondition;
    }

    public bool CheckRequirements(int time, AnimalCounts counts)
    {
        if (IsComplete)
        {
            return true;
        }

        bool completed = false;
        if (Requirements.MinTime != null && time > Requirements.MinTime)
        {
            completed = true;
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

    public bool CheckFailure(int time, AnimalCounts counts)
    {
        if (IsComplete || FailCondition == null)
        {
            return false;
        }

        if (FailCondition.MaxTime != null && time > FailCondition.MaxTime)
        {
            return true;
        }
        else if (FailCondition.MaxAnimalCount != null)
        {
            if (FailCondition.MaxAnimalCount.BunnyCount <= counts.BunnyCount ||
                FailCondition.MaxAnimalCount.FoxCount <= counts.FoxCount ||
                FailCondition.MaxAnimalCount.BearCount <= counts.BearCount)
                return true;
        }

        return false;
    }
}
