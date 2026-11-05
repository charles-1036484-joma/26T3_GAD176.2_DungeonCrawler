using UnityEngine;

// Inherits SpawnPattern and overrides GetSpawnPosition()
public class RandomSpawnPattern : SpawnPattern
{
    //can't customise the labels so the intended z-axis shows up as y
    //alternative is either seperating as x and z or a Vector3 where the y axis is unused
    [SerializeField] private Vector2 areaSize = new Vector2(8f, 4f);

    public override Vector3 GetSpawnPosition(int spawnIndex)
    {
        float x = Random.Range(-areaSize.x / 2f, areaSize.x / 2f);
        float z = Random.Range(-areaSize.y / 2f, areaSize.y / 2f);

        
        return transform.position + new Vector3(x, spawnY, z);
    }
}
