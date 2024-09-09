using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnUnits : MonoBehaviour
{
    public GameObject unitToSpawn;
    public GameObject buttonUsed;
    public CurrencySetter currencySetter;
    public int currencyCost;
    public float yLevelSpawn = 0.225f;
    public bool spawnReady = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currencyCost > currencySetter.currentCurrency)
        {
            spawnReady = false;
            buttonUsed.GetComponent<Button>().interactable = true;
        }

        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0) && spawnReady)
        {
            if (Physics.Raycast(mouseRay, out hit, Mathf.Infinity, 1, QueryTriggerInteraction.Ignore))
            {
                if (hit.collider.gameObject.CompareTag("Placeable"))
                {
                    Instantiate(unitToSpawn, hit.point + Vector3.up * yLevelSpawn, Quaternion.identity);
                    buttonUsed.GetComponent<Button>().interactable = true;
                    currencySetter.ChangeCurrency(-currencyCost);
                    currencyCost = 0;
                    spawnReady = false;
                }
            }
        }

    }
}
