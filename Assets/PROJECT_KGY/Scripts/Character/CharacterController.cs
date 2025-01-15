using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Schema;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

namespace KGY
{
    public class CharacterController : MonoBehaviour
    {
        public bool IsCleaning
        {
            get { return isCleaning; }
            set { isCleaning = value; }
        }

        private CharacterBase characterBase;
        private bool isCleaning;

        private void Awake()
        {
            characterBase = GetComponent<CharacterBase>();
        }

        private void Start()
        {
            KGYInputSystem.Singleton.onClean += Clean;
            KGYInputSystem.Singleton.onInteract += Interact;

            var playerCharacter = characterBase as PlayerCharacter;
            playerCharacter.OnCleanerRoomEntered += OnCleanerRoomEnter;
            playerCharacter.OnCleanerRoomExited += OnCleanerRoomExit;

            //마지막으로 저장된 캐릭터 위치값 : 나중에 사용할 것...
            //characterBase.Teleport(UserDataModel.Singleton.PlayerSessionData.lastPosition);
        }

        private void OnCleanerRoomEnter(CleanerRoom roomData)
        {
            //청소가 완성된 상태라면 return
            if (roomData.isComplete) return;

            //청소상태 업데이트
            Interaction_UI.Instance.PlaceName = roomData.roomName;
            Interaction_UI.Instance.DirtyTotalCount = roomData.DIrtyTotalCount;
            Interaction_UI.Instance.DirtyCleanCount = roomData.DirtyCleanCount;

            Interaction_UI.Instance.IsShow = true;
        }

        private void OnCleanerRoomExit()
        {
            Interaction_UI.Instance.IsShow = false;
            Interaction_UI.Instance.DirtyCleanCount = 0;
        }

        private void Update()
        {
            Vector2 input = KGYInputSystem.Singleton.moveInput;
            characterBase.Move(input);

            if (IsCleaning)
            {
                //클릭하는 방향으로 캐릭터 회전
                Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(mouseRay, out RaycastHit hitInfo, 1000f))
                {
                    Vector3 direction = hitInfo.point - transform.position;
                    Quaternion targetRot = Quaternion.LookRotation(direction);
                    targetRot.eulerAngles = new Vector3(0, targetRot.eulerAngles.y, 0);
                    transform.rotation = targetRot;
                }
            }

            //캐릭터 위치값 저장
            if (Input.GetKeyDown(KeyCode.F1))
            { 
                UserDataModel.Singleton.SetPlayerSessionData(characterBase.transform.position, 50, 20);
            }
        }

        private void Clean(bool isClean)
        {
            characterBase.Clean(isClean);
            IsCleaning = isClean;

            int randomSound = UnityEngine.Random.Range(0, 2);
            SoundType fireSoundType = randomSound == 0 ? SoundType.Fire_01 : SoundType.Fire_02;
            //SoundSystem.Singleton.PlaySFX(fireSoundType, fireStartPoint.position); fireStartPoint.position : 효과음이 시작되어야 하는 위치값
        }

        private void Interact()
        {
            var playerCharacter = characterBase as PlayerCharacter;
            if (playerCharacter == null) return;

            playerCharacter.Interact();
        }
    }
}
