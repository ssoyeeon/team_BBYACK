using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementUI : MonoBehaviour
{
    public GameObject achievementPanel;
    public GameObject achievementItemPrefab;
    public Transform content;

    private List<GameObject> achievementItems = new List<GameObject>();

    private void Start()
    {
        UpdateAchievementUI();
    }    

    public void UpdateAchievementUI()
    {
        ClearAchievementUI();
        foreach(var achievement in AchievementManager.instance.achievements)
        {
            GameObject item = Instantiate(achievementItemPrefab, content);
            Text[] texts = item.GetComponentsInChildren<Text>();
            texts[0].text = achievement.name;
            texts[1].text = achievement.description;
            texts[2].text = $"{achievement.currentProgress}/{achievement.goal}";
            texts[3].text = achievement.isUnlocked ? "含失" : "耕含失";
        }
    }
    
    private void ClearAchievementUI()
    {
        foreach (var item in achievementItems)
        {
            Destroy(item);
        }
        achievementItems.Clear();
    }

    public void ToggleAchievementPanel()
    {
        achievementPanel.SetActive(!achievementPanel.activeSelf);
    }
}
