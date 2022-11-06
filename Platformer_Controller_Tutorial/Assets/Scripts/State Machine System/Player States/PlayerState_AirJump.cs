/****************************************************
    文件：PlayerState_AriJump.cs
	作者：HKZ
    邮箱: 3046916186@qq.com
    日期：2022/9/27 23:28:5
	功能：Nothing
*****************************************************/

using UnityEngine;

namespace HKZ
{
    [CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/AirJump", fileName = "PlayerState_AirJump")]
    public class PlayerState_AirJump : PlayerState
    {
        [SerializeField] private float jumpForce = 7.0f;
        [SerializeField] private float moveSpeed = 5.0f;
        [SerializeField] private ParticleSystem jumpVFX;
        public override void Enter()
        {
            base.Enter();

            player.CanAirJump = false;
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