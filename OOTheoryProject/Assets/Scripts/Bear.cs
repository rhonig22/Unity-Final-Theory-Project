using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inheritance from base class Animal
// The bear class has a long lifespan and can eat both bunnies and foxes
public class Bear : Animal
{
    // Start is called before the first frame update
    protected override void Start()
    {
        moveStep = 1;
        procreateStep = 20;
        procreateChance = 50;
        speed = 1;
        spawnCount = 1;
        lifeSpan = Random.Range(100, 120);
        base.Start();
    }

    // Update is called once per frame
    protected new void Update()
    {
        base.Update();
    }

    // Polymorphism, overriding move functionality
    public override void Move()
    {
        int lumber = Random.Range(0, 4);
        switch (lumber)
        {
            case 0:
            case 3:
                gameObject.transform.Translate(Vector3.forward * speed, Space.Self);
                break;
            case 1:
                gameObject.transform.Rotate(Vector3.up * 90);
                break;
            case 2:
                gameObject.transform.Rotate(Vector3.up * -90);
                break;
        }

    }

    public override bool CanEat(Animal animal)
    {
        return animal is Fox || animal is Bunny;
    }

    // Polymorphism, overriding procreation functionality
    public override void Procreate()
    {
        if (SimulationManager.CurrentBearCount >= 2)
        {
            int spawnChance = Random.Range(0, procreateChance - eatCount);
            if (spawnChance == 0)
                SpawnManager.Instance.SpawnBears(spawnChance);
        }
    }

    protected override void OnDestroy()
    {
        SimulationManager.CurrentBearCount -= 1;
    }
}
