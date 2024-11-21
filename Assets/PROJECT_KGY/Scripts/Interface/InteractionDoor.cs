using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KGY
{
    public class InteractionDoor : MonoBehaviour, IInteractable
    {
        public bool IsAutoInteract {
            get { return isAutoInteract; }
            set { isAutoInteract = value; }
        }
        
        public bool isAutoInteract = false;

        public string Message => "�� ����";

        public Transform targetDoor;

        private bool isOpened;

        public void Interact(CharacterBase playerCharacter)
        {
            if(!isOpened)
            {
                isOpened = true;

                targetDoor.GetComponent<BoxCollider>().isTrigger = true;    //���� ���� �浹���� �ʰ��ϱ� ����
                targetDoor.Rotate(new Vector3(0, -90 , 0));
            }
        }
    }
}
