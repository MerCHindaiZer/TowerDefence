using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlingTower : MonoBehaviour
{
    GameObject enemy;
    public GameObject bullet;
    public int distance;
    private float countdown;
    public float time = 1.5f;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        Search();
        if (countdown <= 0f)
        {
            Fire();
            countdown = time;
        }
        countdown -= Time.fixedDeltaTime;


    }
    void Search()
    {
        if (!(enemy = GameObject.Find("Enemy(Clone)")))
        {
            Debug.Log(message: "Enemy do not find");
        }
    }
    void Fire()
    {
        if (Vector3.Distance(transform.position, enemy.transform.position) < distance)
        {
            Instantiate(bullet, transform.position, transform.rotation);

        }
    }
}
