using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;

public class InteractionManager : MonoBehaviour
{
    private static InteractionManager instance;

    public static InteractionManager Instance => instance;

    public Transform defaultCameraTransform;

    public Action<Interactable> RemoveInteractionState;
    public Action ForceRemoveInteractionState;
    
    private Camera sceneCamera;
    private bool interactionReady;

    private Transform outlineCache;
    
    private LayerMask interactableLayer;

    public float defaultFL = 150f;
    public float zoomFL = 35f;

    private Interactable latestInteractable = null;
    
    public bool InteractionReady
    {
        get => interactionReady;
        set => interactionReady = value;
    }

    private void Awake()
    {
        instance = this;
        interactableLayer = LayerMask.GetMask("Interactable");
        interactionReady = true;
    }

    void Start()
    {
        defaultCameraTransform.position = transform.position;
        sceneCamera = GetComponent<Camera>();
        sceneCamera.focalLength = defaultFL;
    }
    

    // we dont have that many inputs - we use late update so that it can check to open the dialogue after the ui manager already checked if we should close the dialogue
    private void LateUpdate()
    {
        if (MainMenu.Instance.GamePaused || ObjectCloseUpPanel.Instance.CloseUpPanelActive)
        {
            return;
        }
        
        if (Input.GetMouseButtonDown(1) && !ObjectCloseUpPanel.Instance.CloseUpPanelActive)
        {
            ForceRemoveInteractionState?.Invoke();
        }

        if (!interactionReady)
        {
            return;
        }

        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        Ray ray = sceneCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //Debug.DrawRay(ray.origin, ray.direction * 100f, Color.blue, 30f);
        if (!Physics.Raycast(ray, out hit, 100f, interactableLayer))
        {
            //ForceRemoveInteractionState?.Invoke();
            return;
        }

        latestInteractable = hit.transform.GetComponent<Interactable>();
        latestInteractable.InteractionStarted();
        
        if (!latestInteractable.preserveOtherInteractions)
        {
            RemoveInteractionState?.Invoke(latestInteractable);
        }
        
        
    }
    



}
