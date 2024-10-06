using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KGY
{
    public class CameraSystem : MonoBehaviour
    {
        public float cameraSpeed = 5f;
        public GameObject playerCharacter;

        private void Update()
        {
            Vector3 playerPosition = playerCharacter.transform.position;
            //카메라랑 플레이어 사이의 거리도 구해놔야 함! 
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, playerPosition, Time.deltaTime * 10f);
        }
    }
}
