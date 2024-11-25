using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class CameraNavigationButton : MonoBehaviour
    {
        public Transform navigationPosition;

        private Interactable interactable;

        private void Start()
        {
            interactable = GetComponent<Interactable>();
            interactable.OnInteractStart += MoveCamera;
        }

        private void MoveCamera()
        {
            GameplaySceneManager.Instance.MoveGameCamera(navigationPosition.position);
        }
        
    }
}