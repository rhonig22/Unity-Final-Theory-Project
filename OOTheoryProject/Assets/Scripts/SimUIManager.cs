using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SimUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bunnyCount;
    [SerializeField] private TextMeshProUGUI foxCount;
    [SerializeField] private TextMeshProUGUI bearCount;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI goalText;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject failScreen;
    private DataManager dataManager;

    // Start is called before the first frame update
    void Start()
    {
        UpdateCountText();
        SimulationManager.countChanged.AddListener(UpdateCountText);
        dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();
        UpdateGoalText();
        dataManager.goalCompleted.AddListener(EndSim);
        dataManager.goalFailed.AddListener(Failed);
    }

    // Update is called once per frame
    void Update()
    {
        timerText.SetText("Time Passed: " + Timekeeper.GetTime());
        moneyText.SetText("Money: " + MoneyManager.Money);
    }

    private void UpdateCountText()
    {
        bunnyCount.SetText("Bunny Count: " + SimulationManager.CurrentBunnyCount);
        foxCount.SetText("Fox Count: " + SimulationManager.CurrentFoxCount);
        bearCount.SetText("Bear Count: " + SimulationManager.CurrentBearCount);
    }

    private void UpdateGoalText()
    {
        string goalString = dataManager.ActiveGoal.GoalText;
        goalText.SetText(goalString);
    }

    private void EndSim()
    {
        Timekeeper.StopTime();
        winScreen.SetActive(true);
    }

    private void Failed()
    {
        Timekeeper.StopTime();
        failScreen.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene(0);
    }

    public void AddHunter()
    {
        MoneyManager.Instance.AddHunter();
    }
}
