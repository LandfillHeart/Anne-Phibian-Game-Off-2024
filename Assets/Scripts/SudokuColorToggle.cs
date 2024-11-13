using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class SudokuColorToggle : MonoBehaviour
    {
        public SudokuPuzzle puzzle;
        public SudokuPuzzle.PuzzleState stateToSet;
        public bool checkCompletion;
        private Interactable interactable;

        private void Start()
        {
            interactable = GetComponent<Interactable>();
            interactable.OnInteractStart += SetState;
            //interactable.OnInteractRepeated += SetState;
        }

        private void SetState()
        {
            if (checkCompletion)
            {
                puzzle.CheckSolution();
                return;
            }
            puzzle.ChangeState(stateToSet);
        }
        
    }
}