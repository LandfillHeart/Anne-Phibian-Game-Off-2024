using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class SudokuTile : MonoBehaviour
    {
        private Interactable interactable;

        private bool tileActive;

        public bool solutionRequiresActive;
        
        public SpriteRenderer tileSprite;

        public bool CorrectState => solutionRequiresActive ? tileActive : !tileActive;
        
        private void Start()
        {
            interactable = GetComponent<Interactable>();
            //interactable.OnInteractStart += ToggleTileState;
            interactable.OnInteractRepeated += ToggleTileState;
            tileActive = false;
            tileSprite.enabled = false;
        }

        private void ToggleTileState()
        {
            tileActive = !tileActive;
            tileSprite.enabled = tileActive;
        }
        
        
        
    }
}