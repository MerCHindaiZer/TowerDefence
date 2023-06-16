using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bull : MonoBehaviour
{
    GameObject enemy;
    public float speed;
    public int dmg;

    void Start()
    {

    }

    void Update()
    {
        enemy = GameObject.Find("Enemy(Clone)");

        if (Vector3.Distance(transform.position, enemy.transform.position) <= 1)
        {
            Destroy(gameObject);
            enemy.GetComponent<Enemy>().HP -= dmg;
            
        }
        else
        {
            Vector3 dir = enemy.transform.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        }
        
    }    
}
