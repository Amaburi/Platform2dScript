using UnityEngine;

public class CrowController : MonoBehaviour
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
            Debug.LogWarning("No waypoints assigned to CrowController script on " + gameObject.name);
            return;
        }

        // If the player is nearby and isFly is true, move towards the current waypoint
        if (isFly)
        {
            Vector3 targetPosition = waypoints[currentWaypointIndex].position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Check if the crow has reached the current waypoint
            if (transform.position == targetPosition)
            {
                // Move to the next waypoint
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            }
        }

        // Control the animation state
        if (animator != null)
        {
            animator.SetBool("IsFly", isFly);
        }
    }
}
