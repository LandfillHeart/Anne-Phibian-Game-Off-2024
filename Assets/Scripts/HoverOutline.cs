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
            if (ObjectCloseUpPanel.Instance.CloseUpPanelActive || !InteractionManager.Instance.InteractionReady || MainMenu.Instance.GamePaused )
            {
                return;
            }
            hoverRenderer.enabled = true;
        }

        void OnMouseExit()
        {
            hoverRenderer.enabled = false;
        }
    }
}