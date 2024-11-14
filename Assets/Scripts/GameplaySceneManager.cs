using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameplaySceneManager : MonoBehaviour
    {
        public string[] gameStartDialogues;

        private void Start()
        {
            InteractionManager.Instance.InteractionReady = false;
            StartCoroutine(MultipleDialogues(gameStartDialogues));
        }

        private IEnumerator MultipleDialogues(string[] dialoguesReference)
        {
            for (int i = 0; i < dialoguesReference.Length; i++)
            {
                UIManager.Instance.SetDialogueBoxContent(dialoguesReference[i], CharacterReference.Instance.detective);
                while (UIManager.Instance.CloseDialogueOnClick)
                {
                    yield return null;
                }

            }
            
        }
        
    }
}