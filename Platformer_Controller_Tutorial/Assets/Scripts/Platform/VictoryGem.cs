/****************************************************
    文件：VictoryGem.cs
	作者：HKZ
    邮箱: 3046916186@qq.com
    日期：2022/11/6 12:57:27
	功能：Nothing
*****************************************************/

using UnityEngine;

namespace HKZ
{
    public class VictoryGem : MonoBehaviour
    {
        [SerializeField] private VoidEventChannel levelClearedEventChannel;
        [SerializeField] private AudioClip pickUpSFX;
        [SerializeField] private ParticleSystem pickUpVFX;

        private void OnTriggerEnter(Collider other)
        {
            levelClearedEventChannel.Broadcast();
            SoundEffectsPlayer.AudioSource.PlayOneShot(pickUpSFX);
            Instantiate(pickUpVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}