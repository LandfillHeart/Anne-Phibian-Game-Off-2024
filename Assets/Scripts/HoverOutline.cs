using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    public class HoverOutline : MonoBehaviour
    {
        public SpriteRenderer hoverRenderer;
        
        void OnMouseEnter()
        {
            hoverRenderer.enabled = true;
        }

        void OnMouseExit()
        {
            hoverRenderer.enabled = false;
        }
    }
}