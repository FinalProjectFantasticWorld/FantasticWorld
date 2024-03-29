﻿using UnityEngine;

/**
 * This component makes its object watch a given radius, and if the target is found - it starts run away from it.
 */
[RequireComponent(typeof(Runner))]
public class RadiusWatcher: MonoBehaviour {
    [Tooltip("size radius watch")] [SerializeField] float radiusToWatch = 5f;

    private Runner chaser;
    private void Start() {
        chaser = GetComponent<Runner>();
        chaser.enabled = false;
    }

    void Update() {
        float distanceToTarget = Vector3.Distance(
            transform.position, chaser.TargetObjectPosition());
        if (distanceToTarget <= radiusToWatch) {
            chaser.enabled = true;
        } else {
            chaser.enabled = false;
        }
    }

    private void OnDrawGizmosSelected() {
        if (enabled) {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, radiusToWatch);
        }
    }
}
