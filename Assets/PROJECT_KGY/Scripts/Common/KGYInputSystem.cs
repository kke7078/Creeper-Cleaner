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
        public System.Action onInteract;

        private void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            moveInput = new Vector2(horizontal, vertical);

            if (Input.GetMouseButtonDown(0))
            {
                onClean?.Invoke(true);
            }

            if (Input.GetMouseButtonUp(0))
            {
                onClean?.Invoke(false);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                onInteract?.Invoke();
            }
        }
    }
}
