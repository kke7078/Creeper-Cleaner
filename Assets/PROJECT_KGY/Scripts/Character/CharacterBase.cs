using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KGY
{
    public class CharacterBase : MonoBehaviour
    {
        public bool IsMad => isMad;
        
        public GameObject waterSpray;
        public GameObject cleanPoint;
        public float moveSpeed;

        protected float speed = 0f;
        protected float targetRotation;
        protected float rotationVelocity;
        protected float RotationSmoothTime = 0.12f;
        protected bool isMad;

        private UnityEngine.CharacterController unityCharacterController;
        protected Animator characterAnimator;

        protected virtual void Awake()
        {
            characterAnimator = GetComponent<Animator>();
            unityCharacterController = GetComponent<UnityEngine.CharacterController>();
        }

        private void Start()
        {
            
        }

        private void Update()
        {
            Ray wallCheckRay = new Ray(transform.position, transform.forward);
            RaycastHit checkRayHitInfo;

            if (Physics.Raycast(wallCheckRay, out checkRayHitInfo, 1f))
            {
                Debug.Log(checkRayHitInfo.collider.name);
            }
            else
            {
                Debug.Log("타겟 없음");
            }

            //레이 시각화
            Debug.DrawRay(wallCheckRay.origin, wallCheckRay.direction * 1f, Color.red);
        }

        public virtual void Clean(bool isClean)
        {
            if (isClean)
            {
                moveSpeed = 3f;   //캐릭터 이동속도 감소
                waterSpray.SetActive(true);     //물뿌리기 이펙트 show
                cleanPoint.SetActive(true);     //타겟포인트 show

                characterAnimator.SetTrigger("CleanTrigger");
                characterAnimator.SetBool("IsCleaning", true);
                characterAnimator.SetFloat("Cleaning", 1);
            }
            else
            {
                moveSpeed = 4f;   //캐릭터 이동속도 원복
                waterSpray.SetActive(false);     //물뿌리기 이펙트 hide
                cleanPoint.SetActive(false);     //타겟포인트 hide

                characterAnimator.SetBool("IsCleaning", false);
                characterAnimator.SetFloat("Cleaning", 0);
            }
        }

        public virtual void Move(Vector2 input)
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

        public void Teleport(Vector3 position)
        {
            unityCharacterController.enabled = false;
            transform.position = position;
            unityCharacterController.enabled = true;
        }
    }

}