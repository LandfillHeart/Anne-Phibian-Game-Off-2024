using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class MainMenu : MonoBehaviour
    {
        public Transform mainMenuPanel;
        public Transform settingsPanel;

        public bool allowMenuToggle;
        
        private bool inMenuNavigation;
        
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

        private void ToggleCredits(bool state)
        {
            //CloseAllPages();
        }
        
        private void CloseAllPages()
        {
            ToggleSettings(false);
            ToggleCredits(false);
        }
        
    }
}