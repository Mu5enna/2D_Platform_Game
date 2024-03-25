using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCube : MonoBehaviour
{
    Rigidbody2D cubeRB;
    public float damage = 50;
    public float health = 100;
    public float damageFrequency = 1, damageTime;
    public bool isDead = false;
    public float distance = 4, speed = 3;
    float preSpeed;
    Vector3 startPos;

    GameObject object2Destroy = null;

    // Start is called before the first frame update
    void Start()
    {
        cubeRB = GetComponent<Rigidbody2D>();
        startPos = cubeRB.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            object2Destroy = GameObject.Find("EnemyCube");
            Destroy(object2Destroy);
            Application.Quit();
        }
        HorizontalMove();
        preSpeed = cubeRB.velocity.x;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerManage>().getDamage(damage);
        }
    }

    public void getDamege(float damage)
    {
        if (health - damage >= 0 && damageTime < Time.timeSinceLevelLoad) 
        {
            damageTime = Time.timeSinceLevelLoad + damageFrequency;
            health -= damage;
        }
        else
        {
            health = 0;
            isDead = true;
        }
    }

    public void HorizontalMove()
    {
        if (cubeRB.position.x <= startPos.x)
        {
            cubeRB.velocity = new Vector2(speed, 0);
        }
        else if (cubeRB.position.x >= startPos.x + distance)
        {
            cubeRB.velocity = new Vector2(-speed, 0);
        }
        else
        {
            cubeRB.velocity = new Vector2(preSpeed, 0);
        }
    }
}