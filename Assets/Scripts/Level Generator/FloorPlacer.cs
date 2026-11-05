
using System;
using UnityEngine;


namespace FloorPlacement
{
    // This script is responsible for placing floor prefabs in a grid pattern.
    public class FloorPlacer : GeneratorScript
    {
        // Event to notify when floor generation is complete.
        public static event Action OnFloorGenerationComplete;

        // Placement settings for the floor grid.
        [Header("Placement Settings")]
        [SerializeField, Min(0)] private int numberOfFloorsX;
        [SerializeField, Min(0)] private int numberOfFloorsZ;

        // Spacing between floors in the X and Z directions.
        [SerializeField] private float spacingX = 10f;
        [SerializeField] private float spacingZ = 10f;

        // Start is called before the first frame update.
        private void Start()
        {
            // Generate the floor grid when the game starts.
            Generate();
        }

        // This method is called to generate the floor grid.
        public override void Generate()
        {
            // Update the floor grid based on the current settings.
            UpdateFloors();
        }

        // This method handles the logic for updating the floor grid.
        private void UpdateFloors()
        {
            // Check if the floor prefab is assigned.
            if (prefab == null)
            {
                // Log an error if no floor prefab is assigned and exit the method.
                Debug.LogError(
                    "FloorPlacer: No floor prefab is assigned.", this);
                return;
            }
            // Ensure that the number of floors in each direction is non-negative.
            int countX = Mathf.Max(0, numberOfFloorsX);
            int countZ = Mathf.Max(0, numberOfFloorsZ);

            // Rebuild the floor grid based on whether the application is playing or in the editor.
            if (Application.isPlaying)
            {
                
                RebuildRuntimeFloors(countX, countZ);
            }
            // In Edit Mode, update the existing floors and create only missing ones.
#if UNITY_EDITOR
            else
            {
                UpdateEditorPreview(countX, countZ);
            }
            // In Edit Mode, mark the scene as dirty to ensure changes are saved.
#endif

            // Notify the wall generator only after floor generation.
            OnFloorGenerationComplete?.Invoke();
        }

        // Calculate the position of a floor based on its grid coordinates.
        private Vector3 GetFloorPosition(int x, int z)
        {
            // Calculate the position of a floor based on its grid coordinates.
            return transform.position
                + new Vector3(x * spacingX, 0.5f, z * spacingZ);
        }
        
        // Get a random rotation for a floor.
        private Vector3 GetRandomRotation()
        {
            // Randomly select one of four possible rotations (0, 90, 180, 270 degrees) for the floor.
            return UnityEngine.Random.Range(0, 4) switch
            {
                0 => new Vector3(0, 90, 0),
                1 => new Vector3(0, 180, 0),
                2 => new Vector3(0, 270, 0),
                _ => Vector3.zero
            };
        }

        // Rebuild the floor grid during runtime by destroying existing floors and creating new ones.
        private void RebuildRuntimeFloors(int countX, int countZ)
        {
            // This generator's children must be generated floors only.
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                // Destroy existing floor GameObjects to rebuild the grid.
                Destroy(transform.GetChild(i).gameObject);
            }

            // Create new floor GameObjects based on the specified count in each direction.
            for (int x = 0; x < countX; x++)
            {
                // Create new floor GameObjects based on the specified count in each direction.
                for (int z = 0; z < countZ; z++)
                {
                    // Calculate the position and rotation for the new floor.
                    Vector3 position = GetFloorPosition(x, z);
                    Quaternion rotation =
                        Quaternion.Euler(GetRandomRotation());
                    // Instantiate the floor prefab at the calculated position and rotation, and set its parent to this transform.
                    GameObject floor = Instantiate(
                        prefab, position, rotation, transform);
                    // Name the new floor GameObject based on its grid coordinates.
                    floor.name = $"Floor_{x}_{z}";
                }
            }
        }
        // Update the floor grid in the Unity Editor by modifying existing floors and creating only missing ones.
#if UNITY_EDITOR
        // Editor preview, update existing floors and create only missing ones.
        private void UpdateEditorPreview(int countX, int countZ)
        {
            // Calculate the total number of floors that should exist based on the specified count in each direction.
            int targetTotal = countX * countZ;

            // Remove excess floors immediately in Edit Mode.
            for (int i = transform.childCount - 1;
                 i >= targetTotal; i--)
            {
                // Destroy existing floor GameObjects immediately in Edit Mode to avoid issues with the editor's undo system.
                DestroyImmediate(transform.GetChild(i).gameObject);
            }

            // Keep track of the current index in the grid to update or create floor GameObjects.
            int currentIndex = 0;

            // Loop through the grid coordinates and update or create floor GameObjects.
            for (int x = 0; x < countX; x++)
            {
                for (int z = 0; z < countZ; z++)
                {
                    // Calculate the position and rotation for the floor at the current grid coordinates.
                    Vector3 position = GetFloorPosition(x, z);
                    Quaternion rotation =
                        Quaternion.Euler(GetRandomRotation());

                    // If a floor already exists at the current index, update its position and rotation.
                    if (currentIndex < transform.childCount)
                    {
                        Transform existing =
                            transform.GetChild(currentIndex);
                        // Update the existing floor's position, rotation, and name based on its grid coordinates.
                        existing.position = position;
                        existing.rotation = rotation;
                        existing.name = $"Floor_{x}_{z}";
                    }
                    else
                    {
                        // If no floor exists at the current index, instantiate a new floor prefab at the calculated position and rotation.
                        GameObject floor = Instantiate(
                            prefab, position, rotation, transform);
                        // Name the new floor GameObject based on its grid coordinates.
                        floor.name = $"Floor_{x}_{z}";
                    }
                    // Increment the current index to move to the next floor in the grid.
                    currentIndex++;
                }
            }
        }
#endif
    }
}
