using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class SudokuPuzzle : MonoBehaviour
    {
        public GameObject gridRed;
        public GameObject gridGreen;
        public GameObject gridBlue;

        public SudokuTile[] allTiles = new SudokuTile[]{};
        
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
            
        }

        public void ChangeState(PuzzleState newState)
        {
            currentState = newState;

            switch (currentState)
            {
                case PuzzleState.Red:
                    gridRed.SetActive(true);
                    gridBlue.SetActive(false);
                    gridGreen.SetActive(false);
                    break;
                case PuzzleState.Green:
                    gridRed.SetActive(false);
                    gridBlue.SetActive(false);
                    gridGreen.SetActive(true);
                    break;
                case PuzzleState.Blue:
                    gridRed.SetActive(false);
                    gridBlue.SetActive(true);
                    gridGreen.SetActive(false);
                    break;
            }
            
            
            
        }

        public void CheckSolution()
        {
            for (int i = 0; i < allTiles.Length; i++)
            {
                if (!allTiles[i].CorrectState)
                {
                    Debug.Log("At least one tile is wrong");
                    return; // show the solution was wrong
                }
            }

            puzzleComplete = true;
            Debug.Log("All in correct state");

        }
        
        
        public enum PuzzleState
        {
            Red,
            Green,
            Blue
        }
        
    }
}