/****************************************************
    文件：PlayerState_CoyoteTime.cs
	作者：HKZ
    邮箱: 3046916186@qq.com
    日期：2022/10/7 21:44:59
	功能：Nothing
*****************************************************/

using UnityEngine;

namespace HKZ
{
    [CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/CoyoteTime", fileName = "PlayerState_CoyoteTime")]
    public class PlayerState_CoyoteTime : PlayerState
    {
        [SerializeField] private float runSpeed = 5f;

        [SerializeField] private float coyoteTime = 0.1f;
        public override void Enter()
        {
            base.Enter();
            player.SetUseGravity(false);
        }

        public override void Exit()
        {
            player.SetUseGravity(true);
        }

        public override void LogicUpdate()
        {
            if (input.Jump)
            {
                stateMachine.SwicthState(typeof(PlayerState_JumpUp));
            }

            if (StateDuration > coyoteTime || !input.Move) 
            {
                stateMachine.SwicthState(typeof(PlayerState_Fall));
            }

        }

        public override void PhysicUpdate()
        {
            player.Move(runSpeed);
        }
    }
}