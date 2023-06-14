using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class musicManager: MonoBehaviour
{
    public AudioSource theMusic;
    public bool startPlaying;
    public pressnote theBS;

    public static musicManager instance;
    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfactNote = 150;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThersholds;

    public Text scoreText;
    public Text multipleText;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "Score : 0 ";
        currentMultiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying)
        {
            if(Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;

                theMusic.Play();
            }
        }
    }
    public void NoteHit()
    {
        Debug.Log("Hit On Time");
        if (currentMultiplier - 1 < multiplierThersholds.Length)
        {
            multiplierTracker++;

            if (multiplierThersholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }
        multipleText.text = "Multiplier : x" + currentMultiplier;

        //currentScore += scorePerNote * currentMultiplier;
        //Debug.Log(currentScore);
        scoreText.text = "Score : " + currentScore;

    }
    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();

    }
    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();

    }
    public void PerfectHit()
    {
        currentScore += scorePerPerfactNote * currentMultiplier;
        NoteHit();
        
    }
    public void NoteMissed()
    {

        Debug.Log("Missed Note");

        currentMultiplier = 1;
        multiplierTracker = 0;
        currentScore += scorePerNote * currentMultiplier;
    }
}
