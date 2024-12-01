using System;
using UnityEngine;

namespace DefaultNamespace
{
    // changes contents of dialogue from click after the sudoku puzzle is complete
    public class SudokuEventSubscriber : MonoBehaviour
    {
        private DialogueCreator dialogueCreator;
        private bool multipleDialogues;

        public string newDialogue;
        public CharacterData speakingCharacter;
        
        private void Start()
        {
            dialogueCreator = GetComponent<DialogueCreator>();
            GameplaySceneManager.Instance.SudokuPuzzleSolvedEvent += UpdateDialogue;
        }

        private void UpdateDialogue()
        {
            dialogueCreator.dialogueContent = newDialogue;
            dialogueCreator.speakingCharacter = speakingCharacter;
        }
        
    } 
    
}