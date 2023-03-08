using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inheritance from base class Animal
// The fox class has a medium lifespan and can eat bunnies
public class Fox : Animal
{
    // Start is called before the first frame update
    protected override void Start()
    {
        moveStep = 1;
        procreateStep = 10;
        procreateChance = 2;
        speed = 1;
        spawnCount = 1;
        lifeSpan = Random.Range(20, 30); ;
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
        int slink = Random.Range(0, 3);
        switch (slink)
        {
            case 0:
                break;
            case 1:
                gameObject.transform.Rotate(Vector3.up * 45);
                break;
            case 2:
                gameObject.transform.Rotate(Vector3.up * -45);
                break;
        }

        gameObject.transform.Translate(Vector3.forward * speed, Space.Self);
    }

    public override bool CanEat(Animal animal)
    {
        return animal is Bunny;
    }

    // Polymorphism, overriding procreation functionality
    public override void Procreate()
    {
        if (SimulationManager.CurrentFoxCount >= 2)
        {
            int spawnChance = Random.Range(0, procreateChance);
            if (spawnChance == 0)
                SpawnManager.Instance.SpawnFoxes(spawnCount);
        }
    }

    protected override void OnDestroy()
    {
        SimulationManager.CurrentFoxCount -= 1;
    }
}
