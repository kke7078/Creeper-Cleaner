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
        public GameObject waterSpray;
        private CharacterBase characterBase;

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
        }
        private void Clean(bool isClean)
        {
            Debug.Log(isClean);

            if (isClean)
            {
                characterBase.moveSpeed = 3f;   //캐릭터 이동속도 감소
                waterSpray.SetActive(true);     //물뿌리기 이펙트 show

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
            else
            {
                characterBase.moveSpeed = 5f;   //캐릭터 이동속도 원복
                waterSpray.SetActive(false);     //물뿌리기 이펙트 hide
            }
        }
    }
}
