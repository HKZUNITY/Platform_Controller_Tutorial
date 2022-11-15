/****************************************************
    文件：DefeatScreen.cs
	作者：HKZ
    邮箱: 3046916186@qq.com
    日期：2022/11/9 12:28:10
	功能：Nothing
*****************************************************/

using UnityEngine;
using UnityEngine.UI;

namespace HKZ
{
    public class DefeatScreen : MonoBehaviour
    {
        [SerializeField] private VoidEventChannel playerDefeatedEventChannel;
        [SerializeField] private AudioClip[] voice;

        [SerializeField] private Button retryButton;
        [SerializeField] private Button quitButton;

        private void OnEnable()
        {
            playerDefeatedEventChannel.AddListener(ShowUI);

            retryButton.onClick.AddListener(SceneLoader.ReloadScene);
            quitButton.onClick.AddListener(SceneLoader.QuitGame);
        }

        private void OnDisable()
        {
            playerDefeatedEventChannel.RemoveListener(ShowUI);

            retryButton.onClick.RemoveListener(SceneLoader.ReloadScene);
            quitButton.onClick.RemoveListener(SceneLoader.QuitGame);
        }

        private void ShowUI()
        {
            GetComponent<Canvas>().enabled = true;
            GetComponent<Animator>().enabled = true;

            AudioClip retryVoice = voice[Random.Range(0, voice.Length)];
            SoundEffectsPlayer.AudioSource.PlayOneShot(retryVoice);

            Cursor.lockState = CursorLockMode.None;
        }
    }
}