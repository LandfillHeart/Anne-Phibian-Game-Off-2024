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
        if (MainMenu.Instance.GamePaused)
        {
            return;
        }
        
        if (Input.GetMouseButtonDown(1))
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
        
        RemoveInteractionState?.Invoke(latestInteractable);
        latestInteractable.InteractionStarted();
    }

    public void ZoomToPosition(Vector3 endPosition, bool toDefaultPos)
    {
        StartCoroutine(ZoomCoroutine(endPosition, toDefaultPos));
    }

    private IEnumerator ZoomCoroutine(Vector3 position, bool toDefaultPos)
    {
        float elapsedTime = 0f;
        float zoomDuration = 0.4f;

        Vector3 endPosition;
        Vector3 startPosition;
        
        float startingFL = 0f;
        float targetFL = 0f;
        
        switch (toDefaultPos)
        {
            case true:
                endPosition = defaultCameraTransform.position;
                startPosition = position;
                startingFL = zoomFL;
                targetFL = defaultFL;
                break;
            case false:
                endPosition = position;
                startPosition = defaultCameraTransform.position;
                startingFL = defaultFL;
                targetFL = zoomFL;
                break;
        }

        while (elapsedTime <= zoomDuration)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / zoomDuration);
            sceneCamera.focalLength = Mathf.Lerp(startingFL, targetFL, elapsedTime / zoomDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
    }

    public void DollyZoom(Vector3 interactablePos, Vector3 endPosition)
    {
        sceneCamera.transform.LookAt(interactablePos);
        float tanHalfFOV = 5 / (interactablePos - endPosition).magnitude;
        float halfFOV = Mathf.Pow(tanHalfFOV, -1);
        sceneCamera.fieldOfView = halfFOV * 2;
        sceneCamera.transform.position = endPosition;
        
    }



}
