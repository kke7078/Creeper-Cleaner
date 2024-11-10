using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KGY
{
    public class InteractionDoor : MonoBehaviour, IInteractable
    {
        public bool IsAutoInteract => false;
        public string Message => "문 열기";

        public Transform targetDoor;

        private bool isOpened;

        public void Interact(CharacterBase playerCharacter)
        {
            Debug.Log("문이 열렸습니다!");

            if(!isOpened)
            {
                isOpened = true;

                targetDoor.GetComponent<BoxCollider>().isTrigger = true;    //열린 문에 충돌하지 않게하기 위함
                targetDoor.Rotate(new Vector3(0, -90 , 0));
            }
        }
    }
}
