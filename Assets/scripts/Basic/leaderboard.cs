using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using mymanager;
using System.Linq;

public class leaderboard : MonoBehaviour
{
    int listcapacity , playerindex = -1;
    List<Player> players =new List<Player>();
    public TMP_Text log;
    
    public GameObject tryAgainButton , NextButton;
    AudioSource au;

    public GameObject textTemplate , LeaderBoardContent , StarparticleSystem;
    


    // Start is called before the first frame update
    void Start()
    {
      
        GameManager.round++;
        GameManager.remainingTime = 0;
        GameManager.level--;
        listcapacity = GameManager.listcapacity;
        StarparticleSystem.SetActive ( false );
        NextButton.SetActive ( false );
        tryAgainButton.SetActive ( false );
        au = GetComponent<AudioSource> ( );
        int maxtrys = PlayerPrefs.GetInt("maxtries",3);
        print ("round is "+  GameManager.round + " and tries are : " + maxtrys );
        if (GameManager.round < maxtrys)
            tryAgainButton.SetActive ( true );
        else
            NextButton.SetActive ( true );
            

     for(int i = 0 ; i < listcapacity ; i++)
            {
            Player player = new Player( PlayerPrefs.GetString("fname" + i.ToString() , "Nisal") , PlayerPrefs.GetString("lname" + i.ToString() , "Perera"), PlayerPrefs.GetInt("levels" + i.ToString(), 1) ,PlayerPrefs.GetFloat("secs" + i.ToString(), 6+i));
            
            players.Add ( player );
            }

        //GameManager.level = 3;
        //GameManager.allcompleatedTime = 12f;
        print ( $"level : {GameManager.level}" );
        print ( $"Total Time in leader board : {GameManager.allcompleatedTime}" );

        if (GameManager.level >= players[listcapacity -1].Levels)
            {
            if(GameManager.level == players [ listcapacity - 1 ].Levels)
                {
                if (GameManager.allcompleatedTime < players [ listcapacity - 1 ].Secs)
                    {
                    au.PlayOneShot ( SoundManager.bgmusic );
                    insertToLeaderBoard ( );
                    saveplayers ( );
                    }
                else
                    {
                    au.PlayOneShot ( SoundManager.defeated );
                    }
                }
            else
                {
                au.PlayOneShot ( SoundManager.bgmusic );
                insertToLeaderBoard ( );
                saveplayers ( );
                }
            //victorysound playing
            
            }
        else
            {
            au.PlayOneShot ( SoundManager.defeated );
            }
        createLeaderBoardText ( );
      

       
     }

    // Update is called once per frame
    void Update()
    {
        
    }


    void insertToLeaderBoard ( )
        {
        List<int> indexes = new List<int>();
        for (int i =0 ; i < listcapacity ; i++)
            {
            if(GameManager.level == players [ i ].Levels) { indexes.Add ( i ); print ( $"{i} added to the indexes" ); }
            }

        if (indexes.Count != 0)
            {
            print ( "indexes have" );
            playerindex = indexes [indexes.Count-1]+1;
            for (int c = indexes.Count-1 ; 0 <= c ; c--)
                {
                if(players[indexes[c]].Secs >= GameManager.allcompleatedTime)
                    {
                    playerindex = indexes [ c ];
                    }
                }
            Player currentplayer = new Player(GameManager.first_name , GameManager.last_name , GameManager.level , GameManager.allcompleatedTime);
            print ( $"player index is set in first case : index{playerindex}" );
            players.Insert ( playerindex,currentplayer );

            log.text = "<color=green>Congratulations! Your Name Is Added To The Leader Board....";
            StarparticleSystem.SetActive ( true );
            }
        else
            {
            for (int i = 0 ; i < listcapacity ; i++)
                {
                if (players [ i ].Levels < GameManager.level)
                    {
                    playerindex = i;
                    print ( $"player index is set in second case : index{i}" );
                    Player currentplayer = new Player(GameManager.first_name , GameManager.last_name , GameManager.level , GameManager.allcompleatedTime);

                    players.Insert ( i,currentplayer );

                    log.text = "<color=green>Congratulations! Your Name Is Added To The Leader Board....";
                    StarparticleSystem.SetActive ( true );
                    break;
                    }
                }
            }
        }

    void createLeaderBoardText ( )
        {
        GameObject g;
        
        for (int i = 0 ; i < listcapacity ; i++)
            {
            g = Instantiate ( textTemplate, LeaderBoardContent.transform);
            if (playerindex == i)
                {
                g.transform.GetChild ( 0 ).GetComponent<TMP_Text> ( ).text = $"<color=green>0{i + 1}. { players [ i ].FirstName} { players [ i ].LastName}";
                g.transform.GetChild ( 1 ).GetComponent<TMP_Text> ( ).text = $"<color=green>: Compleated { players [ i ].Levels.ToString("00")} Levels";
                string min = Mathf.Floor(players [ i ].Secs/60).ToString("00");
                string sec = Mathf.Floor(players [i].Secs% 60).ToString("00");
                g.transform.GetChild ( 2 ).GetComponent<TMP_Text> ( ).text = $"<color=green>In {min} Mins and {sec} Secs.";
                }
            else
                {
                g.transform.GetChild ( 0 ).GetComponent<TMP_Text> ( ).text = $"<color=white>0{i + 1}. { players [ i ].FirstName} { players [ i ].LastName}";
                g.transform.GetChild ( 1 ).GetComponent<TMP_Text> ( ).text = $"<color=white>: Compleated { players [ i ].Levels.ToString ( "00" )} Levels";
                string min = Mathf.Floor(players [ i ].Secs/60).ToString("00");
                string sec = Mathf.Floor(players [i].Secs% 60).ToString("00");
                g.transform.GetChild ( 2 ).GetComponent<TMP_Text> ( ).text = $"<color=white>In {min} Mins and {sec} Secs.";
                }
            }

        GameManager.level = 1;
        GameManager.allcompleatedTime = 0;
        }

    void saveplayers ( )
        {
        for (int i = playerindex ; i < listcapacity ; i++)
            {
            PlayerPrefs.SetString ( "fname" + i.ToString ( ) , players[i].FirstName );
            PlayerPrefs.SetString ( "lname" + i.ToString ( ),players[i].LastName );
            PlayerPrefs.SetInt("levels" + i.ToString(), players[i].Levels );
            PlayerPrefs.SetFloat("secs" + i.ToString(), players[i].Secs);
            }
        }

    public void GoToscene (string seanName )
        {
        StartCoroutine ( Utils.waitSeanLoader ( seanName,1f ) );
        }
    }
