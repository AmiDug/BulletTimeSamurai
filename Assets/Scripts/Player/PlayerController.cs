using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	PlayerEventHandler eventHandler;

	public float speed = 6f;
	public bool turnedRight = true;
	public float jumpForce = 150f;

	Rigidbody2D rigid;
	Transform trans;

	void Start()
	{
		eventHandler = this.GetComponent<PlayerEventHandler>();
		rigid = this.GetComponent<Rigidbody2D>();
        trans = this.GetComponent<Transform>();

	}

	void FixedUpdate()
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

	

	void OnCollisionStay2D(Collision2D coll)
	{
        
        if (coll.gameObject.name == "Ground" && (Input.GetKey(KeyCode.Space)))
        {
            rigidbody2D.AddForce(Vector3.up * jumpForce);
        }
	}
}
