using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class DialogueCreator : MonoBehaviour
    {
        public Interactable interactable;

        public CharacterData speakingCharacter;
        
        [TextArea(10, 10)]
        public string dialogueContent;

        private void Start()
        {
            interactable = GetComponent<Interactable>();
            interactable.OnInteractStart += ShowDialogue;
        }

        private void ShowDialogue()
        {
            UIManager.Instance.SetDialogueBoxContent(dialogueContent, speakingCharacter);
        }
        
    }
}