using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	public float speed = 6f;
	//public float maxSpeed = 8f;
	public bool onGround = false;
	public bool turnedRight = true;
	public float jumpForce = 350f;

	Rigidbody2D rigid;
	Transform trans;

	// Use this for initialization
	void Start()
	{
		rigid = this.GetComponent<Rigidbody2D>();
		trans = this.GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update()
	{
		HandleInput();
	}

	private void HandleInput()
	{

		rigid.velocity = new Vector3(speed * Input.GetAxisRaw("Horizontal"), rigid.velocity.y, 0f);

		//if (rigid.velocity.x != 0)
		//{
		//	anim.SetBool("Running", true);
		//}
		//else
		//{
		//	anim.SetBool("Running", false);
		//}

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
			//anim.SetBool("Jumping", true);
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		onGround = true;
		//anim.SetBool("Jumping", false);
	}
}
