using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleProximityDetector : MonoBehaviour
{
    [SerializeField] private float detectionRange;
    [SerializeField] private float OuterRange;
    [SerializeField] private LayerMask layerTarget;

    private void Update()
    {
        /*
         
        Collider2D outsideRange = Physics2D.OverlapCircle(transform.position, detectionRange, layerTarget);

        if(detectedNPC != null)
        {
            return;
        }

        // optimize later when i can research more about physics2D

        Collider2D

        for (int i = 0; i < detectedNPC.Length; i++)
        {
            detectedNPC
        }
        // Get first collision
        // Get its text bubble

        // If inside range, perform DetectInsideRange and skip outside range
        // use the open bubble function

        // if outer range
        // use the hide bubble function
        */

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, OuterRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
