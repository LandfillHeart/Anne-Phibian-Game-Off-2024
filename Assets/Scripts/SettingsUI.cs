using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class SettingsUI : MonoBehaviour
    {
        public Slider musicSlider;
        public Slider sfxSlider;
        public TextMeshProUGUI musicVolumeDisplay;
        public TextMeshProUGUI sfxVolumeDisplay;

        public GameObject controlsParent;
        public GameObject audioParent;

        public MainMenu mainMenu;
        
        private void Start()
        {
            
            musicSlider.onValueChanged.AddListener(delegate { UpdateFields(); });
            sfxSlider.onValueChanged.AddListener(delegate { UpdateFields(); });

            musicSlider.value = 100f;
            sfxSlider.value = 100f;

        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                mainMenu.ToggleSettings(false);
            }
        }

        private void UpdateFields()
        {
            musicVolumeDisplay.text = musicSlider.value.ToString();
            sfxVolumeDisplay.text = sfxSlider.value.ToString();
            AudioManager.Instance.ChangeAudioSettings(musicSlider.value, sfxSlider.value);
        }

        private void OnEnable()
        {
            OpenControls();
        }
 
        public void OpenControls()
        {
            controlsParent.SetActive(true);
            audioParent.SetActive(false);
        }

        public void OpenAudio()
        {
            audioParent.SetActive(true);
            controlsParent.SetActive(false);
        }
        
        
    }
}