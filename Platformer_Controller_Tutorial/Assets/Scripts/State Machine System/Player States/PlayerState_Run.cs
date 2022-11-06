/****************************************************
    文件：PlayerState_Run.cs
	作者：HKZ
    邮箱: 3046916186@qq.com
    日期：2022/8/3 0:27:46
	功能：Nothing
*****************************************************/

using UnityEngine;

namespace HKZ
{
    [CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Run", fileName = "PlayerState_Run")]
    public class PlayerState_Run : PlayerState
    {
        [SerializeField] private float runSpeed = 5f;
        [SerializeField] private float acceleration = 5f;
        public override void Enter()
        {
            base.Enter();
            //animator.Play("Unity_Chan_Run");
        }

        public override void LogicUpdate()
        {
            if (!input.Move)
            {
                stateMachine.SwicthState(typeof(PlayerState_Idle));
            }

            if (input.Jump)
            { 
                stateMachine.SwicthState(typeof(PlayerState_JumpUp));
            }

            if (!player.IsGrounded)
            {
                stateMachine.SwicthState(typeof(PlayerState_CoyoteTime));
            }

            currentSpeed = Mathf.MoveTowards(currentSpeed, runSpeed, acceleration * Time.deltaTime);
        }

        public override void PhysicUpdate()
        {
            player.Move(currentSpeed);
        }
    }
}