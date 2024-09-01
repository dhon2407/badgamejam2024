using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Yarn.Unity;

namespace Game.Main.DialogueSystem
{
    [RequireComponent(typeof(AudioSource))]
    [HideMonoScript]
    public class VoiceOverLineProvider : DialogueViewBase
    {
        [SerializeField, ReadOnly] private VoiceOverTable voiceOverTable;
        [SerializeField] private AudioSource audioSource;
        
        public void SetVoiceoverTable(VoiceOverTable voTable)
        {
            voiceOverTable = voTable;
        }
        
        private void Awake()
        {
            if (audioSource == null)
                audioSource = GetComponent<AudioSource>();

            audioSource.spatialBlend = 0f;
        }

        public override void RunLine(LocalizedLine dialogueLine, Action onDialogueLineFinished)
        {
            if (voiceOverTable == null)
            {
                Debug.LogError("Voice table was not set properly.");
                return;
            }
            
            AudioClip voiceClip = voiceOverTable.GetVoiceObject(dialogueLine.TextID) as AudioClip;

            if (voiceClip == null)
            {
                Debug.LogWarning($"No voice clip found for {dialogueLine.TextID}, check voiceover table if needed.");
                return;
            }
            
            if (audioSource.isPlaying)
                audioSource.Stop();
            
            audioSource.PlayOneShot(voiceClip);
        }
    }
}