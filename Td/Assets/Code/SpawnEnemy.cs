using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SpawnEnemy : MonoBehaviour
{
    public Transform prefab;
    public float time = 5f;
    private float countdown;
    int lenght = 0;
    public float TotalTime;
    bool TimeIsOut = false;
    //public TextMeshProUGUI timeText;
 

    void Update()
    {
        //timeText.SetText(TotalTime.ToString());
        if (!TimeIsOut)
        {
            if (lenght != 600)
            {
                if (countdown <= 0f)
                {
                    spawnEnemy();
                    countdown = time;
                    lenght++;

                }

            }
            else
            {
                countdown = 30f;
                lenght = 0;
            }
            TotalTime -= Time.deltaTime;
        }
        if (TotalTime <= 0f)
        {
            TimeIsOut = true;
            TotalTime = 0.00f;
        }
            
            countdown -= Time.fixedDeltaTime;
    }
    void spawnEnemy()
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }
};