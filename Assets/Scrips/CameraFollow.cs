using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
    public Vector2 minCamPos, maxCamPos;
    public float smoothTime;

    private Vector2 velocity;

    void Start()
    {

    }

    void Update()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTime);
        float posZ = Mathf.SmoothDamp(transform.position.z, player.transform.position.z, ref velocity.y, smoothTime);

        transform.position = new Vector3(Mathf.Clamp(posX, minCamPos.x, maxCamPos.x), transform.position.y , Mathf.Clamp(posZ, minCamPos.y, maxCamPos.y));
    }
}
