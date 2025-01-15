using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KGY
{
    public class CleanerRoom : MonoBehaviour
    {
        public float DIrtyTotalCount { get; set; }

        public float DirtyCleanCount
        {
            get { return _dirtyCleanCount; }
            set
            {
                _dirtyCleanCount = value;
                Interaction_UI.Instance.DirtyCleanCount = value;

                //청소가 완료되었다면?
                if (DirtyCleanCount == DIrtyTotalCount)
                {
                    Debug.Log($"{roomName} 청소 완료!");
                    isComplete = true;

                    //청소 UI 안보이게 만들기
                    Interaction_UI.Instance.IsShow = false;
                }

            }
        }

        public string roomName;
        public bool isComplete;
        public float _dirtyTotalCount;
        public float _dirtyCleanCount;

        private void Awake()
        {
            DIrtyTotalCount = GetComponentsInChildren<Projector>().Length;
        }
    }
}
