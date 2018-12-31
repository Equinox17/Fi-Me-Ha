using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour {

    private float score = 0.0f;
    public Text scoretext;

    private int difficulty = 1;
    private int maxDifficulty = 10;
    private int scoreToNextLevel = 10;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if( score >= scoreToNextLevel)
        {

            NewLevel();

        }

        score += Time.deltaTime * difficulty;
        scoretext.text = ((int)score).ToString();
		
	}

    void NewLevel()
    {
        
        if (difficulty == maxDifficulty)
        {
            return;
        }

        scoreToNextLevel *= 2;
        difficulty ++;

        GetComponent<playermotor>().modSpeed(difficulty);

    }


    public float getScore()
    {
        return this.score;
    }

    public void setScore(float s)
    {
        this.score = s;
    }
}
