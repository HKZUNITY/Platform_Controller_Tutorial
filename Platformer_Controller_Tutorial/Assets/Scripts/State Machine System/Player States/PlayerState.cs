/****************************************************
    文件：PlayerState.cs
	作者：HKZ
    邮箱: 3046916186@qq.com
    日期：2022/8/2 23:40:6
	功能：Nothing
*****************************************************/

using UnityEngine;

namespace HKZ
{
    public class PlayerState : ScriptableObject, IState
    {
        [SerializeField] private string stateName;
        [SerializeField, Range(0f, 1f)] private float transitionDuration = 0.1f;

        private float stateStartTime;

        private int stateHash;

        protected float currentSpeed;

        protected Animator animator;
        protected PlayerStateMachine stateMachine;
        protected PlayerInput input;
        protected PlayerController player;

        protected bool IsAnimationFinished => StateDuration >= animator.GetCurrentAnimatorStateInfo(0).length;
        protected float StateDuration => Time.time - stateStartTime;

        private void OnEnable()
        {
            stateHash = Animator.StringToHash(stateName);
        }
        public void Initialize(Animator animator, PlayerController player, PlayerInput input, PlayerStateMachine stateMachine)
        {
            this.animator = animator;
            this.player = player;
            this.input = input;
            this.stateMachine = stateMachine;
        }
        public virtual void Enter()
        {
            animator.CrossFade(stateHash, transitionDuration);
            stateStartTime = Time.time;
        }

        public virtual void Exit()
        {
        }

        public virtual void LogicUpdate()
        {
        }

        public virtual void PhysicUpdate()
        {
        }
    }
}