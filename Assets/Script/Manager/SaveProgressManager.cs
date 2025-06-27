using UnityEngine;
using System.Collections.Generic;

public class SaveProgressManager
{
    public HashSet<int> completedLevels = new();
    public int highestLevelCompleted = 0;

    public void LoadProgress()
    {
        highestLevelCompleted = PlayerPrefs.GetInt("HighestLevel", 0);
        completedLevels.Clear();
        for (int i = 0; i <= highestLevelCompleted; i++)
        {
            completedLevels.Add(i);
        }
    }

    public void SaveProgress()
    {
        PlayerPrefs.SetInt("HighestLevel", highestLevelCompleted);
        PlayerPrefs.Save();
    }

    public bool IsLevelCompleted(int levelIndex)
    {
        return completedLevels.Contains(levelIndex);
    }

    public void MarkLevelCompleted(int levelIndex)
    {
        if (!completedLevels.Contains(levelIndex))
        {
            completedLevels.Add(levelIndex);
            if (levelIndex > highestLevelCompleted)
                highestLevelCompleted = levelIndex;
        }
    }

    public void ResetProgress()
    {
        completedLevels.Clear();
        highestLevelCompleted = 0;
        PlayerPrefs.DeleteKey("HighestLevel");
    }
}
