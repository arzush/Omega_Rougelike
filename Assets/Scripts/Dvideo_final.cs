using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Add this line

public class Dvideo_final : MonoBehaviour
{
    public void Start()
    {
        StartCoroutine(StartVideo());
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    IEnumerator StartVideo()
    {
        yield return new WaitForSeconds(20.0f);
        Application.Quit();
    }
}
