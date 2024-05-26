using UnityEngine;
using UnityEngine.InputSystem;

public class PlantController : MonoBehaviour
{
    private PlayerControls playerControls;

    public GameObject plantPrefab; // Drag your plant prefab onto this field in the Unity Inspector
    public Transform spawnPoint;

    public void Awake()
    {
        playerControls = new PlayerControls();
        playerControls.Enable();

        playerControls.DesktopFarm.GrowPlants.started += value => 
        { 
            GrowPlant(); 
        };
    }

    public void OnCollisionEnter(Collision collision)
    {
        GrowPlant();
    }

    private void GrowPlant()
    {
        Debug.Log("Growing plant!");
        // Instantiate a new plant at the position of this GameObject
        GameObject newPlant = Instantiate(plantPrefab, spawnPoint.position, spawnPoint.rotation);
        // You may need to adjust the position and rotation as per your game's requirements

        // Optional: You can perform additional actions on the new plant GameObject here
    }
}