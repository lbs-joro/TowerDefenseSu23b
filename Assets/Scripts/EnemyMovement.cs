using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class EnemyMovement : MonoBehaviour
{

    public List<GameObject> waypoints;
    int waypointIndex = 0;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = waypoints[waypointIndex].transform.position - transform.position;
        rb.velocity = direction.normalized * 2.0f;

        if ( Vector2.Distance(waypoints[waypointIndex].transform.position, transform.position) < 0.1f)
        {
            waypointIndex += 1;

            if (waypointIndex == waypoints.Count)
            {
                // Jag har kommit till slutet!

                Destroy(gameObject);

                //TODO: spelaren ska förlora ett liv etc.
            }
        }


        // Ändra rotation så att jag tittar åt hållet jag åker.

        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);

    }
}
