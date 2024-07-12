using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Add this line

public class Dvideo : MonoBehaviour
{
    public void Start()
    {
        StartCoroutine(StartVideo());
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Add logic here to handle the Escape key press
            SceneManager.LoadScene("Menu");
        }
    }
    IEnumerator StartVideo()
    {
        yield return new WaitForSeconds(34.0f);
        SceneManager.LoadScene("Menu");
    }
}
