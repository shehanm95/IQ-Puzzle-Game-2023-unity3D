using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using mymanager;

public class temp : MonoBehaviour
{
    public TMP_Text scoreText;
    void Start()
    {
        GameManager.gameover = false;
        
        GameManager.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.gameover)
            {

            }
        else
            {
            StartCoroutine ( Utils.waitSeanLoader ( "leaderboard",3f ) );
            }
    }

    public void increasScore ( )
        {
        if (!GameManager.gameover)
            {

            GameManager.score++;
            Utils.textUpdater ( scoreText,"Score : " + GameManager.score.ToString ( ) );
            }

        }

    public void gameover ( )
        {
        GameManager.gameover = true;
        }
    
}
