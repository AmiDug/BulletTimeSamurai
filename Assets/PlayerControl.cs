using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour 
{
    public GameObject input;
    public float force = 15f;

	// Use this for initialization
	void Start () 
	{
        
	}
	
	// Update is called once per frame
	void Update () 
	{
        //var posX = transform.position.x;
        //var posY = transform.position.y;

	    if(Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody2D.AddForce(Vector2.right * force * -0.5f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody2D.AddForce(Vector2.right * force * 0.5f);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigidbody2D.AddForce(Vector2.up * force * 0.5f);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rigidbody2D.AddForce(Vector2.up * force * -0.5f);
        }
	}
}
