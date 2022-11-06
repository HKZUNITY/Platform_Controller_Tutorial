/****************************************************
    文件：PlayerState_JumpUp.cs
	作者：HKZ
    邮箱: 3046916186@qq.com
    日期：2022/9/27 0:26:3
	功能：Nothing
*****************************************************/

using UnityEngine;

namespace HKZ
{
    [CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/JumpUp", fileName = "PlayerState_JumpUp")]
    public class PlayerState_JumpUp : PlayerState
    {
        [SerializeField] private float jumpForce = 7.0f;
        [SerializeField] private float moveSpeed = 5.0f;
        [SerializeField] private ParticleSystem jumpVFX;

        public override void Enter()
        {
            base.Enter();
            input.HasJumpInputBuffer = false;
            player.SetVelocityY(jumpForce);
            Instantiate(jumpVFX, player.transform.position, Quaternion.identity);
        }
        public override void LogicUpdate()
        {
            if (input.StopJum || player.IsFalling)
            {
                stateMachine.SwicthState(typeof(PlayerState_Fall));
            }
        }

        public override void PhysicUpdate()
        {
            player.Move(moveSpeed);
        }
    }
}