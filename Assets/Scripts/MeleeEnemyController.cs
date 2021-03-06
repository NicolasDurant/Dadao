using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyController : MonoBehaviour
{
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;
    public float runSpeed = 40f;
    private float horizontalMove = 0f;
    private bool direction = true;
    public Animator animator;


    public void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(float move)
    {
        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
        // And then smoothing it out and applying it to the character
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

        // If the input is moving the player right and the player is facing left...
        if (move > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (move < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
    }

    private void FixedUpdate()
    {
        if(direction && horizontalMove < 15)
        {
            horizontalMove = horizontalMove + 0.2f;
        } else if (direction && horizontalMove > 15)
        {
            direction = false;
        } else if (!direction && horizontalMove > -15)
        {
            horizontalMove = horizontalMove - 0.2f;
        } else
        {
            direction = true;
        }
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        Move(horizontalMove * Time.fixedDeltaTime);
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
