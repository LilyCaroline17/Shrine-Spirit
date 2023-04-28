using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NigthSceneLoader : MonoBehaviour
{
    private float timer = 0;
    public float daytimelength = 20;
    public static int numOfDays;

    private void Start()
    {
        numOfDays++;
    }

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
        if (numOfDays >= 1) SceneManager.LoadScene(3);
        else SceneManager.LoadScene(0);
    }
}
