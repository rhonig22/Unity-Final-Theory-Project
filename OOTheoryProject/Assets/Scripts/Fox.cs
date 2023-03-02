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
        speed = 1;
        spawnCount = 2;
        lifeSpan = 20;
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
            int spawn = Random.Range(0, spawnCount);
            SpawnManager.Instance.SpawnFoxes(spawn);
        }
    }

    protected override void OnDestroy()
    {
        SimulationManager.CurrentFoxCount -= 1;
    }
}
