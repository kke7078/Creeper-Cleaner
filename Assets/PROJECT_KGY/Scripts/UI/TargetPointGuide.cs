using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KGY 
{
    public class TargetPointGuide : MonoBehaviour
    {

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("CleanTarget"))
            {
                if (other.transform.localScale.x > 0.05f)
                {
                    other.transform.localScale = Vector3.Lerp(other.transform.localScale, Vector3.zero, Time.deltaTime * 3f);
                }
                else
                {
                    Destroy(other.gameObject);
                }
            }
        }
    }
}
