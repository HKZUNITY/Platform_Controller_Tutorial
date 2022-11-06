/****************************************************
    文件：PlayerStateMachine.cs
	作者：HKZ
    邮箱: 3046916186@qq.com
    日期：2022/8/2 23:40:38
	功能：Nothing
*****************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace HKZ
{
    public class PlayerStateMachine : StateMachine
    {
        [SerializeField]
        private PlayerState[] states;

        private Animator animator;

        private PlayerController player;

        private PlayerInput input;

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
            player = GetComponent<PlayerController>();
            input = GetComponent<PlayerInput>();
            stateTable = new Dictionary<System.Type, IState>(states.Length);
            foreach (PlayerState state in states)
            {
                state.Initialize(animator, player,input, this);
                stateTable.Add(state.GetType(), state);
            }
        }

        private void Start()
        {
            SwitchOn(stateTable[typeof(PlayerState_Idle)]);
        }
    }
}