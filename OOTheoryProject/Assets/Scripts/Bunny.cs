using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bunny : Animal
{

    // Start is called before the first frame update
    void Start()
    {
        timeStep = 2;
        speed = 3;
    }

    // Update is called once per frame
    protected new void Update()
    {
        base.Update();
    }

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

    public override bool CanEat()
    {
        return false;
    }
}
