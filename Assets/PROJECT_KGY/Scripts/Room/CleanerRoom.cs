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

                //û�Ұ� �Ϸ�Ǿ��ٸ�?
                if (DirtyCleanCount == DIrtyTotalCount)
                {
                    Debug.Log($"{roomName} û�� �Ϸ�!");
                    isComplete = true;

                    //û�� UI �Ⱥ��̰� �����
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
