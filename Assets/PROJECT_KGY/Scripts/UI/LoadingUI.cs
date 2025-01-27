using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace KGY
{
    public class LoadingUI : UIBase
    {
        public static LoadingUI Instance => UIManager.Singleton.GetUI<LoadingUI>(UIList.LoadingUI);

        // <summary> progress는 항상 0 ~ 1 사이 값으로 넣을 것 </summary>
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
