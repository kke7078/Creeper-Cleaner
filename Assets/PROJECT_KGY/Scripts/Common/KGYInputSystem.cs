using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KGY
{
    public class KGYInputSystem : SingletonBase<KGYInputSystem>
    {
        public Vector2 moveInput;
        public bool isClean;

        public System.Action<bool> onClean;

        private void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            moveInput = new Vector2(horizontal, vertical);

            if (Input.GetMouseButton(0))
            {
                onClean?.Invoke(true);
            }

            if (Input.GetMouseButtonUp(0))
            {
                onClean?.Invoke(false);
            }

        }


        //private void LateUpdate()
        //{
        //    if (Input.GetMouseButtonDown(0))
        //    { 
        //        isShoot = true;
        //        playerCharacter.moveSpeed = 3f;
        //    }

        //    if (Input.GetMouseButtonUp(0))
        //    {
        //        isShoot = false;
        //        playerCharacter.moveSpeed = 5f;
        //    }

        //    if (Input.GetMouseButton(0))
        //    {
        //        //클릭하는 방향으로 캐릭터 회전
        //        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        //        if (Physics.Raycast(mouseRay, out RaycastHit hitInfo, 1000f))
        //        {
        //            Vector3 direction = hitInfo.point - playerCharacter.transform.position;
        //            Quaternion targetRot = Quaternion.LookRotation(direction);
        //            targetRot.eulerAngles = new Vector3(0, targetRot.eulerAngles.y, 0);
        //            playerCharacter.transform.rotation = targetRot;
        //        }
        //    }
        //}
    }
}
