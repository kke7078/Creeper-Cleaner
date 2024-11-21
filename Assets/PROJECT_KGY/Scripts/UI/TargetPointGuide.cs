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
                Projector projector = other.gameObject.GetComponentInParent<Projector>();

                //������ ũ�Ⱑ 1���� Ŭ ��
                if (projector.fieldOfView > 1f)
                {
                    //������ ũ�� �ٿ��ֱ�
                    projector.fieldOfView = Mathf.Lerp(projector.fieldOfView, 0f, Time.deltaTime * 3f);
                }
                else
                {
                    //���� ����
                    Destroy(projector);
                    Destroy(other.gameObject);
                }
            }
        }
    }
}
