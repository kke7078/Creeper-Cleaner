using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KGY
{
    public class CameraSystem : MonoBehaviour
    {
        public float cameraSpeed;
        public GameObject playerCharacter;
        public Camera mainCamera;

        private void LateUpdate()
        {
            Vector3 playerPosition = playerCharacter.transform.position;
            Vector3 targetPosition = playerPosition + new Vector3(0, 5.5f, -7.05f); //ī�޶�� ĳ���� ������ �Ÿ�

            //ī�޶� �̵�
            Camera.main.transform.position = targetPosition;
        }
    }
}
