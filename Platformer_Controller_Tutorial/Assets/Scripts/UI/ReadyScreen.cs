/****************************************************
    文件：ReadyScreen.cs
	作者：HKZ
    邮箱: 3046916186@qq.com
    日期：2022/11/6 14:22:10
	功能：Nothing
*****************************************************/

using UnityEngine; 

namespace HKZ
{
    public class ReadyScreen : MonoBehaviour
    {
        [SerializeField] private VoidEventChannel readyStartGameEventChannel;
        [SerializeField] private AudioClip startVoice;
        //Animation EVent Funtion
        private void LevelStart()
        {
            readyStartGameEventChannel.Broadcast();

            GetComponent<Canvas>().enabled = false;
            GetComponent<Animator>().enabled = false;
        }

        private void PlayStartVoice()
        {
            SoundEffectsPlayer.AudioSource.PlayOneShot(startVoice);
        }
    }
}