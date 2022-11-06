/****************************************************
    文件：PlayerInput.cs
	作者：HKZ
    邮箱: 3046916186@qq.com
    日期：2022/9/25 23:3:20
	功能：Nothing
*****************************************************/

using System.Collections;
using UnityEngine;

namespace HKZ
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private float JumpInputBufferTime = 0.5f;
        private WaitForSeconds waitJumpInputBufferTime;


        private PlayerInputAction playerInputAction;
        private Vector2 axes => playerInputAction.GamePlay.Axes.ReadValue<Vector2>();

        public bool HasJumpInputBuffer { get; set; }
        public bool Jump => playerInputAction.GamePlay.Jump.WasPressedThisFrame();
        public bool StopJum => playerInputAction.GamePlay.Jump.WasReleasedThisFrame();
        public bool Move => AxisX != 0f;

        public float AxisX => axes.x;

        private void Awake()
        {
            playerInputAction = new PlayerInputAction();

            waitJumpInputBufferTime = new WaitForSeconds(JumpInputBufferTime);
        }

        private void OnEnable()
        {
            playerInputAction.GamePlay.Jump.canceled += delegate
            {
                HasJumpInputBuffer = false;
            };
        }

        //private void OnGUI()
        //{
        //    Rect rect = new Rect(200, 200, 200, 200);
        //    string message = "Has Jump Input Buffer：" + HasJumpInputBuffer;
        //    GUIStyle style = new GUIStyle();
        //    style.fontSize = 20;
        //    style.fontStyle = FontStyle.Bold;

        //    GUI.Label(rect, message, style);
        //}

        public void EnableGamePlayInputs()
        {
            playerInputAction.GamePlay.Enable();
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void SetJumpInputBufferTimer()
        {
            StopCoroutine(nameof(JumpInputBufferCoroutine));
            StartCoroutine(nameof(JumpInputBufferCoroutine));
        }

        private IEnumerator JumpInputBufferCoroutine()
        {
            HasJumpInputBuffer = true;
            yield return waitJumpInputBufferTime;
            HasJumpInputBuffer = false;
        }
    }
}