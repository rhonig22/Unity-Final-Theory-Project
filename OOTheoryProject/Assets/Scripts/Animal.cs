using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    protected int speed;
    protected int moveStep;
    protected int procreateStep;
    protected int spawnCount;
    protected int lifeSpan;

    private int currentMoveStep = 0;
    private int currentLife = 0;
    private int birthday;
    private int currentProcreateStep;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        birthday = GetTime();
        currentProcreateStep = GetTime();
    }

    // Update is called once per frame
    protected void Update()
    {
        // Abstracted away different tasks that need to be performed on update
        CheckProcreate();
        CheckLife();
        CheckMove();
        KeepInBounds();
    }

    private int GetTime()
    {
        return Mathf.FloorToInt(Time.time) * SimulationManager.currentSimulationSpeed;
    }

    private void CheckMove()
    {
        if (GetTime() >= currentMoveStep + moveStep)
        {
            Move();
            currentMoveStep = GetTime();
        }
    }

    private void CheckProcreate()
    {
        if (GetTime() >= currentProcreateStep + procreateStep)
        {
            Procreate();
            currentProcreateStep = GetTime();
        }
    }

    private void CheckLife()
    {
        currentLife = GetTime() - birthday;
        if (currentLife == lifeSpan)
        {
            Destroy(gameObject);
        }
    }

    private void KeepInBounds()
    {
        Vector3 pos = gameObject.transform.position;
        if (gameObject.transform.position.x > SimulationManager.xrange)
            pos.x = SimulationManager.xrange;
        else if (gameObject.transform.position.x < -SimulationManager.xrange)
            pos.x = -SimulationManager.xrange;

        if (gameObject.transform.position.y > SimulationManager.yrange)
            pos.y = SimulationManager.yrange;
        else if (gameObject.transform.position.y < -SimulationManager.yrange)
            pos.y = -SimulationManager.yrange;

        gameObject.transform.position.Set(pos.x, pos.y, pos.z);
    }

    public virtual void Move()
    {

    }

    public virtual bool CanEat(Animal animal)
    {
        return false;
    }

    public virtual void Procreate()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("collision");
        Animal animal = collision.gameObject.GetComponent<Animal>();
        if (CanEat(animal))
        {
            Destroy(collision.gameObject);
            lifeSpan++;
        }
    }

    protected virtual void OnDestroy()
    {
        
    }
}
