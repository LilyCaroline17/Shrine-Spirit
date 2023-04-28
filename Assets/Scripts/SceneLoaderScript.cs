using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderScript : MonoBehaviour
{

    public int numOfVisitors;
    
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        numOfVisitors = 0;
    }

    public void Update()
    {
        animator.SetInteger("NumberOfVisitors",numOfVisitors);
    }

    public void LoadNightScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadDayScene()
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