/****************************************************
    文件：StateMachine.cs
	作者：HKZ
    邮箱: 3046916186@qq.com
    日期：2022/8/1 1:9:54
	功能：Nothing
*****************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace HKZ
{
    public class StateMachine : MonoBehaviour
    {
        IState currentState;

        protected Dictionary<System.Type, IState> stateTable;

        private void Update()
        {
            currentState.LogicUpdate();
        }

        private void FixedUpdate()
        {
            currentState.PhysicUpdate();
        }

        protected void SwitchOn(IState newState)
        {
            currentState = newState;
            currentState.Enter();
        }

        public void SwicthState(IState newState)
        {
            currentState.Exit();
            SwitchOn(newState);
        }
        public void SwicthState(System.Type newStateType)
        {
            SwicthState(stateTable[newStateType]);
        }
    }
}