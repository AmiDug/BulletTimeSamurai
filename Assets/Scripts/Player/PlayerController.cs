using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 80f;
	public float maxSpeed = 9f;
	public float jumpForce = 350f;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		HandleInput();
	}

	private void HandleInput()
	{
		var velX = rigidbody2D.velocity.x;
		var velY = rigidbody2D.velocity.y;

		if (rigidbody2D.velocity.x < maxSpeed)
		{
			if (Input.GetKey(KeyCode.D))
			{
				rigidbody2D.AddForce(Vector2.right * speed * Input.GetAxis("Horizontal"));
			}
		}

		if (rigidbody2D.velocity.x > -maxSpeed)
		{
			if (Input.GetKey(KeyCode.A))
			{
				rigidbody2D.AddForce(Vector2.right * speed * Input.GetAxis("Horizontal"));
			} 
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			rigidbody2D.AddForce(Vector2.up * jumpForce);
		}

	}
}
