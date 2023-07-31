using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed = 2f;
    public bool isFly = false;

    private int currentWaypointIndex = 0;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogWarning("No waypoints assigned to CrowEnemy script.");
            return;
        }

        // Move towards the current waypoint
        Vector3 targetPosition = waypoints[currentWaypointIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Check if the NPC has reached the current waypoint
        if (transform.position == targetPosition)
        {
            // Move to the next waypoint
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;

            // Set IsFly to true when reaching a waypoint
            isFly = true;
        }

        // Control the animation state
        if (animator != null)
        {
            animator.SetBool("IsFly", isFly);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the crow has collided with a waypoint
        if (other.CompareTag("Waypoint"))
        {
            // Set IsFly to true when colliding with a waypoint
            isFly = true;
        }
    }
}
