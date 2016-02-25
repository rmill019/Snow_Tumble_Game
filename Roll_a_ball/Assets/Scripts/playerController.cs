using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerController : MonoBehaviour 
{
	public float speed;
	public Text countText;
	public Text winText;
	public float jumpIntensity;

	//private bool jumping;
	private Rigidbody rb;
	private int count;
	private float playerScale = 0.1f;

	//private float jumpSpeed;


	// Use this for initialization
	void Start () 
	{
		transform.position = new Vector3 (0.353f, 5.348f, -4.678f);
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
		//jumpSpeed = 5.0f;
	
	}
		


	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);


		// Add force is a method available to the Rigidbody class
		rb.AddForce (movement * speed);
		playerJump ();
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			count++;
			SetCountText ();
		}

		if (other.gameObject.CompareTag ("Gain Size")) 
		{
			transform.localScale += new Vector3 (playerScale, playerScale, playerScale);
		}

	}

	// Lines 67 - 74 decrease object size. However the player continues to decrease in size
	// if they remain in contact with the Collision object
	void OnCollisionEnter(Collision collision)
	{
		foreach (ContactPoint contact in collision.contacts) 
		{
			if (collision.gameObject.CompareTag ("Lose Size")) 
				transform.localScale -= new Vector3 (playerScale, playerScale, playerScale);
		}
	}


	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 13) 
		{
			winText.text = "You Win!!";
		}
	}

	void playerJump()
	{
		if (Input.GetKeyDown ("space") || Input.GetKeyDown ("joystick button 0"))
		{
			Vector3 jump = new Vector3 (0.0f, jumpIntensity, 0.0f);
			rb.AddForce (jump);
			// Ball jumps even when on the air. Needs to be fixed.
		}
	}


}
