using UnityEngine;

[System.Serializable]
public class SpawnTableEntry
{
    public GameObject enemyPrefab;

    public Vector3 spawnPosition;

    public Transform spawnPoint;

    public Vector3 GetSpawnPosition()
    {
        if (spawnPoint != null)
            return spawnPoint.position;

        return spawnPosition;
    }
}
