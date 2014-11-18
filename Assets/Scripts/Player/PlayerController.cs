using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	public float speed = 6f;
	//public float maxSpeed = 8f;
	public bool onGround = false;
	public float jumpForce = 350f;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void FixedUpdate() // R U SRS IT WAS SERIOUSLY ONLY TO ENABLE INTERPOLATION
	{
		HandleInput();
	}

	private void HandleInput()
	{

		rigidbody2D.velocity = new Vector3(speed * Input.GetAxisRaw("Horizontal"), rigidbody2D.velocity.y, 0f);

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Jump();
		}
	}

	void Jump()
	{
		if (onGround == true)
		{
			rigidbody2D.AddForce(Vector2.up * jumpForce);
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		onGround = true;
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		onGround = false;
	}
}
