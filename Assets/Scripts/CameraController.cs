using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private float xOffset;
    private float yOffest;
    private float zOffset;
    void Start()
    {
        xOffset = transform.position.x;
        yOffest = transform.position.y;
        zOffset = transform.position.z;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x + xOffset, yOffest, player.transform.position.z + zOffset);
    }
}
