using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelManagement
{
    public class LevelLoader : MonoBehaviour
    {
        private static int mainMenuIndex;
        public static void LoadLevel(string levelName)
        {
            if (Application.CanStreamedLevelBeLoaded(levelName))
            {
                SceneManager.LoadScene(levelName);
            }
            else
            {
                Debug.LogWarning("LEVELLOADER LoadLevel Error: invalid scene specified!");
            }

        }

        public static void LoadLevel(int levelIndex)
        {
            if (levelIndex >= 0 && levelIndex < SceneManager.sceneCountInBuildSettings)
            {
                if (levelIndex == mainMenuIndex)
                {
                    MainMenu.Open();
                }
                SceneManager.LoadScene(levelIndex);
            }
            else
            {
                Debug.LogWarning("LEVELLOADER LoadLevel Error: invalid scene specified!");
            }
        }

        public static void ReloadLevel()
        {
            LoadLevel(SceneManager.GetActiveScene().buildIndex);
        }

        public static void LoadNextLevel()
        {
            int totalSceneCount = SceneManager.sceneCountInBuildSettings;
            LoadLevel((SceneManager.GetActiveScene().buildIndex + 1) % totalSceneCount); ;
        }

        public static void LoadMainMenuLevel()
        {
            LoadLevel(mainMenuIndex);
        }
    }
}