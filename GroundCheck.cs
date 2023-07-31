using System.Collections;
using System.Collections.Generic;


using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public LayerMask groundLayer;
    private bool isGrounded;

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(transform.position, 0.1f, groundLayer);
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }
}
