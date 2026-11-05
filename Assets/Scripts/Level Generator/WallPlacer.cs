
using UnityEngine;
using FloorPlacement;


public class WallPlacer : GeneratorScript
{
    // Subscribe to the floor generation event when the script is enabled.
    private void OnEnable()
    {
        FloorPlacer.OnFloorGenerationComplete += Generate;
    }
    // Unsubscribe from the floor generation event when the script is disabled.
    private void OnDisable()
    {
        FloorPlacer.OnFloorGenerationComplete -= Generate;
    }
    // This method is called when the floor generation is complete.
    public override void Generate()
    {
        UpdateWalls();
    }
    // This method handles the wall generation logic.
    private void UpdateWalls()
    {
        // Check if the wall prefab is assigned.
        if (prefab == null)
        {
            // Log a warning if no wall prefab is assigned and exit the method.
            Debug.LogWarning(
                "WallPlacer: No wall prefab is assigned.", this);
            return;
        }

        // Clear previously generated walls.
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            // Get the child wall GameObject at index i.
            GameObject wall = transform.GetChild(i).gameObject;
            // Destroy the wall GameObject based on whether the application is playing or in the editor.
            if (Application.isPlaying)
            {
                Destroy(wall);
            }
            // Destroy the wall GameObject immediately in the editor to avoid issues with the editor's undo system.
#if UNITY_EDITOR
            else
            {
                DestroyImmediate(wall);
            }
#endif
        }

        // Randomly decide whether a wall should spawn.
        bool spawnWall = Random.Range(0, 2) == 1;
        // If spawnWall is true, instantiate the wall prefab at the current position and rotation of the WallPlacer.
        if (spawnWall)
        {
            Instantiate(
                prefab,
                transform.position,
                transform.rotation,
                transform
            );
        }
        // If spawnWall is false, log a message indicating that no wall was spawned at the current position.
        else
        {
            Debug.Log(
                "No wall spawned at " + transform.position);
        }
    }
}
