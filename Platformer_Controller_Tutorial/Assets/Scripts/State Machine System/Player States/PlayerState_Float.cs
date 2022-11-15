/****************************************************
    文件：PlayerState_Float.cs
	作者：HKZ
    邮箱: 3046916186@qq.com
    日期：2022/11/9 11:34:34
	功能：Nothing
*****************************************************/

using UnityEngine;

namespace HKZ
{
    [CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Float", fileName = "PlayerState_Float")]
    public class PlayerState_Float : PlayerState
    {
        [SerializeField] private VoidEventChannel playerDefeatedEventChannel;

        [SerializeField] private float floatingSpeed = 0.5f;
        [SerializeField] private Vector3 floatingPosiitionOffset;

        [SerializeField] private Vector3 vfxOffset;
        [SerializeField] private ParticleSystem vfx;

        private Vector3 floatingPosition;
        public override void Enter()
        {
            base.Enter();
            playerDefeatedEventChannel.Broadcast();

            Transform playerTranform = player.transform;
            Vector3 vfxPosition = playerTranform.position + new Vector3(playerTranform.localScale.x * vfxOffset.x, vfxOffset.y);
            Instantiate(vfx, vfxPosition, Quaternion.identity, playerTranform);

            floatingPosition = player.transform.position + floatingPosiitionOffset;
        }

        public override void LogicUpdate()
        {
            Transform playerTransform = player.transform;

            if (Vector3.Distance(playerTransform.position, floatingPosition) > floatingSpeed * Time.deltaTime)
            {
                playerTransform.position = Vector3.MoveTowards(playerTransform.position, floatingPosition, floatingSpeed * Time.deltaTime);
            }
            else
            {
                floatingPosition += (Vector3)Random.insideUnitCircle;
            }
        }
    }
}