using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KGY
{
    public abstract class SceneBase : MonoBehaviour
    {
        public abstract float SceneLoadProgress { get; protected set; }
        public abstract IEnumerator SceneStart();
        public abstract IEnumerator SceneEnd();
    }
}
