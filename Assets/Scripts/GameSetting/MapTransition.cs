using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTransition : MonoBehaviour
{
    private CameraController cam;

    public Transform player;

    public Vector2 newMinCameraBoundary;
    public Vector2 newMaxCameraBoundary;

    [SerializeField] Vector2 playerPosOffset;

    [SerializeField] Transform exitPos;
    private void Awake()
    {
        cam = Camera.main.GetComponent<CameraController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            
            cam.minCameraBoundary = newMinCameraBoundary;
            cam.maxCameraBoundary = newMaxCameraBoundary;

            player.position = exitPos.position + (Vector3)playerPosOffset;;
        }
    }
}
