using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

namespace Game.Main.DialogueSystem
{
    /// <summary>
    /// Dialogue background handling class
    /// </summary>
    [HideMonoScript]
    public class BackgroundHandler : DialogueViewBase
    {
        [SerializeField] private Image rayCastBlocker;

        public override void DialogueStarted()
        {
            /* Show the object */
            transform.localScale = Vector3.one;
            
            /* Enable to block raycast to other UI element other than dialogue */
            rayCastBlocker.raycastTarget = true;
        }

        public override void DialogueComplete()
        {
            /* Hide the object */
            transform.localScale = Vector3.zero;
            
            /* Disable blocking raycast */
            rayCastBlocker.raycastTarget = false;
        }
    }
}