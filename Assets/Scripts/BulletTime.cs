using UnityEngine;
using System.Collections;

public class BulletTime : MonoBehaviour
{
    public float bulletTime = 100.0f;
    public bool bulletTimeOn = false;
    public float bulletTimeScale = 0.15f;
    public float bulletSpeed = 20000f;
    bool debugMode = true;

    GameObject player;
    PlayerController playerC;
    Rigidbody2D playerR;
    GameObject mainCam;
    Bullet bullet;
    PlayerController walkSpeed;
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        playerC = player.GetComponent<PlayerController>();
        playerR = player.GetComponent<Rigidbody2D>();
        mainCam = GameObject.Find("MainCamera");
        bullet = GetComponent<Bullet>();
        walkSpeed = GetComponent<PlayerController>();
        StartCoroutine(DrainBulletTime());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (!bulletTimeOn)
            {
                StartBulletTime();
            }
            else
            {
                StopBulletTime();
            }
        }
    }

    void StartBulletTime()
    {
        if (bulletTime > 0)
        {
            bulletTimeOn = true;
            bulletSpeed /= 8f;
        }
        else
        {
            Debug.Log("no BT left");
        }
    }

    void StopBulletTime()
    {
        bulletTimeOn = false;

        bulletSpeed *= 8f;
    }

    void OnGUI()
    {
        GUI.TextArea(new Rect(10.0f, 10.0f, 70.0f, 20.0f), bulletTime.ToString() + ", " + bulletTimeOn.ToString());
    }

    IEnumerator DrainBulletTime()
    {
        if (debugMode == false)
        {
            while (true)
            {
                if (bulletTimeOn)
                {
                    if (bulletTime > 0 && bulletTime <= 100)
                    {
                        bulletTime--;
                    }
                    else if (bulletTime <= 0)
                    {
                        StopBulletTime();
                        Debug.Log("no BT left");
                    }

                    yield return new WaitForSeconds(0.005f);
                }

                yield return 0;
            }
        }
    }
}
