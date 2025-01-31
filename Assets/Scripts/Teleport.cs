using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private Transform destination;

    [SerializeField]
    private GameObject playerGO;

    [SerializeField]
    private Material material;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            playerGO.SetActive(false);
            player.position = destination.position;
            playerGO.SetActive(true);
            playerGO.GetComponent<MeshRenderer>().material = material;
        }
    }
}
