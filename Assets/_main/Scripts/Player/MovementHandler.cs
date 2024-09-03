using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Main.Player
{
    [HideMonoScript]
    public class MovementHandler : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D rb;
        
        [SerializeField]
        private float moveSpeed = 5f; 

        public bool Enabled { get; set; }
        
        private Vector2 _movement;

        private void Update()
        {
            if (!Enabled)
                return;
            
            _movement.x = Input.GetAxisRaw("Horizontal");
            _movement.y = Input.GetAxisRaw("Vertical");

            rb.MovePosition(rb.position + _movement * (moveSpeed * Time.fixedDeltaTime));
        }
    }
}