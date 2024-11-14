using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ObjectInspection : MonoBehaviour
    {
        public Interactable interactable;

        public Sprite objectSprite;
        
        private void Start()
        {
            interactable.OnInteractStart += () => { ToggleInteraction(true); };
            //interactable.OnInteractRepeated += () => { ToggleInteraction(true); };
            //interactable.OnInteractForcedEnd += () => { ToggleInteraction(false); };
        }

        private void ToggleInteraction(bool state)
        {
            if (state)
            {
                ObjectCloseUpPanel.Instance.SetCloseUpContent(objectSprite);
                interactable.interactionActive = false;
                return;
            }
            
            ObjectCloseUpPanel.Instance.ToggleCloseUp(false);
            
        }
        
    }
}