using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SimUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bunnyCount;
    [SerializeField] private TextMeshProUGUI foxCount;
    [SerializeField] private TextMeshProUGUI bearCount;
    [SerializeField] private TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateCountText();
        SimulationManager.countChanged.AddListener(UpdateCountText);
    }

    // Update is called once per frame
    void Update()
    {
        timerText.SetText("Time Passed: " + Timekeeper.GetTime());
    }

    private void UpdateCountText()
    {
        bunnyCount.SetText("Bunny Count: " + SimulationManager.CurrentBunnyCount);
        foxCount.SetText("Fox Count: " + SimulationManager.CurrentFoxCount);
        bearCount.SetText("Bear Count: " + SimulationManager.CurrentBearCount);

    }
}
