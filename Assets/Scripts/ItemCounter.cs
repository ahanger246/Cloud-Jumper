using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemCounter : MonoBehaviour
{
    public int dropCount;
    public Text dropText;

    public int sunCount;
    public Text sunText;

    public Animator levelTransition;

    // Update is called once per frame
    void Update()
    {
        dropText.text = ": " + dropCount.ToString();
        sunText.text = ": " + sunCount.ToString();

        if(dropCount == 3 && sunCount == 3) {
            NextLevel();
        }

    }

    public void NextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int index)
    {
        levelTransition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(index);
    }

}
