using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class WateringCan : MonoBehaviour
{
    bool isWateringCanTilted = false;
    public OnTilt tilter;
    public Transform spout;

    public void OnEnable()
    {
        tilter.onBegin.AddListener(OnWateringCanTilted);
        tilter.onEnd.AddListener(OnWateringCanNotTilted);
    }

    public void OnDisable()
    {
        tilter.onBegin.RemoveListener(OnWateringCanTilted);
        tilter.onEnd.RemoveListener(OnWateringCanNotTilted);
    }

    //method called when watering can is tiltered
    public void OnWateringCanTilted()
    {
        isWateringCanTilted = true;

    }

    public void OnWateringCanNotTilted()
    {
        isWateringCanTilted = false;
    }
        
    // Update is called once per frame
    void Update()
    {
        if (isWateringCanTilted)
        {
            Debug.DrawRay(spout.position, Vector3.down, Color.red);

            RaycastHit hit;
            if(Physics.Raycast(spout.position, Vector3.down, out hit,100.0f))
            {
                if (hit.collider.GetComponent<SeedPlanter>() != null)
                {
                    hit.collider.GetComponent<SeedPlanter>().GrowPlant();
                }    
            }
        }
        
    }
}
