using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance { get; private set; }
    public static int Money { get; private set; }
    public static int Hunters { get; private set; }
    private int currentTime = 0;
    private int pricePerBunny = 3;
    private int pricePerHunter = 5;

    public void AddHunter()
    {
        if (Money >= pricePerHunter)
        {
            Money -= pricePerHunter;
            Hunters++;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        Money = 5;
        Hunters = 0;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Timekeeper.GetTime() > currentTime)
        {
            currentTime = Timekeeper.GetTime();
            Hunt();
        }
    }

    void Hunt()
    {
        GameObject[] bunnies = GameObject.FindGameObjectsWithTag("Bunny");
        for (int i = 0; i < Hunters; i++)
        {
            if (bunnies.Length == 0)
                break;

            int index = Random.Range(0, bunnies.Length);
            Destroy(bunnies[index]);
            Money += pricePerBunny;
            bunnies = GameObject.FindGameObjectsWithTag("Bunny");
        }
    }

}
