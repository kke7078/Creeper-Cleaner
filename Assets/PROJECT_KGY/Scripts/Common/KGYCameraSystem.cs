using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KGY
{
    public class KGYCameraSystem : MonoBehaviour
    {
        public float cameraSpeed;
        public GameObject playerCharacter;
        public Camera mainCamera;

        private void LateUpdate()
        {
            Vector3 playerPosition = playerCharacter.transform.position;
            //Vector3 targetPosition = playerPosition + new Vector3(0, 6.5f, -7.05f); //ī�޶�� ĳ���� ������ �Ÿ�

            //ī�޶� �̵�
            //Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, targetPosition, Time.deltaTime * cameraSpeed);
        }
    }
}
