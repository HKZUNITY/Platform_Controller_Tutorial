/****************************************************
    文件：StarGem.cs
	作者：HKZ
    邮箱: 3046916186@qq.com
    日期：2022/9/28 0:10:39
	功能：给宝石播放音效
*****************************************************/

using System.Collections;
using UnityEngine;

namespace HKZ
{
    public class StarGem : MonoBehaviour
    {
        [SerializeField] private float resetTime = 3.0f;
        [SerializeField] private AudioClip pickUpSFX;
        [SerializeField] private ParticleSystem pickUpVFX;

        private new Collider collider;
        private MeshRenderer meshRenderer;
        private AudioSource audioSource;

        private WaitForSeconds waitResetTime;
        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            collider = GetComponent<Collider>();
            meshRenderer = GetComponentInChildren<MeshRenderer>();
            waitResetTime = new WaitForSeconds(resetTime);
        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent<PlayerController>(out PlayerController player))
            {
                player.CanAirJump = true;
                collider.enabled = false;
                meshRenderer.enabled = false;
                audioSource.PlayOneShot(pickUpSFX);
                Instantiate(pickUpVFX, transform.position, Quaternion.identity); 

                //Invoke(nameof(Reset), resetTime);
                StartCoroutine(ResetCoroutine());
            }
        }

        private void Reset()
        {
            collider.enabled = true;
            meshRenderer.enabled = true;
        }

        private IEnumerator ResetCoroutine()
        {
            yield return waitResetTime;
            Reset();
        }
    }
}