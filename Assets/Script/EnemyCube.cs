using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCube : MonoBehaviour
{
    public float damage = 50;
    public float health = 100;
    public float damageFrequency = 1, damageTime;
    public bool isDead = false;

    GameObject object2Destroy = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            object2Destroy = GameObject.Find("EnemyCube");
            Destroy(object2Destroy);
        }
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
}
