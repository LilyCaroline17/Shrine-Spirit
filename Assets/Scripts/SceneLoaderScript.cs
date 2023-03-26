using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderScript : MonoBehaviour
{
    //public GameObject morning_background;
    //public GameObject afternoon_background;
    //public float daytimelength = 10;
    //private float timer = 0;
    //public bool isMorning = true;

    public int numOfVisitors;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        numOfVisitors = 0;
    }

    public void Update()
    {
        //if (timer < daytimelength)
        //{ timer += Time.deltaTime; }
        //else
        //{
        //    ChangeBackground();
        //    timer = 0;
        //}
        animator.SetInteger("NumberOfVisitors",numOfVisitors);
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene((currentSceneIndex + 1)% SceneManager.sceneCount);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }


    //public void ChangeBackground()
    //{
    //    //add in animations to transition between morning and afternoon
    //    morning_background.SetActive(isMorning);
    //    afternoon_background.SetActive(!isMorning);
    //    isMorning=!isMorning;
    //}
}