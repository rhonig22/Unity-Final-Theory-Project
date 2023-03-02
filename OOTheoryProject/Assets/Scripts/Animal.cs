using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    protected int speed;

    protected int timeStep;

    private int currentStep = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected void Update()
    {
        if (Mathf.FloorToInt(Time.time) >= currentStep + timeStep)
        {
            Move();
            currentStep = Mathf.FloorToInt(Time.time);
        }

        KeepInBounds();
    }

    private void KeepInBounds()
    {
        Vector3 pos = gameObject.transform.position;
        if (gameObject.transform.position.x > SimulationManager.range)
            pos.x = SimulationManager.range;
        else if (gameObject.transform.position.x < -SimulationManager.range)
            pos.x = -SimulationManager.range;

        if (gameObject.transform.position.y > SimulationManager.range)
            pos.y = SimulationManager.range;
        else if (gameObject.transform.position.y < -SimulationManager.range)
            pos.y = -SimulationManager.range;

        gameObject.transform.position.Set(pos.x, pos.y, pos.z);
    }

    public virtual void Move()
    {

    }

    public virtual bool CanEat()
    {
        return false;
    }
}
