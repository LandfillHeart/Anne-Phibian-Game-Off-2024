using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ComputerDesktop : MonoBehaviour
    {
        public GameObject browserIcon;
        public GameObject fileIcon;
        public GameObject diskIcon;

        public HoverOutline computerHoverable;
        
        private void Start()
        {
            computerHoverable.gameObject.SetActive(false);
        }

        public void ToggleAllIcons(bool state)
        {
            browserIcon.SetActive(state);
            fileIcon.SetActive(state);
            diskIcon.SetActive(state);
        }
        
        
        
    }
}