using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    //[SerializeField] private bool isSprinting = false; //is false by default, is true when left shift is pressed down.

    [SerializeField] private KeyCode sprintKey = KeyCode.LeftShift; //sprint key.

    [SerializeField] private float walkSpeed; //how fast Chamy walks.
    [SerializeField] private float sprintSpeed; //how fast Chamy sprints.
    [SerializeField] private float jumpSpeed; //how fast Chamy jumps.
    private Rigidbody2D body; //Chamy's rigid body.
    private Animator animator; //handles animations.
    private bool grounded; //keep track when player is on the ground or not.

    //Awake is called when the script instance is being loaded.
    private void Awake()
    {
        //Get references for rigidbody and animator from the object Chamy.
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    //Runs on every frame: checks for inputs and changes the state of the game during runtime.
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        bool sprintInput = Input.GetKey(sprintKey);

        if (sprintInput == true)
        {
            //Speed and direction at which Chamy is sprinting around.
            body.velocity = new Vector2(horizontalInput * sprintSpeed, body.velocity.y);
        }
        else
        {
            //Speed and direction at which Chamy is walking around.
            body.velocity = new Vector2(horizontalInput * walkSpeed, body.velocity.y);
        }

        //Flips the direction Chamy is facing horizontally. (Right or left)
        if(horizontalInput > 0.01f) //Chamy moves to the right.
        {
            transform.localScale = new Vector3(10, 10, 10);
        }
        if (horizontalInput < -0.01f) //Chamy moves to the left.
        {
            transform.localScale = new Vector3(-10, 10, 10);
        }

        //Jumping Chamy.
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();
        }

        //Set animator parameters
        animator.SetBool("walk", horizontalInput != 0 && sprintInput == false);
        animator.SetBool("sprint", horizontalInput != 0 && sprintInput == true);
        animator.SetBool("grounded", grounded == true);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpSpeed);
        animator.SetTrigger("jump");
        grounded = false;
    }

    //Checks if Chamy is on the ground (else is jumping).
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

}
