using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsController : MonoBehaviour
{
    public void GoBack() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}