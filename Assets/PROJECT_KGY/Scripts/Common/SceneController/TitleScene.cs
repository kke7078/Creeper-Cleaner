using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KGY
{
    public class TitleScene : SceneBase
    {
        public override float SceneLoadProgress { get; protected set; }
        public override IEnumerator SceneStart()
        {
            AsyncOperation async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("TitleScene");

            while (!async.isDone)
            { 
                yield return null;
                SceneLoadProgress = async.progress;
            }

            //Title UI¸¦ º¸¿©Áà
            //UIManager.Show<TitleUI>(UIList.TitleUI);
        }

        public override IEnumerator SceneEnd()
        {
            //Title UI¸¦ ¼û±â±â
            //UIManager.Hide<TitleUI>(UIList.TitleUI);

            AsyncOperation async = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("TitleScene");
            while (!async.isDone)
            {
                yield return null;
                SceneLoadProgress = async.progress;
            }
        }
    }
}
