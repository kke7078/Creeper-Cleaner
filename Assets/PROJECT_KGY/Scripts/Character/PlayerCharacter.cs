using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

namespace KGY
{
    public class PlayerCharacter : CharacterBase
    {
        public System.Action<CleanerRoom> OnCleanerRoomEntered;
        public System.Action OnCleanerRoomExited;

        private CleanerRoomSensor cleanerRoomSensor;
        private InteractionSensor interactionSensor;
        private List<IInteractable> currentInteractionItems = new List<IInteractable>();

        protected override void Awake()
        {
            base.Awake();

            cleanerRoomSensor = GetComponentInChildren<CleanerRoomSensor>();
            cleanerRoomSensor.OnEnterCleanerRoom += (CleanerRoom roomData) => OnCleanerRoomEntered?.Invoke(roomData);
            cleanerRoomSensor.OnExitCleanerRoom += (CleanerRoom roomData) => OnCleanerRoomExited?.Invoke();

            interactionSensor = GetComponentInChildren<InteractionSensor>();
            interactionSensor.OnDetected += OnDetectedInteraction;
            interactionSensor.OnLostSignal += OnLostInteraction;
        }

        public void Interact()
        {
            if (currentInteractionItems.Count <= 0) return;

            currentInteractionItems[0].Interact(this);
            currentInteractionItems.RemoveAt(0);
        }
        
        private void OnDetectedInteraction(IInteractable interactable)
        {
            if (interactable.IsAutoInteract == true) interactable.Interact(this);
            else
            {
                currentInteractionItems.Add(interactable);
            }
        }

        private void OnLostInteraction(IInteractable interactable)
        {
            currentInteractionItems.Remove(interactable);
        }
    }
}
