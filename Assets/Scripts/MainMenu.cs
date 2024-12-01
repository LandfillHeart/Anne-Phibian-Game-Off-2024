using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class MainMenu : MonoBehaviour
    {
        private static MainMenu instance;
        public static MainMenu Instance => instance;
        
        public Transform mainMenuPanel;
        public Transform settingsPanel;
        public Transform creditsPanel;

        public bool allowMenuToggle;
        
        private bool inMenuNavigation;

        public bool GamePaused => mainMenuPanel.gameObject.activeSelf || settingsPanel.gameObject.activeSelf;
        
        private void Awake()
        {
            instance = this;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (inMenuNavigation)
                {
                    CloseAllPages();
                    return;
                }

                if (!allowMenuToggle)
                {
                    return;
                }
                
                switch (mainMenuPanel.gameObject.activeSelf)
                {
                    case true:
                        mainMenuPanel.gameObject.SetActive(false);
                        break;
                    case false:
                        mainMenuPanel.gameObject.SetActive(true);
                        break;
                }
                
            }
        }

        public void StartGame()
        {
            SceneManager.LoadScene("Scenes/Gameplay Desk");
        }

        public void GoToMainMenu()
        {  
            SceneManager.LoadScene("Scenes/Main Menu");
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void ToggleSettings(bool state)
        {
            settingsPanel.gameObject.SetActive(state);
            mainMenuPanel.gameObject.SetActive(!state);
            inMenuNavigation = state;
        }

        public void ToggleCredits(bool state)
        {
            mainMenuPanel.gameObject.SetActive(!state);
            creditsPanel.gameObject.SetActive(state);
            inMenuNavigation = state;
        }
        
        private void CloseAllPages()
        {
            ToggleSettings(false);
            if (!creditsPanel)
            {
                return;
            }
            ToggleCredits(false);
        }

        public void OpenGitHub()
        {
            Application.OpenURL("https://github.com/LandfillHeart");
        }

        public void OpenInstagram()
        {
            Application.OpenURL("https://www.instagram.com/froo.gss/");
        }

        public void OpenTypewriterAsset()
        {
            Application.OpenURL("https://www.1001fonts.com/breamcatcher-font.html");
        }

        public void OpenCommodoreAsset()
        {
            Application.OpenURL("https://jamiecross.itch.io/c-64-font-free");
        }
        
    }
}