using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Main.Sound
{
    [RequireComponent(typeof(AudioSource))]
    [HideMonoScript]
    public class NPCAudioSource : MonoBehaviour
    {
        [SerializeField, Required] private AudioSource audioSource;
        [SerializeField] private SpriteRenderer testImage;
        
        
        public Vector2 position => transform.position;

        private void Awake()
        {
            audioSource.volume = 0f;
        }
        
        public void SetInFullRange()
        {
            SetVolume(100f);
            testImage.color = Color.red;
        }

        public void SetDetected(bool isDetected)
        {
            SetVolume(isDetected ? 30f : 0f);
            testImage.color = isDetected ? Color.green : Color.white;
        }

        private void SetVolume(float volume)
        {
            audioSource.volume = Mathf.Clamp(volume, 0, 100f) / 100f;
        }
    }
}