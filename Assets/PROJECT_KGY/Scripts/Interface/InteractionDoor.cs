using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KGY
{
    public class InteractionDoor : MonoBehaviour, IInteractable
    {
        public bool IsAutoInteract => false;
        public string Message => "�� ����";

        public GameObject targetDoor;

        private bool isOpened;

        public void Interact(CharacterBase playerCharacter)
        {
            Debug.Log("���� ���Ƚ��ϴ�!");
        }
    }
}
