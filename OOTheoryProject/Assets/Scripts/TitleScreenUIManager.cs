using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenUIManager : MonoBehaviour
{
    private DataManager dataManager;

    private void Start()
    {
        dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();
    }

    public void StartGame()
    {
        dataManager.SetActiveGoal();
        SceneManager.LoadScene(1);
    }

    public void ViewGoalsList()
    {
        SceneManager.LoadScene(2);
    }

    public void EndBunnyEdit(string count)
    {
        Debug.Log(count);
        if (int.TryParse(count, out int num))
            SimulationManager.InitialBunnyCount = num;
    }

    public void EndFoxEdit(string count)
    {
        Debug.Log(count);
        if (int.TryParse(count, out int num))
            SimulationManager.InitialFoxCount = num;
    }

    public void EndBearEdit(string count)
    {
        Debug.Log(count);
        if (int.TryParse(count, out int num))
            SimulationManager.InitialBearCount = num;
    }
}
