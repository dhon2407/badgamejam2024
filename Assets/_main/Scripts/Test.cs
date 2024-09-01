using Game.Main.DialogueSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Main
{
    [HideMonoScript]
    public class Test : MonoBehaviour
    {
        [SerializeField] private DialogueData testDialogue;
        
        [Button, HideInEditorMode]
        private void TestDialogue()
        {
            Dialogue.StartDialogue(testDialogue);
        }
    }
}