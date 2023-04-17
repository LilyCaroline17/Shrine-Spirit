using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    // Start is called before the first frame update

    public int score = 0;
    private int score1;
    private int score2;
    private int score3;

    public GameObject bird_spirit;
    public GameObject rock_spirit;
    public GameObject plant_ghost;

    // Update is called once per frame
    void Update()
    {
        score1 = bird_spirit.GetComponent<EnemyScript>().score;
        score2 = rock_spirit.GetComponent<EnemyScript>().score;
        score3 = plant_ghost.GetComponent<EnemyScript>().score;

        score = score1 + score2 + score3;
    }
}
