using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KGY
{
    public class GameScene : SceneBase
    {
        public override float SceneLoadProgress { get; protected set; }
        public override IEnumerator SceneStart()
        {
            AsyncOperation async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("GameScene");

            while (!async.isDone)
            {
                yield return null;
                SceneLoadProgress = async.progress;
            }

            //Ingame에서 사용할 UI를 띄워준다.
            //UIManager.Show<IngameUI>(UIList.IngameUI);
        }

        public override IEnumerator SceneEnd()
        {
            //Ingame에서 사용할 UI를 숨겨준다.
            //UIManager.Hide<IngameUI>(UIList.IngameUI);

            AsyncOperation async = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("GameScene");
            while (!async.isDone)
            {
                yield return null;
                SceneLoadProgress = async.progress;
            }
        }
    }
}
