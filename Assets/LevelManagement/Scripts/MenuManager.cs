using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement
{
    public class MenuManager : MonoBehaviour
    {
        public MainMenu mainMenuPrefab;
        public SettingsMenu settingsMenuPrefab;
        public CreditsScreen creditsScreenPrefab;
        public GameMenu gameMenuPrefab;
        public PauseMenu pauseMenuPrefab;

        [SerializeField]
        private Transform _menuParent;
        private Stack<Menu> _menuStack = new Stack<Menu>();

        private static MenuManager _instance;
        public static MenuManager Instance { get => _instance; }

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
                InitializedMenu();
                DontDestroyOnLoad(gameObject);
            }
        }
        private void OnDestroy()
        {
            if (_instance == this) _instance = null;
        }
        private void InitializedMenu()
        {
            if (_menuParent == null)
            {
                GameObject menuParentObject = new GameObject("Menus");
                _menuParent = menuParentObject.transform;
            }
            DontDestroyOnLoad(_menuParent.gameObject);

            Menu[] menuPrefabs = { mainMenuPrefab, settingsMenuPrefab, creditsScreenPrefab, gameMenuPrefab, pauseMenuPrefab };
            foreach(Menu prefab in menuPrefabs)
            {
                if (prefab != null)
                {
                    Menu menuInstance = Instantiate(prefab, _menuParent);
                    if(prefab  != mainMenuPrefab)
                    {
                        menuInstance.gameObject.SetActive(false);
                    }
                    else
                    {
                        OpenMenu(menuInstance);
                    }
                }
            }
        }

        public void OpenMenu(Menu menuInstance)
        {
            if (menuInstance == null) Debug.LogWarning("MenuManager OpenMenu ERROR: invalid menu");
            
            if(_menuStack.Count > 0)
            {
                foreach (Menu menu in _menuStack)
                {
                    menu.gameObject.SetActive(false);
                }
            }

            menuInstance.gameObject.SetActive(true);
            _menuStack.Push(menuInstance);
        }

        public void CloseMenu()
        {
            if (_menuStack.Count == 0)
            {
                Debug.LogWarning("MenuManager CLoseMenu ERROR No menus in stack");
                return;
            }

            Menu topMenu = _menuStack.Pop();
            topMenu.gameObject.SetActive(false);

            if (_menuStack.Count > 0)
            {
                Menu nextMenu = _menuStack.Peek();
                nextMenu.gameObject.SetActive(true);
            }
        }
    }
}