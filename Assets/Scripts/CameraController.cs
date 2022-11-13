using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //[SerializeField] private Transform player;
    public Vector3 offset;
    public Transform target;
    [Range (1, 10)]
    public float smootherFactor;

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        var targetPosition = target.position + offset;
        var smootherPosition = Vector3.Lerp(transform.position, targetPosition, smootherFactor * Time.fixedDeltaTime);
        transform.position = smootherPosition;
    }
}
