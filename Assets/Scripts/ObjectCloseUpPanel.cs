using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ObjectCloseUpPanel : MonoBehaviour
    {
        private static ObjectCloseUpPanel instance;
        public static ObjectCloseUpPanel Instance => instance;

        public SpriteRenderer backgroundBlur;
        public SpriteRenderer closeUpObject;

        public bool CloseUpPanelActive;
        
        private void Awake()
        {
            instance = this;
        }

        private void LateUpdate()
        {
            if (!CloseUpPanelActive)
            {
                return;
            }

            if (MainMenu.Instance.GamePaused)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                ToggleCloseUp(false);
            }
        }

        public void SetCloseUpContent(Sprite closeUpSprite)
        {
            closeUpObject.sprite = closeUpSprite;
            ToggleCloseUp(true);
        }
        
        public void ToggleCloseUp(bool state)
        {
            backgroundBlur.enabled = state;
            closeUpObject.enabled = state;
            CloseUpPanelActive = state;
        }


    }
}