/****************************************************
    文件：BalacBall.cs
	作者：HKZ
    邮箱: 3046916186@qq.com
    日期：2022/11/9 13:57:19
	功能：Nothing
*****************************************************/

using UnityEngine;

namespace HKZ
{
    public class BlackBall : MonoBehaviour
    {
        [SerializeField] VoidEventChannel gateTriggerEventChannel;
        [SerializeField] private float lifeTime = 10f;

        private void OnEnable()
        {
            gateTriggerEventChannel.AddListener(OnGateTriggered);
        }
        private void OnDisable()
        {
            gateTriggerEventChannel.RemoveListener(OnGateTriggered);
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out PlayerController player))
            {
                player.OnDefeated();
            }
        }
        private void OnGateTriggered()
        {
            Destroy(gameObject, lifeTime);
        }
    }
}