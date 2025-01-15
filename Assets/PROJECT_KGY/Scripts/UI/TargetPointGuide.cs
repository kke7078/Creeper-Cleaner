using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace KGY 
{
    public class TargetPointGuide : MonoBehaviour
    {
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("CleanTarget"))
            {
                Projector projector = other.gameObject.GetComponentInParent<Projector>();

                //패턴의 크기가 1보다 클 때
                if (projector.fieldOfView > 10f)
                {
                    //패턴의 크기 줄여주기
                    projector.fieldOfView = Mathf.Lerp(projector.fieldOfView, 0f, Time.deltaTime * 3f);
                }
                else
                {
                    //청소된 오브젝트 갯수 증가
                    other.GetComponentInParent<CleanerRoom>().DirtyCleanCount++;

                    //패턴 삭제
                    Destroy(projector);
                    Destroy(other.gameObject);
                }
            }
        }
    }
}
