using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonForUnits : MonoBehaviour
{
    public GameObject towerSpawn;
    public GameObject objManagingUnits;
    public int cost;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUnitToSpawn()
    {
        objManagingUnits.GetComponent<SpawnUnits>().unitToSpawn = towerSpawn;
        objManagingUnits.GetComponent<SpawnUnits>().spawnReady = true;
        objManagingUnits.GetComponent<SpawnUnits>().buttonUsed = gameObject;
        GetComponent<Button>().interactable = false;
        objManagingUnits.GetComponent<SpawnUnits>().currencyCost = cost;
    }
}
