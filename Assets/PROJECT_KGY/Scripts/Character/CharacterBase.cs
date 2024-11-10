using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KGY
{
    public class CharacterBase : MonoBehaviour
    {
        public bool IsMad => isMad;
        
        public GameObject waterSpray;
        public float moveSpeed;

        protected float speed = 0f;
        protected float targetRotation;
        protected float rotationVelocity;
        protected float RotationSmoothTime = 0.12f;
        protected bool isMad;

        private UnityEngine.CharacterController unityCharacterController;
        protected Animator characterAnimator;

        private void Awake()
        {
            characterAnimator = GetComponent<Animator>();
            unityCharacterController = GetComponent<UnityEngine.CharacterController>();
        }

        private void Start()
        {
            
        }

        private void Update()
        {
            
        }

        public virtual void Clean(bool isClean)
        {
            if (isClean)
            {
                moveSpeed = 3f;   //캐릭터 이동속도 감소
                waterSpray.SetActive(true);     //물뿌리기 이펙트 show

                characterAnimator.SetTrigger("CleanTrigger");
                characterAnimator.SetBool("IsCleaning", true);
                characterAnimator.SetFloat("Cleaning", 1);
            }
            else
            {
                moveSpeed = 5f;   //캐릭터 이동속도 원복
                waterSpray.SetActive(false);     //물뿌리기 이펙트 hide

                characterAnimator.SetBool("IsCleaning", false);
                characterAnimator.SetFloat("Cleaning", 0);
            }
        }

        public virtual void Move(Vector2 input, bool isClean)
        {
            float magnitude = input.magnitude;
            characterAnimator.SetFloat("Speed", magnitude);

            if (magnitude <= 0.1f) return;

            Vector3 inputDirection = new Vector3(input.x, 0, input.y).normalized;
            targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg;
            float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref rotationVelocity, RotationSmoothTime);
            transform.rotation = Quaternion.Euler(0, rotation, 0);

            Vector3 targetDirection = Quaternion.Euler(0, targetRotation, 0) * Vector3.forward;

            unityCharacterController.Move(targetDirection.normalized * moveSpeed * Time.deltaTime);
        }
    }

}