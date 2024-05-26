using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedPlanter : MonoBehaviour
{
    //Variables type followed by name
    public SeedTypeEnum seedType = SeedTypeEnum.None;
    public Transform spawnPoint;
    public float shootForce = 10f; // The force to apply when shooting the plant vertically

    //Reference to seed plant
    public GameObject plantReference;

    //Reference to spawned object
    public GameObject spawnedPlantReference;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that hit is a seed or a watering can
        if ((other.GetComponent<SeedChoice>() != null) && (spawnedPlantReference == null))
        {
            // Seed is detected
            HandleSeedCollision(other);
        }
        else if (other.CompareTag("WaterBalloon"))
        {
            // Watering can is detected
            Debug.Log("Plant watered!");

            Destroy(other.gameObject);
            GrowPlant();
        }
    }

    private void HandleSeedCollision(Collider other)
    {
        Debug.Log("Seed planted: " + other.GetComponent<SeedChoice>().seedType.ToString());

        // Makes sure the object that hit is a seed
        SeedChoice seedChoice = other.GetComponent<SeedChoice>();

        // Saves seed type for future use
        seedType = seedChoice.seedType;
        plantReference = seedChoice.plantReference;

        // Destroy seed
        Destroy(other.gameObject);

        // Spawns mound of dirt

    }

    public void GrowPlant()
    {
        if ((plantReference != null) && (spawnedPlantReference == null))
        {
            Debug.Log("Growing plant!");
            
            // Instantiate a new plant at the position of this GameObject
            spawnedPlantReference = Instantiate(plantReference, spawnPoint.position, spawnPoint.rotation);
        }

        // Optional: You can perform additional actions on the new plant GameObject here
    }

    private void ResetGround()
    {
        plantReference = null;
        spawnedPlantReference = null;
    }


    private void OnMouseOver()
    {
        // Check if the mouse is over the plant and the mouse button is pressed
        if (Input.GetMouseButtonDown(0)) //left click on mouse
        {
            ShootPlantVertically();
        }
    }

    private void ShootPlantVertically()
    {
        //if there is a plant
        if (spawnedPlantReference != null)
        {
            // Apply vertical force to shoot the plant upwards
            spawnedPlantReference.GetComponent<Rigidbody>().AddForce(Vector3.up * shootForce, ForceMode.Impulse);

            ResetGround();
        }
    }
}
