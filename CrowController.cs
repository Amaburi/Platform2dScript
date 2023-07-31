using UnityEngine;
using System.Collections;
public class CrowController : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed = 2f;
    public Animator animator;
    public PlayerController playerController; // Reference to the PlayerController script
    public bool isFly = false;
    private int currentWaypointIndex = 0;
    private bool isDead = false;
    private Collider2D crowCollider;
    

    private void Start()
    {
        crowCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        
        if (isDead)
        {
            // If the crow is dead, no need to update its behavior
            return;
        }

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
        animator.SetBool("IsFly", isFly);
        animator.SetBool("IsDeath", isDead);

        // Check for the player's attack and trigger crow's death if attacked
        
    }

    public void TakeDamage()
    {
        if (!isDead)
        {
            Debug.Log("Crow took damage.");
            // Set the crow's 'IsDeath' parameter to true and play the death animation
            animator.SetBool("IsDeath", true);
            crowCollider.enabled = false;
            // Stop the crow from flying
            isFly = false;
            animator.SetBool("IsFly", false);

            // Add any additional death behavior here (e.g., disable movement, destroy GameObject, etc.)

            // Mark the crow as dead
           
        }
    }

    public void FinishDeathAnimation()
    {
        // Reset the attack animation parameter to false when the attack animation finishes
        animator.SetBool("IsDeath", false);
        isDead = false;
    }
    public void SetIsDead(bool value)
    {
        isDead = value;
        animator.SetBool("IsDeath", value);
        Debug.Log("IsDead");
        
    }
}
