using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Animal : MonoBehaviour
{
    protected int speed;
    protected int moveStep;
    protected int procreateStep;
    protected int procreateChance;
    protected int spawnCount;
    protected int lifeSpan;
    protected int eatCount = 0;

    private int currentLife = 0;
    private int birthday;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        birthday = Timekeeper.GetTime();
        StartCoroutine(MoveStep());
        StartCoroutine(ProcreateStep());
    }

    // Update is called once per frame
    protected void Update()
    {
        // Abstracted away different tasks that need to be performed on update
        CheckLife();
    }

    private IEnumerator MoveStep()
    {
        while (SimulationManager.currentSimulationSpeed > 0)
        {
            yield return new WaitForSeconds(moveStep / SimulationManager.currentSimulationSpeed);
            Move();
            KeepInBounds();
        }
    }

    private IEnumerator ProcreateStep()
    {
        while (SimulationManager.currentSimulationSpeed > 0)
        {
            yield return new WaitForSeconds(procreateStep / SimulationManager.currentSimulationSpeed);
            Procreate();
        }
    }

    private void CheckLife()
    {
        currentLife = Timekeeper.GetTime() - birthday;
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
            eatCount++;
        }
    }

    protected virtual void OnDestroy()
    {
        
    }
}
