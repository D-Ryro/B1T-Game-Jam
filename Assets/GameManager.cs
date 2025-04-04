using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Character Configs")]
    [SerializeField] private List<BaseKuker> kukerTypes;
    [SerializeField] private List<BaseGhost> ghostTypes;

    [Header("Spawning")]
    [SerializeField] private int ghostsToKillForNewKuker = 5;
    [SerializeField] private float spawnRadius = 5f;
    [SerializeField] private float minGhostSpawnDelay = 2f;
    [SerializeField] private float maxGhostSpawnDelay = 5f;

    [HideInInspector] public List<KukerController> activeKukers = new List<KukerController>();
    [HideInInspector] public List<GhostController> activeGhosts = new List<GhostController>();
    public int ghostsKilled { get; private set; }

    void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        Instance = this;
        SpawnInitialKuker();
        SpawnInitialGhost(); // Optional: Spawn first ghost immediately
    }

    void SpawnInitialKuker()
    {
        Instantiate(kukerTypes[0].prefab, Vector3.zero, Quaternion.identity);
    }

    void SpawnInitialGhost()
    {
        SpawnGhost();
    }

    // Called when a ghost dies
    public void GhostKilled()
    {
        ghostsKilled++;
        if (ghostsKilled % ghostsToKillForNewKuker == 0)
        {
            SpawnNewKuker();
        }
        StartCoroutine(SpawnGhostWithDelay(Random.Range(minGhostSpawnDelay, maxGhostSpawnDelay)));
    }

    IEnumerator SpawnGhostWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SpawnGhost();
    }

    // Main ghost spawning logic
    public void SpawnGhost()
    {
        if (ghostTypes.Count == 0 || activeKukers.Count == 0) return;

        BaseGhost randomType = ghostTypes[Random.Range(0, ghostTypes.Count)];
        Vector2 spawnPos = GetSpawnPositionOutsideView();
        Instantiate(randomType.prefab, spawnPos, Quaternion.identity);
    }

    // Main kuker spawning logic
    public void SpawnNewKuker()
    {
        if (kukerTypes.Count == 0 || activeKukers.Count == 0) return;

        BaseKuker randomType = kukerTypes[Random.Range(0, kukerTypes.Count)];
        Vector2 spawnPos = GetSpawnPositionOutsideView();
        Instantiate(randomType.prefab, spawnPos, Quaternion.identity);
    }

    // Helper: Get spawn position at screen edge
    Vector2 GetSpawnPositionOutsideView()
    {
        Camera cam = Camera.main;
        Vector2 viewportPos = Vector2.zero;

        // Random edge (0=top, 1=right, 2=bottom, 3=left)
        int edge = Random.Range(0, 4);
        switch (edge)
        {
            case 0: viewportPos = new Vector2(Random.value, 1.1f); break; // Top
            case 1: viewportPos = new Vector2(1.1f, Random.value); break; // Right
            case 2: viewportPos = new Vector2(Random.value, -0.1f); break; // Bottom
            case 3: viewportPos = new Vector2(-0.1f, Random.value); break; // Left
        }

        return cam.ViewportToWorldPoint(viewportPos);
    }

    // Circle formation for kukers (called in KukerController's OnDestroy)
    public void ArrangeKukersInCircle()
    {
        if (activeKukers.Count == 0) return;

        float angleStep = 360f / activeKukers.Count;
        float radius = 2f;
        Vector2 center = activeKukers[0].transform.position;

        for (int i = 0; i < activeKukers.Count; i++)
        {
            float angle = angleStep * i * Mathf.Deg2Rad;
            Vector2 offset = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;
            activeKukers[i].MoveToPosition(center + offset);
        }
    }
}