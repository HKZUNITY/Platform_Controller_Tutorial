/****************************************************
    文件：AutoRotate.cs
	作者：HKZ
    邮箱: 3046916186@qq.com
    日期：2022/9/28 0:32:5
	功能：Nothing
*****************************************************/

using UnityEngine;

namespace HKZ
{
    public class AutoRotate : MonoBehaviour
    {
        [SerializeField] private Vector3 rotation;
        private void Update()
        {
            transform.Rotate(rotation * Time.deltaTime);
        }
    }
}