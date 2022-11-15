/****************************************************
    文件：SceneLoader.cs
	作者：HKZ
    邮箱: 3046916186@qq.com
    日期：2022/11/9 12:39:8
	功能：Nothing
*****************************************************/

using UnityEngine.SceneManagement;

namespace HKZ
{
    public class SceneLoader
    {
        public static void ReloadScene()
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(sceneIndex);
        }

        public static void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        public static void LoadNextScene()
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (sceneIndex >= SceneManager.sceneCount)
            {
                //DO Something.E.g. Load your main menu scene
                ReloadScene();
                return;
            }
            SceneManager.LoadScene(sceneIndex);
        }
    }
}