/****************************************************
    文件：GateTrigger.cs
	作者：HKZ
    邮箱: 3046916186@qq.com
    日期：2022/11/6 12:51:13
	功能：Nothing
*****************************************************/

using System;
using UnityEngine;

namespace HKZ
{
    public class GateTrigger : MonoBehaviour
    {
        [SerializeField] private VoidEventChannel gateTriggeredEventChannel;
        [SerializeField] private AudioClip pickUpSFX;
        [SerializeField] private ParticleSystem pickUpVFX;

        //public event Action Delegate;

        private void OnTriggerEnter(Collider other)
        {
            //Delegate?.Invoke();
            //if (Delegate != null)
            //{
            //    Delegate.Invoke();
            //}

            gateTriggeredEventChannel.Broadcast(); 
            SoundEffectsPlayer.AudioSource.PlayOneShot(pickUpSFX);
            Instantiate(pickUpVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}