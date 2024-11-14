using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class DesktopNavigation : MonoBehaviour
    {
        public ComputerDesktop desktop;
        
        public GameObject deepNavigation;

        private Interactable interactable;

        private void Start()
        {
            interactable = GetComponent<Interactable>();
            interactable.OnInteractStart += () => { ToggleBrowser(true); };
            InteractionManager.Instance.ForceRemoveInteractionState += () => { ToggleBrowser(false); };
        }

        private void ToggleBrowser(bool state)
        {
            if (!state && !deepNavigation.activeSelf)
            {
                return;
            }
            
            deepNavigation.SetActive(state);
            desktop.ToggleAllIcons(!state);
        }
        
    }
}