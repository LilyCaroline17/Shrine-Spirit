using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleSpawnerScript : MonoBehaviour
{
    public GameObject Visitor;
    public bool shouldSpawn = true;

    // Start is called before the first frame update
    //void Start()
    //{
    //    spawnVisitor();
    //}


    void Update()
    {
        if (shouldSpawn) { spawnVisitor(); shouldSpawn = false; }
    }

    void spawnVisitor()
    {
        Instantiate(Visitor, transform.position, transform.rotation);
    }
}
