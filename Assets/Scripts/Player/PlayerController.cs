using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed = 15f;
    public float maxSpeed = 8f;
    public bool onGround = false;
    public float jumpForce = 350f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        Debug.Log(Input.GetAxis("Horizontal"));
    }

    private void HandleInput()
    {
        var velX = rigidbody2D.velocity.x;
        var velY = rigidbody2D.velocity.y;
        float z = 0f;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (Mathf.Abs(rigidbody2D.velocity.x) < maxSpeed)
            {
                //rigidbody2D.AddForce(Vector2.right * speed * Input.GetAxisRaw("Horizontal"));
				rigidbody2D.velocity = new Vector3(speed * Input.GetAxis("Horizontal"), rigidbody2D.velocity.y, z);
            }
        }
		//else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
		//{
		//	rigidbody2D.velocity = new Vector3(0f, rigidbody2D.velocity.y, z);
		//}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (rigidbody2D.velocity.y == 0)
        {
            onGround = true;
        }else
        {
            onGround = false;
        }
    }

    void Jump()
    {
        if (onGround == true)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce);
        }
    }
}
