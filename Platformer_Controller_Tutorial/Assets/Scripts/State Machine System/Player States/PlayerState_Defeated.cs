/****************************************************
    文件：PlayerState_Defeated.cs
	作者：HKZ
    邮箱: 3046916186@qq.com
    日期：2022/11/9 11:34:51
	功能：Nothing
*****************************************************/

using UnityEngine;

namespace HKZ
{
    [CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Defeated", fileName = "PlayerState_Defeated")]
    public class PlayerState_Defeated : PlayerState
    {
        [SerializeField] private ParticleSystem vfx;
        [SerializeField] private AudioClip[] voice;
        public override void Enter()
        {
            base.Enter();

            Instantiate(vfx, player.transform.position, Quaternion.identity);

            AudioClip deathVoice = voice[Random.Range(0, voice.Length)];
            player.VoicePlayer.PlayOneShot(deathVoice);
        }

        public override void LogicUpdate()
        {
            if (IsAnimationFinished)
            {
                stateMachine.SwicthState(typeof(PlayerState_Float));
            }
        }
    }
}