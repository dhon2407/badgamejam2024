using Sirenix.OdinInspector;
using UnityEngine;
using Yarn.Unity;

namespace Game.Main.DialogueSystem
{
    [HideMonoScript]
    [CreateAssetMenu(fileName = "DialogueData", menuName = "DialogueSystem/Dialogue data", order = 0)]
    public class DialogueData : ScriptableObject
    {
        [Title("Yarn Data")]
        [SerializeField] protected YarnProject yarnProject;
        [SerializeField] protected string defaultStartingNode;
        
        [Title("Voice Over Table")]
        [SerializeField] protected VoiceOverTable voiceOverTable;

        public YarnProject YarnProject => yarnProject;
        public VoiceOverTable VoiceOverTable => voiceOverTable;
        public virtual string CurrentNode => defaultStartingNode;
    }
}