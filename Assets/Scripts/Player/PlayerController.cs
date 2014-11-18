using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	public float speed = 6f;
	//public float maxSpeed = 8f;
	public bool onGround = false;
	public bool canDash = false;
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
		float axisV = Input.GetAxisRaw("Vertical");
		float axisH = Input.GetAxisRaw("Horizontal");

		if (onGround)
		{
			rigidbody2D.AddForce(Vector2.up * jumpForce);
		}
		else if (!onGround && canDash)
		{
			rigidbody2D.velocity = new Vector3(0f, 0f, 0f);

			rigidbody2D.AddForce(Vector2.up * 500f * axisV);
			rigidbody2D.AddForce(Vector2.right * 250f * axisH);

			canDash = false;
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		onGround = true;
		canDash = true;
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		onGround = false;
	}
}
