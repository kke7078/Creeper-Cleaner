using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KGY
{
    public class InputSystem : MonoBehaviour
    {
        public static InputSystem Instance;

        public CharacterController playerCharacter;

        public bool isShoot;

        private void Awake()
        {
            Instance = this;
        }

        private void LateUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            { 
                isShoot = true;
                playerCharacter.moveSpeed = 3f;
            }

            if (Input.GetMouseButtonUp(0))
            {
                isShoot = false;
                playerCharacter.moveSpeed = 5f;
            }

            if (Input.GetMouseButton(0))
            {
                //클릭하는 방향으로 캐릭터 회전
                Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(mouseRay, out RaycastHit hitInfo, 1000f))
                {
                    Vector3 direction = hitInfo.point - playerCharacter.transform.position;
                    Quaternion targetRot = Quaternion.LookRotation(direction);
                    targetRot.eulerAngles = new Vector3(0, targetRot.eulerAngles.y, 0);
                    playerCharacter.transform.rotation = targetRot;
                }
            }
        }
    }
}
