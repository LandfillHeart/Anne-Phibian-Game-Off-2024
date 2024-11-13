using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class BrowserToggle : MonoBehaviour
    {
        public ComputerDesktop desktop;
        
        public GameObject browserWindow;

        private Interactable interactable;

        private void Start()
        {
            interactable = GetComponent<Interactable>();
            interactable.OnInteractStart += () => { ToggleBrowser(true); };
            InteractionManager.Instance.ForceRemoveInteractionState += () => { ToggleBrowser(false); };
        }

        private void ToggleBrowser(bool state)
        {
            if (!state && !browserWindow.activeSelf)
            {
                return;
            }
            
            browserWindow.SetActive(state);
            desktop.ToggleAllIcons(!state);
        }
        
    }
}