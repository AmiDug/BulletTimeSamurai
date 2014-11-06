using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        var camPos = transform.position;
        var camPosX = transform.position.x;
        var camPosY = transform.position.y;
        var playerPosX = player.transform.position.x;
        var playerPosY = player.transform.position.y;

        while (camPosX != playerPosX)
        {
            camPos = new Vector3(Mathf.Lerp(camPosX, playerPosX, 1f), camPosY, transform.position.z);
        }
	}
}
