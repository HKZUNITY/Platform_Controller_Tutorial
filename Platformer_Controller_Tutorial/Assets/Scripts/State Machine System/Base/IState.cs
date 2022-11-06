/****************************************************
    文件：IState.cs
	作者：HKZ
    邮箱: 3046916186@qq.com
    日期：2022/8/1 1:3:53
	功能：state接口
*****************************************************/

using UnityEngine;

namespace HKZ
{
    public interface IState
    {
        /// <summary>
        /// 进入
        /// </summary>
        void Enter();
        /// <summary>
        /// 离开
        /// </summary>
        void Exit();
        /// <summary>
        /// 逻辑更新
        /// </summary>
        void LogicUpdate();
        /// <summary>
        /// 物理更新
        /// </summary>
        void PhysicUpdate();
    }
}