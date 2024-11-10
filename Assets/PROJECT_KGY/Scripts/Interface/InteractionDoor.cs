using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KGY
{
    public class InteractionDoor : MonoBehaviour, IInteractable
    {
        public bool IsAutoInteract => false;
        public string Message => "문 열기";

        public GameObject targetDoor;

        private bool isOpened;

        public void Interact(CharacterBase playerCharacter)
        {
            Debug.Log("문이 열렸습니다!");
        }
    }
}
