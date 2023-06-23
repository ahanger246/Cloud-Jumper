using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPatrol : MonoBehaviour
{

    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D body;
    private Transform location;
    private float moveSpeed = 4;
    [SerializeField]
    private AudioSource tweeting;
    // Start is called before the first frame update
    void Start() 
    {
        tweeting.Play();
        body = GetComponent<Rigidbody2D>();
        location = pointB.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = location.position - transform.position;
        if (location == pointB.transform)
        {
            body.velocity = new Vector2(moveSpeed, 0);
        }
        else {
            body.velocity = new Vector2(-moveSpeed, 0);
        }

        if (Vector2.Distance(transform.position, location.position) < 1f && location == pointB.transform) {
            flip();
            location = pointA.transform;
        }
        if (Vector2.Distance(transform.position, location.position) < 1f && location == pointA.transform)
        {
            flip();
            location = pointB.transform;
        }
    }

    private void flip() {
        tweeting.Play();
        Vector3 tempScale = transform.localScale;
        tempScale.x *= -1;
        transform.localScale = tempScale;
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(pointA.transform.position, 1f);
        Gizmos.DrawWireSphere(pointB.transform.position, 1f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}
