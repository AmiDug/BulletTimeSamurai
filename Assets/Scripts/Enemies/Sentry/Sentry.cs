using UnityEngine;
using System.Collections;

public class Sentry : MonoBehaviour
{
    GameObject player;
    public GameObject bullet;
    Vector3 bulletPosition;
    Rigidbody2D bulletRB;
    BulletTime bulletTime;
    public float timeLeft = 0.0f;
    public float timeToWait = 0.3f;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        bulletPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 0.35f, transform.localPosition.z);
        bulletTime = player.GetComponent<BulletTime>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            FireBullet();
        }

        if (timeLeft >= timeToWait)
        {
            FireBullet();
            timeLeft = 0f;
        }
        timeLeft += Time.deltaTime;
    }

    void FireBullet()
    {
        GameObject firedBullet = GameObject.Instantiate(bullet, bulletPosition, new Quaternion(0f, 0f, 0f, 0f)) as GameObject;

        bulletRB = firedBullet.GetComponent<Rigidbody2D>();
        bulletRB.AddForce((Vector2.right * -bulletTime.bulletSpeed) * transform.localScale.x);
        
    }
}
