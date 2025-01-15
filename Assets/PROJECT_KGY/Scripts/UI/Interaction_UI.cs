using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KGY
{
    public class Interaction_UI : MonoBehaviour
    {
        public static Interaction_UI Instance { get; private set; }
        public string PlaceName 
        {
            get { return _placeName; }
            set 
            {
                _placeName = value;
                cleanPlaceName.text = _placeName;
            }
        }

        public float DirtyTotalCount { get; set; }
        public float DirtyCleanCount { get; set; }

        public float CleanGauge { 
            get { return _cleanGauge; }
            set 
            {
                _cleanGauge = DirtyCleanCount / DirtyTotalCount;
                cleanStateImage.fillAmount = Mathf.Lerp(cleanStateImage.fillAmount, _cleanGauge, Time.deltaTime * 10f);
            }
        }

        [field: SerializeField] public bool IsShow { get; set; } = false;

        public RectTransform cleanState;
        public Image cleanStateImage;
        public TextMeshProUGUI cleanPlaceName;

        private string _placeName;
        private float _dirtyTotalCount;
        private float _dirtyCleanCount;
        private float _cleanGauge;

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            //청소 진행바 위치값 지정
            Vector2 showPosition = IsShow ? new Vector2(cleanState.anchoredPosition.x, 50f) : new Vector2(cleanState.anchoredPosition.x, -100f);
            cleanState.anchoredPosition = Vector2.Lerp(cleanState.anchoredPosition, showPosition, Time.deltaTime * 10f);


            //청소 진행바 값 입력
            CleanGauge = DirtyCleanCount / DirtyTotalCount;

        }
    }
}
