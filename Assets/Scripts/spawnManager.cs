using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public List<GameObject> enemiesActive = new List<GameObject>();
    public GameObject spawn;
    public Vector3 Spawnpos;

    private float minEnemy = 10;
    private float maxEnemy = 20;
    private float wave;
    private int ronde = 1;
    private float summoned;
    public enum difficulty { easy, normal, hard, impossible };
    public difficulty diff = difficulty.easy;

    void Start()
    {
        if (GameStats.game == true)
        {
            Spawnpos = spawn.transform.position;
            Wave();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesActive.Count <= 0)
        {
            return;
        }
    }

    void Diff(string diff)
    {
        if (Enum.TryParse(diff.ToLower(), out difficulty result))
        {
            switch (diff)
            {
                case "easy":
                    //appel
                    break;
                case "normal":
                    //loser
                    break;
                case "hard":
                    //noob
                    break;
                case "impossible":
                    //stop
                    break;
            }
        }
        else
            throw new InvalidOperationException(nameof(diff));
    }

    void Ronde() 
    {
        
    }
    void Wave()
    {
        if (summoned < maxEnemy && GameStats.game == true)
        {
            InvokeRepeating("spawnEnemy",0,1);
            summoned++;

        }
        else if (summoned >= maxEnemy)
        {
            return;
        }
    }

            //maxEnemy = maxEnemy* 1.5f;
            //minEnemy = minEnemy* 1.5f;
            //Debug.Log("maxEnemy: " + maxEnemy + " minEnemy: " + minEnemy);

    void spawnEnemy()
    {
        if (GameStats.game == true)
        enemiesActive.Add(Instantiate(enemyPrefabs[0], Spawnpos, transform.rotation, transform));
    }
}
