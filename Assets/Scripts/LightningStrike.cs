using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningStrike : MonoBehaviour
{
    public GameObject lightningBolt;
    public Transform lightningPos;
    private float strikeTimer;
    private float soundTimer = 0;
    private GameObject Marvin;
    [SerializeField]
    private AudioSource thunder;
    // Start is called before the first frame update
    void Start()
    {
        Marvin = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float MarvinDistance = Vector2.Distance(transform.position, Marvin.transform.position);
        if (MarvinDistance < 10)
        {
            strikeTimer += Time.deltaTime;
            soundTimer -= Time.deltaTime;

            if (strikeTimer > 2)
            {
                strikeTimer = 0;
                strike();
            }

            if (soundTimer <= 0) {
                soundTimer = 5;
                thunder.Play();
            }
        }  
    }

    void strike() {
        Instantiate(lightningBolt, lightningPos.position, Quaternion.identity);
    }
}
