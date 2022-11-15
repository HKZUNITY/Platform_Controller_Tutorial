/****************************************************
    文件：ClearTimer.cs
	作者：HKZ
    邮箱: 3046916186@qq.com
    日期：2022/11/9 13:11:54
	功能：Nothing
*****************************************************/

using UnityEngine;
using UnityEngine.UI;

namespace HKZ
{
    public class ClearTimer : MonoBehaviour
    {
        [SerializeField] private Text timeText;

        [SerializeField] private VoidEventChannel levelStartedEventChannel;
        [SerializeField] private VoidEventChannel levelClearedEVentChannel;
        [SerializeField] private VoidEventChannel playerDefeatedEventChannel;

        [SerializeField] private StringEventChannel clearTimeTextEventChannel;

        private bool stop = true;

        private float clearTime;

        private void OnEnable()
        {
            levelStartedEventChannel.AddListener(levelStart);
            levelClearedEVentChannel.AddListener(levelClear);
            playerDefeatedEventChannel.AddListener(HideUI);
        }
        private void OnDisable()
        {
            levelStartedEventChannel.RemoveListener(levelStart);
            levelClearedEVentChannel.RemoveListener(levelClear);
            playerDefeatedEventChannel.RemoveListener(HideUI);
        }
        private void FixedUpdate()
        {
            if (stop) return;
            clearTime += Time.fixedDeltaTime;
            timeText.text = System.TimeSpan.FromSeconds(clearTime).ToString(@"mm\:ss\:ff");
        }

        private void levelStart()
        {
            stop = false;
        }

        private void levelClear()
        {
            HideUI();
            clearTimeTextEventChannel.Broadcast(timeText.text);
        }

        private void HideUI()
        {
            stop = true;
            GetComponent<Canvas>().enabled = false;
        }
    }
}