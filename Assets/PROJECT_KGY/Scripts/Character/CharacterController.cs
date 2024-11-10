using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace KGY
{
    public class CharacterController : MonoBehaviour
    {
        public bool IsCleaning
        {
            get { return isCleaning; }
            set { isCleaning = value; }
        }

        private CharacterBase characterBase;
        private bool isCleaning;

        private void Awake()
        {
            characterBase = GetComponent<CharacterBase>();
        }

        private void Start()
        {
            KGYInputSystem.Singleton.onClean += Clean;
        }

        private void Update()
        {
            Vector2 input = KGYInputSystem.Singleton.moveInput;
            characterBase.Move(input);

            if (IsCleaning)
            {
                //클릭하는 방향으로 캐릭터 회전
                Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(mouseRay, out RaycastHit hitInfo, 1000f))
                {
                    Vector3 direction = hitInfo.point - transform.position;
                    Quaternion targetRot = Quaternion.LookRotation(direction);
                    targetRot.eulerAngles = new Vector3(0, targetRot.eulerAngles.y, 0);
                    transform.rotation = targetRot;
                }
            }
        }

        private void Clean(bool isClean)
        {
            characterBase.Clean(isClean);
            IsCleaning = isClean;
        }
    }
}
