using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ZoomOnInteract : MonoBehaviour
    {
        public Transform zoomPosition;
        private Interactable interactable;

        private void Start()
        {
            interactable = GetComponent<Interactable>();
            interactable.OnInteractStart += () =>
            {
                InteractionManager.Instance.ZoomToPosition(zoomPosition.position, toDefaultPos: false);
            };
        }
        
        
        
    }
}