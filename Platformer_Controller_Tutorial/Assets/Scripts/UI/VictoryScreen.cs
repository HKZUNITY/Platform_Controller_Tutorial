/****************************************************
    文件：VictoryScreen.cs
	作者：HKZ
    邮箱: 3046916186@qq.com
    日期：2022/11/6 13:57:13
	功能：Nothing
*****************************************************/

using UnityEngine;
using UnityEngine.UI;

namespace HKZ
{
    public class VictoryScreen : MonoBehaviour
    {
        [SerializeField] private VoidEventChannel levelClearedEventChannel;
        [SerializeField] private StringEventChannel clearTimeTextEventChannel;

        [SerializeField] private Button nextLevelButton;
        [SerializeField] private Text timeText;


        private void OnEnable()
        {
            levelClearedEventChannel.AddListener(ShowUI);

            nextLevelButton.onClick.AddListener(SceneLoader.LoadNextScene);
            clearTimeTextEventChannel.AddListener(SetTimeText);
        }

        private void OnDisable()
        {
            levelClearedEventChannel.RemoveListener(ShowUI);

            nextLevelButton.onClick.RemoveListener(SceneLoader.LoadNextScene);
            clearTimeTextEventChannel.RemoveListener(SetTimeText);
        }

        private void ShowUI()
        {
            GetComponent<Canvas>().enabled = true;
            GetComponent<Animator>().enabled = true;

            Cursor.lockState = CursorLockMode.None;
        }

        private void SetTimeText(string timeText)
        {
            this.timeText.text = timeText;
        }
    }
}