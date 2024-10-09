using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KGY
{
    public class InputSystem : MonoBehaviour
    {
        public CharacterController playerCharacter;

        void OnDrawGizmos()
        { 
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(playerCharacter.transform.position + Vector3.forward, playerCharacter.transform.position + new Vector3(0, -1f, 2f));
        }

        private void LateUpdate()
        {
            if (Input.GetMouseButton(0))
            {
                //클릭한 방향으로 캐릭터 회전
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
