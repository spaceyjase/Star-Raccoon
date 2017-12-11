using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
  [SerializeField]
  private GameObject[] prefabs;
  [SerializeField]
  private float xRange = 1.0f;
  [SerializeField]
  private float yRange = 1.0f;
  [SerializeField]
  private float minSpawnTime = 1.0f;
  [SerializeField]
  private float maxSpawnTime = 10.0f;

  private void Start()
  {
    Invoke(nameof(SpawnWall), UnityEngine.Random.Range(minSpawnTime, maxSpawnTime));
  }

  private void SpawnWall()
  {
    float posX = UnityEngine.Random.Range(-xRange, xRange);
    float posY = UnityEngine.Random.Range(-yRange, yRange);
    var prefab = prefabs[UnityEngine.Random.Range(0, prefabs.Length)];
    Instantiate(prefab, transform.position + new Vector3(posX, posY, 0.0f), prefab.transform.rotation);

    // Spawn another wall!
    Invoke(nameof(SpawnWall), UnityEngine.Random.Range(minSpawnTime, maxSpawnTime));
  }
}
