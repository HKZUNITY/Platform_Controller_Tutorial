/****************************************************
    文件：PlayerState_Idle.cs
	作者：HKZ
    邮箱: 3046916186@qq.com
    日期：2022/8/3 0:27:34
	功能：Nothing
*****************************************************/

using UnityEngine;

namespace HKZ
{
    [CreateAssetMenu(menuName ="Data/StateMachine/PlayerState/Idle",fileName ="PlayerState_Idle")]
    public class PlayerState_Idle : PlayerState
    {
        [SerializeField] private float deceleration = 5f;

        public override void Enter()
        {
            base.Enter();
            //animator.Play("Unity_Chan_Idle");

            //player.SetVelocityX(0f);
            currentSpeed = player.MoveSpeed;
        }

        public override void LogicUpdate()
        {
            if (input.Move)
            {
                stateMachine.SwicthState(typeof(PlayerState_Run));
            }

            if (input.Jump)
            {
                stateMachine.SwicthState(typeof(PlayerState_JumpUp));
            }

            if (!player.IsGrounded)
            {
                stateMachine.SwicthState(typeof(PlayerState_Fall));
            }

            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.deltaTime);
        }

        public override void PhysicUpdate()
        {
            player.SetVelocityX(currentSpeed * player.transform.localScale.x);
        }
    }
}