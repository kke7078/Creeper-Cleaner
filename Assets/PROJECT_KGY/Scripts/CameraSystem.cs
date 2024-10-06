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
            //ī�޶�� �÷��̾� ������ �Ÿ��� ���س��� ��! 
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, playerPosition, Time.deltaTime * 10f);
        }
    }
}
