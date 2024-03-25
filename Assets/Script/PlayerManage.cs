using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManage : MonoBehaviour
{

    public float health = 100;
    public float damage = 50;
    public bool isDead = false;
    public float damageFrequency = 1, damageTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getDamage(float damage)
    {
        if (health - damage > 0 && damageTime < Time.timeSinceLevelLoad) 
        {
            damageTime = damageFrequency + Time.timeSinceLevelLoad;
            health -= damage;
        }
        else
        {
            health = 0;
            isDead = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "TriggerZone")
        {
            collision.GetComponent<EnemyCube>().getDamege(damage);
        }
    }
}
