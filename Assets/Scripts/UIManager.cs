using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class UIManager : MonoBehaviour
    {
        private static UIManager instance;
        public static UIManager Instance => instance;
        
        public GameObject dialogueBoxPanel;
        public DialogueBox dialogueBox;

        private bool closeDialogueOnClick;

        public bool CloseDialogueOnClick
        {
            get => closeDialogueOnClick;
            set => closeDialogueOnClick = value;
        }
        
        private void Awake()
        {
            instance = this;
        }

        private void Update()
        {
            // on click, close the dialogue box
            if (!closeDialogueOnClick)
            {
                return;
            }

            if (MainMenu.Instance.GamePaused)
            {
                return;
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                ToggleDialogueBox(false);
                InteractionManager.Instance.InteractionReady = true;
                closeDialogueOnClick = false;
            }
        }

      
        public void ToggleDialogueBox(bool state)
        {
            dialogueBoxPanel.SetActive(state);
        }

        public void SetDialogueBoxContent(string content, CharacterData characterData)
        {
            if (!dialogueBoxPanel.activeSelf)
            {
                ToggleDialogueBox(true);
            }

            InteractionManager.Instance.InteractionReady = false;
            dialogueBox.SetContent(content, characterData);
            closeDialogueOnClick = true;
        }
        
        
    }
}