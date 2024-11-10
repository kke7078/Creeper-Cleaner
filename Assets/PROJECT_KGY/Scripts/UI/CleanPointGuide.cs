using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KGY 
{
    public class CleanPointGuide : MonoBehaviour
    {
        private CharacterController playerCharacter;

        private void Awake()
        {
            playerCharacter = GetComponentInParent<CharacterController>();
        }

        private void OnTriggerStay(Collider other)
        {
            if (!playerCharacter.IsCleaning) return;

            if (other.gameObject.layer == LayerMask.NameToLayer("CleanTarget"))
            {
                Debug.Log("청소할 것");
            }

            //if (other.gameObject.layer == LayerMask.NameToLayer("TargetObj"))
            //{
            //    if (other.transform.localScale.x > 0.05f)
            //    {
            //        other.transform.localScale = Vector3.Lerp(other.transform.localScale, Vector3.zero, Time.deltaTime * 3f);
            //    }
            //    else
            //    {
            //        Destroy(other.gameObject);
            //    }
            //}
        }
    }
}
