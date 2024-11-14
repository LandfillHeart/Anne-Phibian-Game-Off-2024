using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class PasswordPuzzle : MonoBehaviour
    {
        private Interactable interactable;

        public TMP_InputField inputField;

        public TextMeshProUGUI readonlyContent;

        public SpriteRenderer screenOnSprite;

        public ComputerDesktop desktopPuzzle;
        
        public string expectedPassword;

        private bool puzzleCompleted;

        private bool fadeComplete = true;
        private Color colorCache;

        private bool firstInteraction = true;
        
        private void Start()
        {
            interactable = GetComponent<Interactable>();
            interactable.OnInteractStart += StartReadingInput;
            interactable.OnInteractEnd += StopReadingInput;
            interactable.OnInteractRepeated += () => { if(fadeComplete) inputField.ActivateInputField(); };
            colorCache = screenOnSprite.color;
            colorCache.a = 0f;
            screenOnSprite.color = colorCache;
        }

        private void OnDisable()
        {
            interactable.OnInteractStart -= StartReadingInput;
            interactable.OnInteractEnd -= StopReadingInput;
            interactable.OnInteractRepeated -= () => { if(fadeComplete) inputField.ActivateInputField(); };

        }

        private void Update()
        {
            if (puzzleCompleted)
            {
                return;
            }
            
            if (inputField.text != expectedPassword)
            {
                return;
            }

            puzzleCompleted = true;
            CompletePuzzle();
            
        }

        // this isn't needed now that i added the OnInputRepeated action
        /*
        private void LateUpdate()
        {
            if (puzzleCompleted)
            {
                return;
            }

            if (interactable.interactionActive && fadeComplete)
            {
                inputField.ActivateInputField();
            }
            
        }*/

        private void StartReadingInput()
        {
            if (!fadeComplete)
            {
                return;
            }

            StartCoroutine(FadeScreen(true));
        }

        private void StopReadingInput()
        {
            if (!fadeComplete)
            {
                return;
            }
            
            StartCoroutine(FadeScreen(false));
        }

        private void CompletePuzzle()
        {
            //StopReadingInput();
            inputField.DeactivateInputField();
            screenOnSprite.enabled = true;
            inputField.gameObject.SetActive(false);
            desktopPuzzle.gameObject.SetActive(true);
            readonlyContent.enabled = false;
            this.enabled = false;
        }

        private IEnumerator FadeScreen(bool fadeIn)
        {
            switch (fadeIn)
            {
                case true when !interactable.interactionActive:
                    yield break;
                case false when interactable.interactionActive:
                    yield break;
            }
            fadeComplete = false;
            float elapsedTime = 0f;
            float duration = 0.5f;
            float targetAlpha = fadeIn ? 1f : 0f;
            float startingAlpha = fadeIn ? 0f : 1f;
            if (!fadeIn)
            {
                readonlyContent.enabled = fadeIn;
                inputField.DeactivateInputField();
                inputField.gameObject.SetActive(false);
            }
            
            while (elapsedTime <= duration)
            {
                colorCache.a = Mathf.Lerp(startingAlpha, targetAlpha, elapsedTime / duration);
                screenOnSprite.color = colorCache;
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            colorCache.a = targetAlpha;
            screenOnSprite.color = colorCache;
            fadeComplete = true;
            
            if (fadeIn)
            {
                readonlyContent.enabled = fadeIn;
                inputField.gameObject.SetActive(true);
                inputField.text = "";
                inputField.ActivateInputField();
            }

            if (firstInteraction)
            {
                UIManager.Instance.SetDialogueBoxContent("Needs a password. Maybe I can find something useful by nosing around", CharacterReference.Instance.detective);
                firstInteraction = false;
            }
            
        }
        
    }
}