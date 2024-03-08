using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health = 3;
    [SerializeField] int difficultyRamp = 1;
    float currentHealth = 100;
    Enemy enemy;

    private void Start() {
        enemy = GetComponent<Enemy>();
    }

    private void OnEnable() {
        currentHealth = health;
    }
    private void OnParticleCollision(GameObject other) {
        ProcessHit();
    }

    private void ProcessHit() {
        currentHealth--;
        if (currentHealth <= 0) {
            gameObject.SetActive(false);
            health += difficultyRamp;
            enemy.RewardGold();
        }
    }
}
