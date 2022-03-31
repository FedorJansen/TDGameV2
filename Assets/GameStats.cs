using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameStats : MonoBehaviour
{
    public static int levens;
    public int score;
    public TextMeshProUGUI Score;

    public static bool game = true;
    // Start is called before the first frame update
    void Start()
    {
        levens = 1;
        score = 0;
        Projectile.scoe += scoreErbij;
        EnemyMovement.alivent += levensEraf;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void levensEraf()
    {
        levens--;
        Debug.Log(levens);
        if (levens <= 0)
        {
            GameObject[] tempList = GameObject.FindGameObjectsWithTag("enemy");
            foreach (GameObject gameObject in tempList)
            {
                Destroy(gameObject);
            }
            GameObject[] tempGrid = GameObject.FindGameObjectsWithTag("tower");
            foreach (GameObject gameObject in tempGrid)
            {
                Destroy(gameObject);
            }
            game = false;
            Debug.Log("Game is disabled.");
        }
    }

    void scoreErbij()
    {
        score+= 10;
        Score.text = "Score :" + score;
    }
}
