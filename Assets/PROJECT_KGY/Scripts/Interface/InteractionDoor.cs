using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KGY
{
    public class InteractionDoor : MonoBehaviour, IInteractable
    {
        public bool IsAutoInteract => false;
        public string Message => "�� ����";

        public Transform targetDoor;

        private bool isOpened;

        public void Interact(CharacterBase playerCharacter)
        {
            Debug.Log("���� ���Ƚ��ϴ�!");

            if(!isOpened)
            {
                isOpened = true;

                targetDoor.GetComponent<BoxCollider>().isTrigger = true;    //���� ���� �浹���� �ʰ��ϱ� ����
                targetDoor.Rotate(new Vector3(0, -90 , 0));
            }
        }
    }
}
