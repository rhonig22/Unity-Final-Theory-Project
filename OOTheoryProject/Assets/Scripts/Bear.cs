using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : Animal
{
    // Start is called before the first frame update
    protected override void Start()
    {
        moveStep = 3;
        procreateStep = 20;
        speed = 1;
        spawnCount = 2;
        lifeSpan = 100;
        base.Start();
    }

    // Update is called once per frame
    protected new void Update()
    {
        base.Update();
    }

    public override void Move()
    {
        int lumber = Random.Range(0, 3);
        switch (lumber)
        {
            case 0:
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
        return animal is Fox || animal is Bear;
    }

    public override void Procreate()
    {
        if (SimulationManager.CurrentBearCount >= 2)
        {
            int spawn = Random.Range(0, spawnCount);
            SpawnManager.Instance.SpawnBears(spawn);
        }
    }

    protected override void OnDestroy()
    {
        SimulationManager.CurrentBearCount -= 1;
    }
}
