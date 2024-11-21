using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KGY
{
    public class SoundPlayController : MonoBehaviour
    {
        public SoundType soundType;
        public bool isBGM = false;

        private void Start()
        {
            if (isBGM)
            {
                SoundSystem.Singleton.PlayBGM(soundType);
            }
            else
            {
                SoundSystem.Singleton.PlaySFX(soundType, transform.position);
            }
        }
    }
}
