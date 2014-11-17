using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour
{

    public GameObject player;
    public float X = 0.05f;

    // Use this for initialization
    void Start()
    {
        var playerPosX = player.transform.position.x;
        var playerPosY = player.transform.position.y;

        this.transform.localPosition = new Vector3(playerPosX, playerPosY, this.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        MoveCam(player.transform.localPosition.x, player.transform.localPosition.y);
    }

    public void MoveCam(float posX, float posY)
    {
        float camPosX = transform.localPosition.x;
        float camPosY = transform.localPosition.y;

        float offsetY = camPosY - posY;

        this.transform.localPosition = new Vector3(Mathf.Lerp(camPosX, posX, X), (camPosY - offsetY) * 0.55f, transform.localPosition.z);
    }
}
