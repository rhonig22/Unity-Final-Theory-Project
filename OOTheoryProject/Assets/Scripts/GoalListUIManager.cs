using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoalListUIManager : MonoBehaviour
{
    [SerializeField] GameObject goalPage;
    private DataManager dataManager;

    private void Start()
    {
        dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();
        PopulateGoals();
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene(0);
    }

    private void PopulateGoals()
    {
        Vector2 position = new Vector2(0, -150);
        Vector2 anchor = new Vector2(.5f, 1);
        Vector2 size = new Vector2(800, 50);
        float height = 50f;
        int count = 1;
        foreach (Goal goal in dataManager.Goals)
        {
            GameObject textObject = new GameObject();
            textObject.transform.parent = goalPage.transform;
            TextMeshProUGUI textComponent = textObject.AddComponent<TextMeshProUGUI>();
            textComponent.text = count + ".\t" + goal.GoalText;
            if (goal.IsComplete)
            {
                textComponent.fontStyle = FontStyles.Strikethrough;
            }

            textComponent.rectTransform.anchorMin = anchor;
            textComponent.rectTransform.anchorMax = anchor;
            textComponent.rectTransform.anchoredPosition = position;
            textComponent.rectTransform.sizeDelta = size;
            position.y -= height;
            count++;
        }
    }
}
