using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject[] points;
    public float speed = 10f;
    private GameObject target;
    private int wavepointIndex = 0;
    public int HP;

    void Start()
    {

        /*for (int i = 0; i < 8; i++) {
            if (!(points[i] = GameObject.Find("WP" + i)))
                Debug.Log(message: "WP" + i + " do not find");
        }*/
        target = points[0];
        HP = 200;
    }
    void Update()
    {
        Vector3 dir = target.transform.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.transform.position) <= 0.3f)
        {
            GetNextWaypoint();
        }
        if (HP == 0)
            Die();
    }
    void GetNextWaypoint()
    {
        if (wavepointIndex >= points.Length - 1)
        {
            Die();
            return;
        }
        wavepointIndex++;
        target = points[wavepointIndex];
    }
    public void Die()
    {
        Destroy (gameObject);
    }
};