using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class MainMenu : MonoBehaviour
    {
        public Transform mainMenuPanel;
        public Transform settingsPanel;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                CloseAllPages();
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

        public void ToggleSettings(bool state)
        {
            settingsPanel.gameObject.SetActive(state);
            mainMenuPanel.gameObject.SetActive(!state);
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