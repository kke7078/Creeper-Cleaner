using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace KGY
{
    public class InteractionTutorial : MonoBehaviour
    {
        public TextMeshProUGUI interactionText;

        private void Awake()
        {
            interactionText.GetComponent<RectTransform>().sizeDelta = new Vector2(interactionText.preferredWidth, interactionText.preferredHeight);

            RectTransform rootTransform = interactionText.GetComponentInParent<InteractionTutorial>().GetComponent<RectTransform>();
            rootTransform.sizeDelta = new Vector2(interactionText.GetComponent<RectTransform>().sizeDelta.x + 30, rootTransform.sizeDelta.y);

            Debug.Log(interactionText.GetComponent<RectTransform>().sizeDelta.x);
        }

    }
}
