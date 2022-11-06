/****************************************************
    文件：PlayerState_Land.cs
	作者：HKZ
    邮箱: 3046916186@qq.com
    日期：2022/9/27 0:26:17
	功能：Nothing
*****************************************************/

using UnityEngine;

namespace HKZ
{
    [CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Land", fileName = "PlayerState_Land")]
    public class PlayerState_Land : PlayerState
    {
        [SerializeField] private float stiffTime = 0.2f;
        public override void Enter()
        {
            base.Enter();

            player.SetVelocity(Vector3.zero);
        }
        public override void LogicUpdate()
        {
            if (input.HasJumpInputBuffer || input.Jump)
            {
                stateMachine.SwicthState(typeof(PlayerState_JumpUp));
            }

            if (StateDuration < stiffTime)
            {
                return;
            }

            if (input.Move)
            {
                stateMachine.SwicthState(typeof(PlayerState_Run));
            }

            if (IsAnimationFinished)
            {
                stateMachine.SwicthState(typeof(PlayerState_Idle));
            }
        }
    }
}