/****************************************************
    文件：Gate.cs
	作者：HKZ
    邮箱: 3046916186@qq.com
    日期：2022/11/6 13:21:53
	功能：Nothing
*****************************************************/

using UnityEngine;

namespace HKZ
{
    public class Gate : MonoBehaviour
    {
        [SerializeField] private VoidEventChannel gateTriggeredEventChannel;

        //private GateTrigger gateTrigger;
        //private void Start()
        //{
            //gateTrigger = FindObjectOfType<GateTrigger>();
            //gateTrigger.Delegate += Open;
        //}
        private void OnEnable()
        {
            gateTriggeredEventChannel.AddListener(Open);
        }
        private void OnDisable()
        {
            //gateTrigger.Delegate -= Open;
            gateTriggeredEventChannel.RemoveListener(Open);
        }
        private void Open()
        {
            Destroy(gameObject);
        }
    }
}