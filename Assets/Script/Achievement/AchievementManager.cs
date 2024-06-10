using System.Collections.Generic;
using UnityEngine;


public class AchievementManager : MonoBehaviour
{
    public static AchievementManager instance;
    public List<Achievement> achievements;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// 업적 진행 상황을 추가합니다.
    public void AddProgress(string achievementName, int amount)
    {
        Achievement achievement = achievements.Find(a => a.name == achievementName);
        if (achievement != null)
        {
            achievement.AddProgress(amount);
        }
    }

    /// 새로운 업적을 추가합니다.
    public void AddAchievement(Achievement achievement)
    {
        achievements.Add(achievement);
    }
}
