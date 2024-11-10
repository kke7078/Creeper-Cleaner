using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace KGY
{
    public class TitleUI : MonoBehaviour
    {
        private void Awake()
        {

        }

        public void OnClickStartButton()
        {
            Main.Instance.LoadScene(Main.SceneType.GameScene);
        }

        public void OnClickExitButton()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else  
            Application.Quit();
#endif
        }
    }
}
