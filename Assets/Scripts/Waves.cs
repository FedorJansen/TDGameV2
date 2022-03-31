using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    private float minEnemy;
    private float maxEnemy;
    private float wave;
    private int ronde = 1;
    public enum difficulty {easy, normal, hard, impossible };
    public difficulty diff = difficulty.easy;
    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        
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

    void Wave()
    {

    }
}


