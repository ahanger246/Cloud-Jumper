using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreenController : MonoBehaviour
{
    public Text timeText;
    public Text snowText;
    // Start is called before the first frame update
    void Start()
    {
        timeText.text = BonusManager.timer.ToString("F2") + " seconds";
        snowText.text = BonusManager.snowCount.ToString() + "/3";
    }

    public void returnToMainMenu() {
        SceneManager.LoadScene(0);
    }
}
