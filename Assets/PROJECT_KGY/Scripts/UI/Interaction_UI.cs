using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KGY
{
    public class Interaction_UI : MonoBehaviour
    {
        public RectTransform cleanState;

        private void Update()
        {
            Debug.Log(cleanState.anchoredPosition);


            //show
            if (Input.GetKeyDown(KeyCode.F5))
            {
                //while을 써보자

                Vector2 showPosition = new Vector2(cleanState.anchoredPosition.x, 50f);
                cleanState.anchoredPosition = Vector2.Lerp(cleanState.anchoredPosition, new Vector2(cleanState.anchoredPosition.x, 50f), Time.deltaTime * 50f);
                //Vector3 showPosition = new Vector3(cleanState.position.x, 50f, cleanState.position.z);
                //cleanState.position = Vector3.Lerp(cleanState.position, showPosition, Time.deltaTime);
            }

            //hide
            if (Input.GetKeyDown(KeyCode.F6))
            {
                cleanState.GetComponent<Animator>().SetTrigger("isShowTrigger");
                cleanState.GetComponent<Animator>().SetBool("isShow", false);
            }
        }
    }
}
