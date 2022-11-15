/****************************************************
    文件：VoidEventChannel.cs
	作者：HKZ
    邮箱: 3046916186@qq.com
    日期：2022/11/6 13:36:55
	功能：Nothing
*****************************************************/

using System;
using UnityEngine;

namespace HKZ
{
    [CreateAssetMenu(menuName ="Data/EventChannels",fileName ="VoidEventChannel_")]
    public class VoidEventChannel : ScriptableObject
    {
        private Action Delegate;

        public void Broadcast()
        {
            Delegate?.Invoke();
        }

        public void AddListener(Action action)
        {
            Delegate += action;
        }

        public void RemoveListener(Action action)
        {
            Delegate -= action;
        }
    }
}