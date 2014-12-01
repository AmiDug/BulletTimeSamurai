using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	PlayerEventHandler eventHandler;

	public float speed = 6f;
	//public float maxSpeed = 8f;
	public bool onGround = false;
	public static bool turnedRight = true;
	public float jumpForce = 350f;

	Rigidbody2D rigid;
	Transform trans;

	void Start()
	{
		eventHandler = this.GetComponent<PlayerEventHandler>();
		rigid = this.GetComponent<Rigidbody2D>();
		trans = this.GetComponent<Transform>();
	}

	void Update()
	{
		HandleInput();
	}

	private void HandleInput()
	{

		rigid.velocity = new Vector3(speed * Input.GetAxisRaw("Horizontal"), rigid.velocity.y, 0f);

		if (Input.GetAxisRaw("Horizontal") < 0 && turnedRight)
		{
			Flip();
		}

		if (Input.GetAxisRaw("Horizontal") > 0 && !turnedRight)
		{
			Flip();
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Jump();
		}

		if (Input.GetMouseButtonDown(0))
		{
			eventHandler.Attack_1();
		}
	}

	void Flip()
	{
		turnedRight = !turnedRight;
		trans.localScale = new Vector3(trans.localScale.x * -1, trans.localScale.y, trans.localScale.z);
	}

	void Jump()
	{
		if (onGround && rigid.velocity.y == 0)
		{
			onGround = false;
			rigid.AddForce(Vector2.up * jumpForce);
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		onGround = true;
	}
}
