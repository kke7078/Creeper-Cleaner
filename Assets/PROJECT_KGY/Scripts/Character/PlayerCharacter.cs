using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KGY
{
    public class PlayerCharacter : CharacterBase
    {
        private InteractionSensor interactionSensor;
        private List<IInteractable> currentInteractionItems = new List<IInteractable>();

        protected override void Awake()
        {
            base.Awake();

            interactionSensor = GetComponentInChildren<InteractionSensor>();
            interactionSensor.OnDetected += OnDetectedInteraction;
            interactionSensor.OnLostSignal += OnLostInteraction;
        }

        public void Interact()
        {
            Debug.Log("Interact Start");
            //if (currentInteractionItems.Count <= 0) return;

            ////TEST
            //currentInteractionItems[0].Interact(this);
            //currentInteractionItems.RemoveAt(0);
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
