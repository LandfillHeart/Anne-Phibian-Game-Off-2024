using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ComputerDesktop : MonoBehaviour
    {
        public GameObject browserIcon;
        public GameObject diskIcon;

        public HoverOutline computerHoverable;
        
        private void Start()
        {
            computerHoverable.gameObject.SetActive(false);
        }

        public void ToggleAllIcons(bool state)
        {
            browserIcon.SetActive(state);
            diskIcon.SetActive(state);
        }
        
        
        
    }
}