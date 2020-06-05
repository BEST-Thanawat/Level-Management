using SampleGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement
{
    [RequireComponent(typeof(Canvas))]
    public class Menu : MonoBehaviour
    {
        private GameManager gameManager;
        private MenuManager menuManager;
        private void Awake()
        {
            gameManager = FindObjectOfType<GameManager>();
            if (gameManager == null) Debug.LogError("GameManager is null");

            menuManager = FindObjectOfType<MenuManager>();
            if (menuManager == null) Debug.LogError("MenuManager is null");
        }
        public void OnPlayPressed()
        {
            gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null) gameManager.LoadNextLevel();
        }
        public void OnSettingsPressed()
        {
            Menu settingsMenu = transform.parent.Find("SettingsMenu(Clone)").GetComponent<Menu>();
            if (menuManager != null && settingsMenu != null)
            {
                menuManager.OpenMenu(settingsMenu);
            }
        }

        public void OnCreditsPressed()
        {
            Menu creditsMenu = transform.parent.Find("CreditsMenu(Clone)").GetComponent<Menu>();
            if (menuManager != null && creditsMenu != null)
            {
                menuManager.OpenMenu(creditsMenu);
            }
        }

        public void OnBackPressed()
        {
            if (menuManager != null)
            {
                menuManager.CloseMenu();
            }
        }
    }
}

