using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KGY
{
    public class CleanerRoomSensor : MonoBehaviour
    {
        public CleanerRoom CurrentRoom { get; private set; }
        public System.Action<CleanerRoom> OnEnterCleanerRoom;
        public System.Action<CleanerRoom> OnExitCleanerRoom;


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out CleanerRoom roomData))
            {
                CurrentRoom = roomData;
                OnEnterCleanerRoom?.Invoke(CurrentRoom);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent(out CleanerRoom roomData))
            {
                CurrentRoom = null;
                OnExitCleanerRoom?.Invoke(CurrentRoom);
            }
        }
    }
}
