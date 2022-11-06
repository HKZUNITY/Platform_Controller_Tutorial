/****************************************************
    文件：PlayerController.cs
	作者：HKZ
    邮箱: 3046916186@qq.com
    日期：2022/8/3 0:19:25
	功能：Nothing
*****************************************************/

using UnityEngine;

namespace HKZ
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerGroundDetector groundDetector;

        private PlayerInput input;

        private new Rigidbody rigidbody;

        public bool CanAirJump { get; set; } = true;
        public bool IsGrounded => groundDetector.IsGround;
        public bool IsFalling => rigidbody.velocity.y < 0f && !IsGrounded;
        public float MoveSpeed => Mathf.Abs(rigidbody.velocity.x);

        private void Awake()
        {
            groundDetector = GetComponentInChildren<PlayerGroundDetector>();
            input = GetComponent<PlayerInput>();
            rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            input.EnableGamePlayInputs();
        }

        public void Move(float speed)
        {
            if (input.Move)
            {
                transform.localScale = new Vector3(input.AxisX, 1f, 1f);
            }
            SetVelocityX(speed * input.AxisX);
        }

        public void SetVelocity(Vector3 velocity)
        {
            rigidbody.velocity = velocity;
        }

        public void SetVelocityX(float velocityX)
        {
            rigidbody.velocity = new Vector3(velocityX, rigidbody.velocity.y);
        }

        public void SetVelocityY(float velocityY)
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, velocityY);
        }

        public void SetUseGravity(bool value)
        {
            rigidbody.useGravity = value;
        }
    }
}