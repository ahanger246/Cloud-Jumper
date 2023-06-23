using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BonusManager : MonoBehaviour
{

    public static int snowCount;
    public static float timer;
    private bool gameComplete;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 7) {
            gameComplete = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameComplete) {
            timer += Time.deltaTime;
        }
    }
}
