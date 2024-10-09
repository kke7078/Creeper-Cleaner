using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace KGY
{
    public class CharacterController : MonoBehaviour
    {
        public Vector3 moveInput;
        public float moveSpeed;

        protected float targetRotation;
        protected float rotationVelocity;
        protected float RotationSmoothTime = 0.12f;

        private UnityEngine.CharacterController unityCharacterController;

        private void Awake()
        {
            unityCharacterController = GetComponent<UnityEngine.CharacterController>();
        }

        private void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            moveInput = new Vector3(horizontal, 0, vertical);
            Move(moveInput);
        }

        public void Move(Vector3 input)
        {
            float magnitude = input.magnitude;
            if (magnitude <= 0.1f) return;

            Vector3 inputDirection = moveInput.normalized;

            targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg;
            float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref rotationVelocity, RotationSmoothTime);

            transform.rotation = Quaternion.Euler(0, rotation, 0);

            Vector3 targetDirection = Quaternion.Euler(0, targetRotation, 0) * Vector3.forward;

            unityCharacterController.Move(inputDirection * moveSpeed * Time.deltaTime);
        }
    }
}
