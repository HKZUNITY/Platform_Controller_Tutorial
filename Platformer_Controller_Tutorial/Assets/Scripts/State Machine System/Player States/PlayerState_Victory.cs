/****************************************************
    文件：PlayerState_Victory.cs
	作者：HKZ
    邮箱: 3046916186@qq.com
    日期：2022/11/9 12:53:18
	功能：Nothing
*****************************************************/

using UnityEngine;

namespace HKZ
{
    [CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Victory", fileName = "PlayerState_Victory")]
    public class PlayerState_Victory : PlayerState
    {
        [SerializeField] private AudioClip[] voice;
        public override void Enter()
        {
            base.Enter();
            input.DisableGameplayInputs();

            player.VoicePlayer.PlayOneShot(voice[Random.Range(0, voice.Length)]);
        }
    }
}