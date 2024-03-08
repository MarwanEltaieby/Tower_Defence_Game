using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocater : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float range;
    Transform target;
    
    // private void Start() {
    //     target = FindObjectOfType<EnemyMover>().transform;
    // }
    
    private void Update() {
        FindClosestTarget();
        AimWeapon();
    }

    private void FindClosestTarget() {
        EnemyHealth[] enemies = FindObjectsOfType<EnemyHealth>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(EnemyHealth enemy in enemies) {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (targetDistance < maxDistance) {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }
        target = closestTarget;
    }

    private void AimWeapon() {
        //if (target == null) {return;}
        float targetDistance = Vector3.Distance(transform.position, target.position);
        weapon.LookAt(target);
        if (targetDistance < range) {
            Attack(true);
        } else {
            Attack(false);
        }
    }

    void Attack(bool isActive) {
        var emissionModule = projectileParticles.emission;
        emissionModule.enabled = isActive;
    }
}
