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

    // Start is called before the first frame update
    void Start()
    {
        bunnyCount.SetText("Bunny Count: " + SimulationManager.InitialBunnyCount);
        foxCount.SetText("Fox Count: " + SimulationManager.InitialFoxCount);
        bearCount.SetText("Bear Count: " + SimulationManager.InitialBearCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
