using UnityEngine;

public class PlayerController : MonoBehaviour
{
	    public float speed = 3.0f;
	    public float friction = 17.5f;
	    public GameObject player;
	    public Rigidbody m_Rigidbody;
	    // This vector is used to store the player's actual velocity
	    private Vector3 velocity = Vector3.zero;

	    // Update is called once per frame
	    void Update()
	    {
		    // These should be Either 1 or -1. They're floats to support controller or gyro input.
		    float vert = Input.GetAxis("Vertical");
		    float horiz = Input.GetAxis("Horizontal");
		    // This is how I check if you're actually moving.
		    // The transform information is duplicated, with positive or negative values of 1 representing the translation direction
		    // When magnitude is greater than zero, you pressed a button. 
		    Vector3 direction = new Vector3(horiz, 0, vert);

		    if (direction.magnitude > 0)
		    {
			    // Direction * Speed * Time since last fram (Seconds)
			    velocity += direction * speed * Time.deltaTime;
			    // Speed limit!
			    velocity = Vector3.ClampMagnitude(velocity, 20.0f);
		    }
		    else
		    {
			    // Deceleration is still ongoing.
			    velocity = velocity.normalized * friction * Time.deltaTime;
			    if (velocity.magnitude < 0.1f)
			    {
				    velocity = Vector3.zero;
			    }
		    }
		    transform.position += velocity * Time.deltaTime;
	    }
}
