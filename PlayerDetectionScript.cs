using UnityEngine;

public class PlayerDetectionScript : MonoBehaviour
{
    // Reference to the crow GameObject to be affected
    public GameObject crow;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player has entered the trigger area
        if (other.CompareTag("Player"))
        {
            // Set isFly to true for the corresponding crow
            if (crow != null)
            {
                CrowController crowController = crow.GetComponent<CrowController>();
                if (crowController != null)
                {
                    crowController.isFly = true;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the player has exited the trigger area
        if (other.CompareTag("Player"))
        {
            // Set isFly to false for the corresponding crow
            if (crow != null)
            {
                CrowController crowController = crow.GetComponent<CrowController>();
                if (crowController != null)
                {
                    crowController.isFly = false;
                }
            }
        }
    }
}
