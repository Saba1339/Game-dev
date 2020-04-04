using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	// This is a reference to the Rigidbody component called "rb"
	public Rigidbody rb;

	public float forwardForce = 2000f;	// Variable that determines the forward force
	public float sidewaysForce = 500f;  // Variable that determines the sideways force
    private float screenWidth;
    // We marked this as "Fixed"Update because we
    // are using it to mess with physics.

    private void Start()
    {
        screenWidth = Screen.width / 2;
    }



    void FixedUpdate ()
	{
		// Add a forward force
		rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.position.x > screenWidth)  // If the player is pressing the "d" key
            {
                // Add a force to the right
                rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }

            else if (touch.position.x < screenWidth)  // If the player is pressing the "a" key
            {
                // Add a force to the left
                rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
        }
        if (rb.position.y < -1f)
		{
			FindObjectOfType<GameManager>().EndGame();
		}
	}
}
