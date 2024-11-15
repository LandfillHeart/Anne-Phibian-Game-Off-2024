using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class GameplaySceneManager : MonoBehaviour
    {
        public string[] gameStartDialogues;

        public Image cutsceneImage;
        public Image cutsceneBgImage;
        public TextMeshProUGUI cutsceneText; 

        public float fadeDuration = 3f;
        private float elapsedTime;

        private Color colorCache;
        private Color bgColorCache;
        
        private void Start()
        {
            InteractionManager.Instance.InteractionReady = false;
            colorCache = new Color();
            bgColorCache = new Color();
            colorCache = cutsceneImage.color;
            bgColorCache = cutsceneBgImage.color;
            colorCache.a = 0f;
            StartCoroutine(StartingCutscene());
        }

        private IEnumerator StartingCutscene()
        {
            InteractionManager.Instance.InteractionReady = false;
            elapsedTime = 0f;

            while (elapsedTime <= fadeDuration)
            {
                cutsceneImage.color = colorCache;
                cutsceneText.color = colorCache;
                colorCache.a = Mathf.Lerp(0, 1, elapsedTime / fadeDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            while (!Input.GetMouseButtonDown(0) || MainMenu.Instance.GamePaused)
            {
                yield return null;
            }

            elapsedTime = 0f;
            while (elapsedTime <= fadeDuration)
            {
                cutsceneImage.color = colorCache;
                cutsceneText.color = colorCache;
                cutsceneBgImage.color = bgColorCache;
                colorCache.a = Mathf.Lerp(1, 0, elapsedTime / fadeDuration);
                bgColorCache.a = colorCache.a;
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            cutsceneImage.enabled = false;
            cutsceneText.enabled = false;
            cutsceneBgImage.enabled = false;

            
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