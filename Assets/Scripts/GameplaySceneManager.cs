using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class GameplaySceneManager : MonoBehaviour
    {
        private static GameplaySceneManager instance;
        public static GameplaySceneManager Instance => instance;
        
        public string[] gameStartDialogues;
        public string[] sudokuSolvedDetectiveDialogues;
        public string[] sudokuSolvedAssistantDialogues;
        
        public Image startingCutsceneImage;
        public Image endingCutsceneImage;
        public Image cutsceneBgImage;
        public TextMeshProUGUI cutsceneText;

        public Action SudokuPuzzleBeaten;
        
        public float fadeDuration = 3f;
        private float elapsedTime;

        private Color colorCache;
        private Color bgColorCache;
        
        private void Start()
        {
            instance = this;
            InteractionManager.Instance.InteractionReady = false;
            colorCache = new Color();
            bgColorCache = new Color();
            //colorCache = cutsceneImage.color;
            bgColorCache = cutsceneBgImage.color;
            colorCache.a = 0f;
            StartCoroutine(StartingCutscene());
        }

        // to use with buttons in game
        public void MoveGameCamera(Vector3 endPosition)
        {
            Camera.main.transform.position = endPosition;
        }

        public void SudokuPuzzleSolved()
        {
            StartCoroutine(SudokuDialogues());
            SudokuPuzzleBeaten?.Invoke();
        }
        
        private IEnumerator SudokuDialogues()
        {
            yield return StartCoroutine(MultipleDialogues(sudokuSolvedDetectiveDialogues, CharacterReference.Instance.detective));
            yield return StartCoroutine(MultipleDialogues(sudokuSolvedAssistantDialogues, CharacterReference.Instance.assistant));

        }

        private IEnumerator StartingCutscene()
        {
            yield return StartCoroutine(SimpleCutscene(startingCutsceneImage));
            yield return StartCoroutine(MultipleDialogues(gameStartDialogues, CharacterReference.Instance.detective));
        }

        private IEnumerator EndingCutscene()
        {
            yield return StartCoroutine(SimpleCutscene(endingCutsceneImage));
            SceneManager.LoadScene("Main Menu");
        }

        private IEnumerator SimpleCutscene(Image cutsceneImage)
        {
            InteractionManager.Instance.InteractionReady = false;
            elapsedTime = 0f;
            colorCache = cutsceneImage.color;
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

            
            


        }
        
        private IEnumerator MultipleDialogues(string[] dialoguesReference, CharacterData speaker)
        {
            for (int i = 0; i < dialoguesReference.Length; i++)
            {
                UIManager.Instance.SetDialogueBoxContent(dialoguesReference[i], speaker);
                while (UIManager.Instance.CloseDialogueOnClick)
                {
                    yield return null;
                }

            }
            
        }

    }
}