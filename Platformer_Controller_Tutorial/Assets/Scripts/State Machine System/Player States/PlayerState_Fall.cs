/****************************************************
    文件：PlayerState_Fall.cs
	作者：HKZ
    邮箱: 3046916186@qq.com
    日期：2022/9/27 0:25:47
	功能：Nothing
*****************************************************/

using UnityEngine;

namespace HKZ
{
    [CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Fall", fileName = "PlayerState_Fall")]
    public class PlayerState_Fall : PlayerState
    {
        [SerializeField] private AnimationCurve speedCurve;
        [SerializeField] private float moveSpeed = 5.0f;
        public override void LogicUpdate()
        { 
            if (player.IsGrounded)
            {
                stateMachine.SwicthState(typeof(PlayerState_Land));
            }

            if (input.Jump)
            {
                if (player.CanAirJump)
                {
                    stateMachine.SwicthState(typeof(PlayerState_AirJump));
                    return;
                }
                input.SetJumpInputBufferTimer();
            }
        }

        public override void PhysicUpdate()
        {
            player.Move(moveSpeed);

            player.SetVelocityY(speedCurve.Evaluate(StateDuration));
        }
    }
}