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

            //���������� ����� ĳ���� ��ġ�� : ���߿� ����� ��...
            //characterBase.Teleport(UserDataModel.Singleton.PlayerSessionData.lastPosition);
        }

        private void OnCleanerRoomEnter(CleanerRoom roomData)
        {
            //û�Ұ� �ϼ��� ���¶�� return
            if (roomData.isComplete) return;

            //û�һ��� ������Ʈ
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
                //Ŭ���ϴ� �������� ĳ���� ȸ��
                Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(mouseRay, out RaycastHit hitInfo, 1000f))
                {
                    Vector3 direction = hitInfo.point - transform.position;
                    Quaternion targetRot = Quaternion.LookRotation(direction);
                    targetRot.eulerAngles = new Vector3(0, targetRot.eulerAngles.y, 0);
                    transform.rotation = targetRot;
                }
            }

            //ĳ���� ��ġ�� ����
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
            //SoundSystem.Singleton.PlaySFX(fireSoundType, fireStartPoint.position); fireStartPoint.position : ȿ������ ���۵Ǿ�� �ϴ� ��ġ��
        }

        private void Interact()
        {
            var playerCharacter = characterBase as PlayerCharacter;
            if (playerCharacter == null) return;

            playerCharacter.Interact();
        }
    }
}
