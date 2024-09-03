using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Main.Player
{
    [HideMonoScript]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private MovementHandler movement;

        private void Start()
        {
            movement.Enabled = true;
        }
    }
}