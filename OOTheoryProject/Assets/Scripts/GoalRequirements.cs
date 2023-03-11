using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GoalRequirements
{
    public int? MinTime;
    public int? MaxTime;
    public AnimalCounts MinAnimalCount;
    public AnimalCounts MaxAnimalCount;
}

[System.Serializable]
public class AnimalCounts
{
    public int? BunnyCount;
    public int? FoxCount;
    public int? BearCount;
}