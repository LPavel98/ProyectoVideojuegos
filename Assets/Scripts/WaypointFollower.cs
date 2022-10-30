using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    SpriteRenderer sr;
   [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;
    void Start()
    {
        //Debug.Log("Iniciamos script de player");
        //gameManager = FindObjectOfType<GameManagerController>();
        //rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        //animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            sr.flipX = true;
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                sr.flipX = false;
                currentWaypointIndex = 0;
                
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
