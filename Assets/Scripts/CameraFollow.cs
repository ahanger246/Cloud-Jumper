using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Vector3 offset;
    [Range(1, 10)]
    public float smoothFactor;
    [SerializeField]
    private Vector3 minValues, maxValues;
    

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void LateUpdate() {
        Follow();
    }

    void Follow() {
        Vector3 playerPosition = player.position + offset;
        Vector3 bounds = new Vector3(Mathf.Clamp(playerPosition.x, minValues.x, maxValues.x), 
                                     Mathf.Clamp(playerPosition.y, minValues.y, maxValues.y),
                                     Mathf.Clamp(playerPosition.z, minValues.z, maxValues.z));

        Vector3 smooth = Vector3.Lerp(transform.position, bounds, smoothFactor*Time.fixedDeltaTime);
        transform.position = smooth;
    }
}
