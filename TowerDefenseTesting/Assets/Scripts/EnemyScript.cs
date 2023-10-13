using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public float speed;
    public GameObject[] turnPoints;
    int currentTarget = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject targeting = turnPoints[currentTarget];
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.LookAt(new Vector3(targeting.transform.position.x, transform.position.y, targeting.transform.position.z));
        if ((transform.position - new Vector3(targeting.transform.position.x, transform.position.y, targeting.transform.position.z)).magnitude < 0.001f)
        {
            currentTarget++;
        }
    }
}
