using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Interactable : MonoBehaviour
{
    public bool interactionActive;

    public bool preserveOtherInteractions;
    
    public Action OnInteractStart;
    public Action OnInteractEnd;
    public Action OnInteractRepeated;
    public Action OnInteractForcedEnd; // need this for desktop to get out of apps only when right clicking
    
    void Start()
    {
        InteractionManager.Instance.RemoveInteractionState += InteractionCleared;
        InteractionManager.Instance.ForceRemoveInteractionState += InteractionCleared;
    }

    public void InteractionStarted()
    {
        if (interactionActive)
        {
            return;
        }
        interactionActive = true;
        OnInteractStart?.Invoke();
        //InteractionManager.Instance.InteractionReady = false;
    }

    public void InteractionCleared(Interactable latestInteractable)
    {
        if (interactionActive && this == latestInteractable)
        {
            OnInteractRepeated?.Invoke();
            return;
        }
        
        if (!interactionActive || this == latestInteractable)
        {
            return;
        }

        interactionActive = false;
        OnInteractEnd?.Invoke();
        //InteractionManager.Instance.InteractionReady = true;
    }

    public void InteractionCleared()
    {
        if (!interactionActive)
        {
            return;
        }

        interactionActive = false;
        OnInteractForcedEnd?.Invoke();
        OnInteractEnd?.Invoke();

    }
    
}
