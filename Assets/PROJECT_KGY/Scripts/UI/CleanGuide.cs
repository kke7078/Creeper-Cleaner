using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KGY 
{
    public class CleanGuide : MonoBehaviour
    {
        public CharacterController playerCharacter;
        //public LayerMask groundLayer;

        private void Update()
        {
            //마우스 위치 방향으로 회전
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mouseRay, out RaycastHit hitInfo, 1000f))
            {
                Vector3 direction = hitInfo.point - transform.position; // 내위치 - 마우스 레이가 닿은 위치
                Quaternion targetRot = Quaternion.LookRotation(direction); // 그 방향 벡터를 쳐다보는 앵글 값
                targetRot.eulerAngles = new Vector3(90f, targetRot.eulerAngles.y, 0f); // 그 앵글 값에서 Y 축 값만 이용
                transform.rotation = targetRot;
            }
        }

        private void LateUpdate()
        {
            //캐릭터 위치로 이동
            transform.position = playerCharacter.transform.position;
        }
    }
}
