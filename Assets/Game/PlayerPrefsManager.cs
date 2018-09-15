using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class PlayerPrefsManager : MonoBehaviour
    {
        const string MASTER_VOLUME_KEY = "master_volume";
        const string DIFFICULTY_KEY = "difficulty";
        const string LEVEL_KEY = "level_unlocked_";

        public static void SetMasterVolume(float volume)
        {
            if (volume >= 0f && volume <= 1f)
            {
                PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
            }
            else
            {
                Debug.LogError("Master volume out of range");
            }
        }

        public static float GetMasteVolume()
        {
            return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
        }

        public static void UnlockLevel(int level)
        {
            if (level <= SceneManager.sceneCountInBuildSettings - 1)
            {
                PlayerPrefs.SetInt(LEVEL_KEY + level, 1);
            }
            else
            {
                Debug.LogError("Trying to unlock level not in build order");
            }
        }

        public static bool IsLevelUnlocked(int level)
        {
            var levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level);
            var isLevelUnlocked = levelValue == 1;

            if (level <= SceneManager.sceneCountInBuildSettings - 1)
            {
                return isLevelUnlocked;
            }

            Debug.LogError("trying to query level not in build order");
            return false;
        }

        public static void SetDifficulty(float difficultyNum)
        {
            if (difficultyNum > 1 && difficultyNum <= 3)
            {
                PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficultyNum);
            }
            else
            {
                Debug.LogError("Difficulty out of range");
            }
        }

        public static float GetDifficulty()
        {
            return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
        }
    }
}
