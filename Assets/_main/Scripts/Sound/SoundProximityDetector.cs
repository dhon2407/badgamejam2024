using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Main.Sound
{
    [HideMonoScript]
    public class SoundProximityDetector : MonoBehaviour
    {
        [SerializeField] private float detectionRange;
        [SerializeField] private float completeRange;
        [SerializeField] private LayerMask layerTarget;

        private readonly Collider2D[] _detections = new Collider2D[10];

        private readonly List<NPCAudioSource> _currentSources = new(); 
        private readonly List<NPCAudioSource> _detectedSources = new(); 
        private readonly List<NPCAudioSource> _onCloseRange = new(); 
        
        private void Update()
        {
            int detectedSize = Physics2D.OverlapCircleNonAlloc(transform.position, detectionRange, _detections, layerTarget);
            if (detectedSize == 0)
                return;
            
            _onCloseRange.Clear();
            _detectedSources.Clear();
            for (int i = 0; i < detectedSize; i++)
                AddSources(_detections[i].GetComponent<NPCAudioSource>());

            /* Clear undetected sources */
            foreach (NPCAudioSource source in _currentSources)
            {
                if (!_detectedSources.Contains(source))
                    source.SetDetected(false);
            }
            
            _currentSources.Clear();
            foreach (NPCAudioSource detectedSource in _detectedSources)
                _currentSources.Add(detectedSource);
            
            foreach (NPCAudioSource detectedSource in _currentSources)
            {
                detectedSource.SetDetected(true);
                if (Vector2.Distance(transform.position, detectedSource.position) < completeRange)
                    _onCloseRange.Add(detectedSource);
            }

            if (_onCloseRange.Count == 0)
                return;

            NPCAudioSource closestAudio = _onCloseRange[0];
            if (_onCloseRange.Count > 1)
            {
                for (int i = 1; i < _onCloseRange.Count; i++)
                {
                    if (Vector2.Distance(transform.position, _onCloseRange[i].position) <
                        Vector2.Distance(transform.position, _onCloseRange[i - 1].position))
                        closestAudio = _onCloseRange[i];

                }
            }
            closestAudio.SetInFullRange();
        }
        
        private void AddSources(NPCAudioSource npcAudioSource)
        {
            if (npcAudioSource == null)
                return;
            
            _detectedSources.Add(npcAudioSource);
        }


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position,detectionRange);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position,completeRange);
        }
    }
}