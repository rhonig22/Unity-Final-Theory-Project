using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

// Inheritance from base class Animal
// The bunny class has a short life span, but a chance to cause a population explosion
public class Bunny : Animal
{

    // Start is called before the first frame update
    protected override void Start()
    {
        moveStep = 1;
        procreateStep = 3;
        procreateChance = 6;
        speed = 3;
        spawnCount = Random.Range(5, 10);
        lifeSpan = Random.Range(5, 20);

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
        int hop = Random.Range(0, 4);
        switch(hop)
        {
            case 0:
                break;
            case 1:
                gameObject.transform.Rotate(Vector3.up * 180);
                break;
            case 2:
                gameObject.transform.Rotate(Vector3.up * 90);
                break;
            case 3:
                gameObject.transform.Rotate(Vector3.up * -90);
                break;
        }

        gameObject.transform.Translate( Vector3.forward * speed, Space.Self );
    }

    public override bool CanEat(Animal animal)
    {
        return false;
    }

    // Polymorphism, overriding procreation functionality
    public override void Procreate()
    {
        if (SimulationManager.CurrentBunnyCount >= 2)
        {
            int spawnChance = Random.Range(0, procreateChance);
            if (spawnChance == 0)
                SpawnManager.Instance.SpawnBunnies(spawnCount);
        }
    }

    protected override void OnDestroy()
    {
        SimulationManager.CurrentBunnyCount -= 1;
        GameObject particle = Instantiate(particles, transform.position, particles.transform.rotation);
        particle.transform.parent = gameObject.transform.parent;
    }
}
