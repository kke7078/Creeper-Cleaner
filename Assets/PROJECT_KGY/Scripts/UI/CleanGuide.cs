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
            //���콺 ��ġ �������� ȸ��
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mouseRay, out RaycastHit hitInfo, 1000f))
            {
                Vector3 direction = hitInfo.point - transform.position; // ����ġ - ���콺 ���̰� ���� ��ġ
                Quaternion targetRot = Quaternion.LookRotation(direction); // �� ���� ���͸� �Ĵٺ��� �ޱ� ��
                targetRot.eulerAngles = new Vector3(90f, targetRot.eulerAngles.y, 0f); // �� �ޱ� ������ Y �� ���� �̿�
                transform.rotation = targetRot;
            }
        }

        private void LateUpdate()
        {
            //ĳ���� ��ġ�� �̵�
            transform.position = playerCharacter.transform.position;
        }
    }
}
