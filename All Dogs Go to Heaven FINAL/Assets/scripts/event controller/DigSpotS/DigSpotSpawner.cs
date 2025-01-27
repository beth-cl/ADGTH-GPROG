using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigSpotSpawner : MonoBehaviour
{
    public GameObject digSpotPrefab; // Prefab for the dig spot GameObject
    public Transform spawnArea; // The area where dig spots should be spawned
    public int maxSpawns = 10; // Maximum number of dig spots to spawn

    private int currentspawns = 0; //Current no of spots on screen

    public Material[] materials;
    public string[] DigSpotType = { "", "", "" };

    //int prevDSID = -1;
    

    // Start is called before the first frame update
    void Start()
    {
        SpawnDigSpots();

        EventController.OnCloneDestroyed += SpawnNewDigSpot;
    }

    private void OnDestroy()
    {

        EventController.OnCloneDestroyed -= SpawnNewDigSpot;
    }

    private void SpawnDigSpots()
    {
        for (int i = 0; i < maxSpawns; i++)
        {
            //AssignSpotType();
            SpawnNewDigSpot();
        }
    }

    private void SpawnNewDigSpot()
    {
        // Calculate a random spawn position within the spawn area
        Vector3 randomPosition = new Vector3(
            Random.Range(spawnArea.position.x - 50f, spawnArea.position.x + 50f), // X
            spawnArea.position.y, // Y (flat ground)
            Random.Range(spawnArea.position.z - 50f, spawnArea.position.z + 50f) // Z
        );

        DigSpotType = ID_strings.AssignSpotType();
        

        // Instantiate a new dig spot at the calculated position
        GameObject newDigSpot = Instantiate(digSpotPrefab, randomPosition, Quaternion.identity);

        Material digSpotMaterial = GetMaterial(DigSpotType[2]);
        Renderer renderer = newDigSpot.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material = digSpotMaterial;
            //renderer.material = GetMaterial(DigSpotType[2]);

        }
        else
        {
            Debug.LogWarning("Renderer not found on the dig spot prefab.");
        }

        //newDigSpot.name = "DigSpot_" + (i + 1); // Ensure unique names
        EventController.ObjectCloned(newDigSpot);

        currentspawns++;
    }


    private Material GetMaterial(string S_MatID)
    {
        if (!int.TryParse(S_MatID, out int I_MatID))
        {
            Debug.LogError($"Failed to parse S_MatID: {S_MatID} to an integer.");
            return null; // Return null to avoid further errors
        }

        if (I_MatID < 0 || I_MatID >= materials.Length)
        {
            Debug.LogError($"Material ID {I_MatID} is out of bounds. Array length: {materials.Length}");
            return null; // Return null to avoid further errors
        }

        return materials[I_MatID];
    }

}

