using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : Animal
{
    // Start is called before the first frame update
    void Start()
    {
        timeStep = 1;
        speed = 1;
    }

    // Update is called once per frame
    protected new void Update()
    {
        base.Update();
    }

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

    public override bool CanEat()
    {
        return true;
    }
}
