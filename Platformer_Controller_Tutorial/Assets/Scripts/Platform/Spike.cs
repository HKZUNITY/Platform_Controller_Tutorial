/****************************************************
    文件：Spike.cs
	作者：HKZ
    邮箱: 3046916186@qq.com
    日期：2022/11/9 11:26:20
	功能：Nothing
*****************************************************/

using UnityEngine;

namespace HKZ
{
    public class Spike : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out PlayerController player))
            {
                player.OnDefeated();
            }
        }
    }
}