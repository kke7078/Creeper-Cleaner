using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace KGY
{
    // <summary> progress�� �׻� 0 ~ 1 ���� ������ ���� �� </summary>
    public class LoadingUI : UIBase
    {
        public float LoadingProgress
        {
            set
            {
                loadingBar.fillAmount = value;
                loadingText.text = $"{value * 100f:0.0} %";
            }
        }

        [SerializeField] private UnityEngine.UI.Image loadingBar;
        [SerializeField] private TextMeshProUGUI loadingText;
    }
}
