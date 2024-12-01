using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameEndTrigger : MonoBehaviour
    {
        private bool triggerEnabled = false;
        private bool triggerActivated;
        private bool triggerUsed;
        private Interactable interactable;
        private void Start()
        {
            GameplaySceneManager.Instance.SudokuPuzzleSolvedEvent += () => { triggerEnabled = true; };
            interactable = GetComponent<Interactable>();
            interactable.OnInteractStart += () =>
            {
                if (triggerEnabled)
                {
                    triggerActivated = true;
                }
            };
        }

        // silly little way to check when the dialogue has been closed, which will only happen when the last dialogue of the game has been played
        private void Update()
        {
            if (triggerUsed)
            {
                return;
            }
            
            if (!triggerEnabled || !triggerActivated)
            {
                return;
            }

            if (UIManager.Instance.CloseDialogueOnClick)
            {
                return;
            }

            triggerUsed = true;
            
            GameplaySceneManager.Instance.TriggerGameEnd();
            
        }
        
    }
}