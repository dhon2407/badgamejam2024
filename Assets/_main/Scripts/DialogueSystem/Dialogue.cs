using System;
using DMGToolBox.Managers;
using Game.Main.Settings;
using Sirenix.OdinInspector;
using UnityEngine;
using Yarn.Unity;

namespace Game.Main.DialogueSystem
{
    [RequireComponent(typeof(DialogueRunner))]
    [HideMonoScript]
    public class Dialogue : SingletonManager<Dialogue>
    {
        [SerializeField] private DialogueRunner dialogueRunner;
        [SerializeField] private VoiceOverLineProvider voiceOverLineProvider;
        
        /// <summary>
        /// Start dialogue
        /// </summary>
        /// <param name="dialogueData">Dialogue data</param>
        public static void StartDialogue(DialogueData dialogueData) => GetInstance().StartDialogueImpl(dialogueData);

        private bool _dialogueRunning;

        private static Dialogue GetInstance()
        {
            try
            {
                /* Getting this instance will throw an error if this object is not yet created */
                return Instance;
            }
            catch (Exception)
            {
                Debug.Log("Dialogue instance not found, initializing");
                /* Create the instance if it throws error */
                return GameSettings.Dialog.Instantiate().GetComponent<Dialogue>();
            }
        }
        
        /// <summary>
        /// Running yarn dialogue
        /// </summary>
        /// <param name="dialogueData">Dialogue data</param>
        private void StartDialogueImpl(DialogueData dialogueData)
        {
            if (_dialogueRunning)
            {
                Debug.LogWarning("Dialogue is still running, make sure you wait for the current dialogue before running another.");
                return;
            }
            
            voiceOverLineProvider.SetVoiceoverTable(dialogueData.VoiceOverTable);
            dialogueRunner.SetProject(dialogueData.YarnProject);
            dialogueRunner.StartDialogue(dialogueData.CurrentNode);

            _dialogueRunning = true;
        }
        
        /// <summary>
        /// Singleton initialization
        /// </summary>
        protected override void Init()
        {
            if (dialogueRunner == null)
                dialogueRunner = GetComponent<DialogueRunner>();
            
            dialogueRunner.onDialogueComplete.AddListener(DialogueCompleted);
        }

        /// <summary>
        /// Dialog complete function used as callback
        /// </summary>
        private void DialogueCompleted()
        {
            _dialogueRunning = false;
        }
    }
}


