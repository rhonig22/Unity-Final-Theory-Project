using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : Animal
{
    // Start is called before the first frame update
    void Start()
    {
        timeStep = 3;
        speed = 1;
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

    public override bool CanEat()
    {
        return true;
    }
}
