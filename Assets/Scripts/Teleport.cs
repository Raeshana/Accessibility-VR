using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    private Transform destination;

    [SerializeField]
    private GameObject playerGO;

    private Transform playerPos;
    private ParticleSystem hasTp;

    void Start() {
        playerPos = playerGO.transform;
        hasTp = playerGO.GetComponentInChildren<ParticleSystem>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            playerGO.SetActive(false);
            playerPos.position = destination.position;
            playerGO.SetActive(true);
            hasTp.Play();
        }
    }
}
