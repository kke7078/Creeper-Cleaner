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
            //Vector3 targetPosition = playerPosition + new Vector3(0, 6.5f, -7.05f); //카메라와 캐릭터 사이의 거리

            //카메라 이동
            //Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, targetPosition, Time.deltaTime * cameraSpeed);
        }
    }
}
