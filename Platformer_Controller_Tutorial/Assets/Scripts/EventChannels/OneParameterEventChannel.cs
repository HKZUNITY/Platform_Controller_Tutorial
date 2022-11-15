/****************************************************
    文件：OneParameterEventChannel.cs
	作者：HKZ
    邮箱: 3046916186@qq.com
    日期：2022/11/9 13:33:22
	功能：Nothing
*****************************************************/

using System;
using UnityEngine;

namespace HKZ
{
    public class OneParameterEventChannel<T> : ScriptableObject
    {
            private Action<T> Delegate;

            public void Broadcast(T obj)
            {
                Delegate?.Invoke(obj);
            }

            public void AddListener(Action<T> action)
            {
                Delegate += action;
            }

            public void RemoveListener(Action<T> action)
            {
                Delegate -= action;
            }
    }
}