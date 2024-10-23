using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public int score;

    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    public int Score
    {
        get { return score; } 
        set {  score = value; }
    }

    public IEnumerator Trapped()
    {
        while (true) 
        {
            Health -= Random.Range(1, 8);
            yield return new WaitForSeconds(.6f);
        };
    }
}


