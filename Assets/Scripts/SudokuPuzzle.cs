using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class SudokuPuzzle : MonoBehaviour
    {
        public GameObject gridRed;
        public GameObject gridGreen;
        public GameObject gridBlue;

        public SudokuColorToggle[] colorToggles;
        
        public SudokuTile[] allTiles = new SudokuTile[]{};

        public TextMeshProUGUI sudokuTextContent;
        public TextMeshProUGUI sudokuSolutionStateText;

        private PuzzleState currentState;

        private bool puzzleComplete;

        /*
        private readonly PuzzleState[] expectedSolution = new[]
        {
            PuzzleState.Red, PuzzleState.Blue, PuzzleState.Green,
            PuzzleState.Blue, PuzzleState.Green, PuzzleState.Red,
            PuzzleState.Green, PuzzleState.Red, PuzzleState.Blue
        };*/

        private void Start()
        {
            allTiles = GetComponentsInChildren<SudokuTile>(true);
        }


        private void OnEnable()
        {
            ChangeState(PuzzleState.Red);
            sudokuTextContent.enabled = true;
        }

        private void OnDisable()
        {
            sudokuTextContent.enabled = false;
        }

        public void ChangeState(PuzzleState newState)
        {
            currentState = newState;

            switch (currentState)
            {
                case PuzzleState.Red:
                    sudokuTextContent.color = Color.red;
                    gridRed.SetActive(true);
                    gridBlue.SetActive(false);
                    gridGreen.SetActive(false);
                    break;
                case PuzzleState.Green:
                    sudokuTextContent.color = Color.green;
                    gridRed.SetActive(false);
                    gridBlue.SetActive(false);
                    gridGreen.SetActive(true);
                    break;
                case PuzzleState.Blue:
                    sudokuTextContent.color = Color.blue;
                    gridRed.SetActive(false);
                    gridBlue.SetActive(true);
                    gridGreen.SetActive(false);
                    break;
            }
            
            
            
        }

        public void CheckSolution()
        {
            bool isSolved = true;
            for (int i = 0; i < allTiles.Length; i++)
            {
                if (!allTiles[i].CorrectState)
                {
                    isSolved = false;
                    break;
                }
            }

            StartCoroutine(AnimatedSudoku(isSolved));
            

        }

        // Hopefully gives the player some feedback on what they're trying to do
        private IEnumerator AnimatedSudoku(bool solved)
        {
            foreach (var colorToggle in colorToggles)
            {
                colorToggle.gameObject.SetActive(false);
            }
            
            ChangeState(PuzzleState.Red);
            yield return new WaitForSeconds(0.75f);
            ChangeState(PuzzleState.Green);
            yield return new WaitForSeconds(0.75f);
            ChangeState(PuzzleState.Blue);
            yield return new WaitForSeconds(0.75f);

            sudokuTextContent.enabled = false;
            
            if (solved)
            {
                
                sudokuSolutionStateText.color = Color.green;
                sudokuSolutionStateText.text = "CORRECT";
                sudokuSolutionStateText.enabled = true;
                yield return new WaitForSeconds(0.75f);
                GameplaySceneManager.Instance.SudokuPuzzleSolved();
                yield break;
            }
            
            sudokuSolutionStateText.color = Color.red;
            sudokuSolutionStateText.text = "WRONG";
            sudokuSolutionStateText.enabled = true;
            yield return new WaitForSeconds(0.75f);
            sudokuTextContent.enabled = true;
            sudokuSolutionStateText.enabled = false;
            
            foreach (var colorToggle in colorToggles)
            {
                colorToggle.gameObject.SetActive(true);
            }
            
        }
        
        
        public enum PuzzleState
        {
            Red,
            Green,
            Blue
        }
        
    }
}