using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NigthSceneLoader : MonoBehaviour
{
    private float timer = 0;
    public float daytimelength = 20;

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
        //want to have the spirits stop/disappear ouside
        SceneManager.LoadScene(0);
    }
}
