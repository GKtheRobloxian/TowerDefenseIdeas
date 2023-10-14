using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float health;
    public float speed;
    public float distance;
    public GameObject[] turnPoints;
    int currentTarget = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTarget > turnPoints.Length-1)
        {
            GameObject.Find("Management").GetComponent<HealthManager>().UpdateValue(health);
            Destroy(gameObject);
        }
        else
        {
            GameObject targeting = turnPoints[currentTarget];
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            transform.LookAt(new Vector3(targeting.transform.position.x, transform.position.y, targeting.transform.position.z));
            if ((transform.position - new Vector3(targeting.transform.position.x, transform.position.y, targeting.transform.position.z)).magnitude < 0.01f)
            {
                currentTarget++;
            }
            distance += Time.deltaTime * speed;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Damaged(float damageTaken)
    {
        health -= damageTaken;
    }
}
