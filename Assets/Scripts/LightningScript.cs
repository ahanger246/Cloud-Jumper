using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningScript : MonoBehaviour
{
    private Rigidbody2D body;
    private GameObject levelFloor;
    public float force;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        levelFloor = GameObject.Find("Floor");

        Vector3 direction = levelFloor.transform.position - transform.position;
        body.velocity = new Vector2(0, direction.y).normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 5) {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Bird")) {
            Destroy(gameObject);
        }    
    }
}
