/****************************************************
    文件：SoundEffectsPlayer.cs
	作者：HKZ
    邮箱: 3046916186@qq.com
    日期：2022/11/6 12:17:10
	功能：音效播放器
*****************************************************/

using UnityEngine;

namespace HKZ
{
    public class SoundEffectsPlayer : MonoBehaviour
    {
        public static AudioSource AudioSource { get; private set; }

        private void Awake()
        {
            AudioSource = GetComponent<AudioSource>();
            AudioSource.playOnAwake = false;
        }
    }
}