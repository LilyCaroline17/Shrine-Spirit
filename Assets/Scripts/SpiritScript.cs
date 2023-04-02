using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritScript : MonoBehaviour
{
    public float speed = 10;
    public Vector2 direction;
    private bool facingRight;
    public float walkSpeed;
    public float maxSpeed;
    public float increasedSpeed;
    private Rigidbody2D rb;
    private Vector3 lastVelocity = Vector3.zero;
    private Vector3 velocity;
    private enum Direction {front, back, left, right};
    private Direction orientation = Direction.front;
    private Animator anim;


    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        direction =Vector2.zero;
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetMouseButtonDown(0)) OnMouseDown();
        Move();
    }

    private void OnMouseDown()
    {
        direction=getMousePos() - (Vector2)transform.position;
        direction.Normalize();
    }

    //when screen is tapped, spirit will move towards the location
    // void move()
    // {
    //     float xmove = direction.x * speed;
    //     transform.position = new Vector3(direction.x * speed, direction.y * speed, 0.0f);
    //     // If the input is moving the player right and the player is facing left...
    //     if (xmove > 0 && !facingRight)
    //     {
    //         // ... flip the player.
    //         Flip();
    //     }
    //     // Otherwise if the input is moving the player left and the player is facing right...
    //     else if (xmove < 0 && facingRight)
    //     {
    //         // ... flip the player.
    //         Flip();
    //     }
    // }

    void OnGUI()
    {
        if (Event.current.Equals(Event.KeyboardEvent("up")) ||
            Event.current.Equals(Event.KeyboardEvent("w")))
        {
            anim.Play("Walking_Back");
            orientation = Direction.back;

        } else if(Event.current.Equals(Event.KeyboardEvent("down")) ||
            Event.current.Equals(Event.KeyboardEvent("s")))
        {
            anim.Play("Walking_Front");
            orientation = Direction.front;
        } else if(Event.current.Equals(Event.KeyboardEvent("right")) ||
            Event.current.Equals(Event.KeyboardEvent("d")))
        {
            anim.Play("Walking_Right");
            orientation = Direction.right;
        } else if(Event.current.Equals(Event.KeyboardEvent("left")) ||
            Event.current.Equals(Event.KeyboardEvent("a"))) {
            anim.Play("Walking_Left");
            orientation = Direction.left;
        }

        if(rb.velocity == Vector2.zero)
        {
            anim.Play("Idle");

        }

    
    }

    void Move()
    {
        Vector3 move;

      
        if(orientation == Direction.left || orientation == Direction.right)
        {
            move =  new Vector3(Input.GetAxis("Horizontal"),0,0);
        } else {
            move =  new Vector3(0, Input.GetAxis("Vertical"),0);
        
        }

        if (move.Equals(Vector3.zero))
        {
            // return to walking speed once not moving
            increasedSpeed = walkSpeed;

        }
        else
        {
            // increase speed while walking
            float potentialInc = increasedSpeed + 2.0f * Time.deltaTime;
            if (potentialInc > maxSpeed)
            {
                increasedSpeed = maxSpeed;
            }
            else
            {
                increasedSpeed = potentialInc;
            }
        }

    
        velocity = move * increasedSpeed;
        rb.velocity = velocity;
    }

    Vector2 getMousePos()
    { return (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition); 
    }

    private void Flip()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
    
}
