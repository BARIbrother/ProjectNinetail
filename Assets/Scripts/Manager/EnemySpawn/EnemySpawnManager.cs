using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private List<SpawnTable> waves = new();

    private int currentWaveIndex = -1;
    private int aliveEnemyCount = 0;

    void Start()
    {
        currentWaveIndex ++; // temp code.
        SpawnWave();
    }
    public void SetSpawnTable(List<SpawnTable> tables)
    {
        waves = tables;
    }

    public void SpawnWave()
    {
        //currentWaveIndex ++; when wave is completed
        if (waves[currentWaveIndex] == null)
        {
            Debug.LogWarning("SpawnTable이 설정되지 않았습니다.");
            return;
        }

        foreach (var entry in waves[currentWaveIndex].entries)
        {
            Spawn(entry);
        }
    }

    private void Spawn(SpawnTableEntry entry)
    {
        if (entry.enemyPrefab == null)
        {
            Debug.LogWarning("Enemy Prefab이 비어 있습니다.");
            return;
        }

        GameObject enemy = Instantiate(
                entry.enemyPrefab,
                entry.GetSpawnPosition(),
                Quaternion.identity
            );

            aliveEnemyCount++;

            // 적이 죽을 때 콜백 연결
            var damageable = enemy.GetComponent<Damageable>();
            if (damageable != null)
            {
                damageable.onDead += OnEnemyDead;
            }
    }

    private void OnEnemyDead()
    {
        aliveEnemyCount--;

        if (aliveEnemyCount <= 0)
        {
            SpawnWave();
        }
    }
}
