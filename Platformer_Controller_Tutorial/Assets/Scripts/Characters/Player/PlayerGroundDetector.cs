/****************************************************
    文件：PlayerGroundDetector.cs
	作者：HKZ
    邮箱: 3046916186@qq.com
    日期：2022/9/27 0:27:43
	功能：Nothing
*****************************************************/

using UnityEngine;

namespace HKZ
{
    public class PlayerGroundDetector : MonoBehaviour
    {
        [SerializeField] private float detectionRadius = 0.1f;
        [SerializeField] LayerMask groundLayer;

        private Collider[] colliders = new Collider[1];

        public bool IsGround => Physics.OverlapSphereNonAlloc(transform.position, detectionRadius, colliders, groundLayer) != 0;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
        }
    }
}