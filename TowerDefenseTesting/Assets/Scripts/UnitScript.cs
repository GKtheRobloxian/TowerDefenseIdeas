using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    public float range;
    public float fireRate;
    public GameObject firePrefab;
    float fireRateInit;
    public float damage;
    int failCount;
    GameObject lookAtTarget;
    public GameObject[] withinRange;
    // Start is called before the first frame update
    void Start()
    {
        range = GetComponent<SphereCollider>().radius;
        fireRateInit = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        ObjectTracking();
        Shooting();
    }

    void ObjectTracking()
    {
        GameObject[] possibleTargets = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < withinRange.Length; i++)
        {
            if (withinRange[i] == null || (withinRange[i].transform.position - transform.position).magnitude > range)
            {
                withinRange[i] = GameObject.Find("Filler");
            }
        }
        for (int i = 0; i < possibleTargets.Length; i++)
        {
            if ((possibleTargets[i].transform.position - transform.position).magnitude > range)
            {
                failCount++;
            }
            else
            {
                withinRange[i - failCount] = possibleTargets[i];
            }
            if (i == possibleTargets.Length - 1)
            {
                failCount = 0;
            }
        }
        if (withinRange[0].CompareTag("Enemy"))
        {
            transform.LookAt(withinRange[0].transform.position);
        }
        else
        {
            transform.rotation = Quaternion.Euler(transform.localEulerAngles);
        }
    }

    void Shooting()
    {
        fireRate -= Time.deltaTime;
        if (fireRate <= 0 && withinRange[0].CompareTag("Enemy"))
        {
            withinRange[0].GetComponent<EnemyScript>().Damaged(damage);
            StartCoroutine(PrefabQuickEnable());
            fireRate = fireRateInit;
        }
    }

    IEnumerator PrefabQuickEnable()
    {
        firePrefab.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        firePrefab.SetActive(false);
    }
}
