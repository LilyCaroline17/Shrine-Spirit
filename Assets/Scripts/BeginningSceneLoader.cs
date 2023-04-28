using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginningSceneLoader : MonoBehaviour
{
    private float timer = 0;
    public float daytimelength = 5;

    // Update is called once per frame
    void Update()
    {
        if (timer < daytimelength)
        { timer += Time.deltaTime; }
        else
        {
            timer = 0;
            LoadDayScene();
        }
    }

    public void LoadDayScene()
    {
        SceneManager.LoadScene(0);
    }
}
