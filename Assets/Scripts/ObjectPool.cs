using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] [Range(0, 50)] int poolSize = 5;
    [SerializeField] [Range(0.1f, 30f)] float spawnCooldown;
    GameObject[] pool;

    private void Awake() {
        PopulatePool();
    }

    private void PopulatePool() {
        pool = new GameObject[poolSize];
        for (int i = 0; i < pool.Length; i++) {
            pool[i] = Instantiate(enemy, transform);
            pool[i].SetActive(false);
        }
    }

    private void Start() {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies() {
        while (true) {
            //Instantiate(enemy, transform);
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnCooldown);
        }
    }

    private void EnableObjectInPool() {
        foreach (GameObject enemy in pool) {
            if (!enemy.activeInHierarchy) {
                enemy.SetActive(true);
                break;
            } 
        }
    }
}
