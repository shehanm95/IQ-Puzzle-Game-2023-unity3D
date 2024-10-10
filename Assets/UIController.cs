using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using mymanager;
using UnityEngine.SceneManagement;

public class UIController: MonoBehaviour
    {



    [Header("=== level Text ===")]
    public TMP_Text levelText;

    [Header("=== Player Speed ===")]
    public float totalTime = 60f; // Total time for the countdown in seconds
    private float currentTime; // Current time left
    


    [Header("=== Player Timer ===")]
    public TMP_Text timerText; // Reference to a UI Text component to display the timer
    private bool isCountingDown = false,  last10sound =false;
    public AudioClip last10soundau;

    [Header ( "=== WinPanel ===" )]
    public GameObject endPanel;
    public TMP_Text EndPanelLog , yourScoreText , HeighScoreText;
    public string WinText, LooseText;
    AudioSource au;

    [Header ( "=== Camera Settings ===" )]
    public TMP_InputField CamPasswordInput;
    public GameObject CamSettingsPanel;
    Camera mainCamera;

    void Start ( )
        {
        float num = 43f;
        print ( $"{Mathf.Floor(num / 60):00}" );
        mainCamera = Camera.main;
        totalTime = GameManager.GetTotalTime ( GameManager.level )+ GameManager.remainingTime;
        au = GetComponent<AudioSource> ( );
        if (totalTime == 0)
            totalTime = 50f;
        currentTime = totalTime;
        UpdateTimerText ( );
        StartCountdown ( );
        levelText.text = $"This is level : {GameManager.level:00}";
        setLeaderScore ( );
        setYourScore ( );
        if (GameManager.CameraX != 0)
            {
            changeCameraPosX ( GameManager.CameraX );
            changeCameraPosY ( GameManager.CameraY );
            changeCamerazoom ( GameManager.CameraZoom );
            }
       
        }

    void Update ( )
        {
       
        if (isCountingDown)
            {
            if (currentTime > 0f)
                {
                currentTime -= Time.deltaTime;
                UpdateTimerText ( );
                }
            else
                {
                // Timer reached zero, you can perform actions here
                Debug.Log ( "Time's up!" );
                isCountingDown = false;
                ActiveEndPanel ( "lost" );
                }
            }
        }

    void UpdateTimerText ( )
        {
        // Format the time as minutes and seconds
        float minutes = Mathf.Floor(currentTime / 60);
        float seconds = Mathf.Floor(currentTime % 60);

        // Update the UI Text component
        if (currentTime > 0)
            {
            if (currentTime < 10)
                {
                timerText.color = Color.red;
                if (!last10sound)
                    {
                    au.Stop ( );
                    au.PlayOneShot ( last10soundau );
                    last10sound = true;
                    }
                }
            timerText.text = string.Format ( "{0:00}:{1:00}",minutes,seconds );
            }
        else
            {
            timerText.text = "00:00";
            GameManager.gameover = true;
            au.Stop ( );

            }
        }

    // Start the countdown
    public void StartCountdown ( )
        {
        isCountingDown = true;
        }


    public void win ( )
        {
        GameManager.level++;
        GameManager.allcompleatedTime += totalTime - currentTime;
        GameManager.remainingTime = currentTime;
        print ( "remaining time is" + GameManager.remainingTime.ToString() );
        ActiveEndPanel ( "win" );
        }

    public void ActiveEndPanel(string state )
        {
        isCountingDown = false;
        au.Stop ( );
        endPanel.SetActive ( true );
        if(state == "win")
            {
            StartCoroutine (Utils.RevealText ( WinText,EndPanelLog,au ));
           // GameManager.level++;

            int buildIndex = SceneUtility.GetBuildIndexByScenePath( $"level{GameManager.level}");
            print ( buildIndex );
            if (buildIndex != -1)
                {
                StartCoroutine ( Utils.waitSeanLoader ( $"level{GameManager.level}",4 ) );
                }
            else
                {
                StartCoroutine ( Utils.waitSeanLoader ( "leaderboard",3 ) );
                }
            
            }
        else {
            if(GameManager.level == 1){LooseText = "GAME OVER";}
            else { LooseText = $"You have compleated {GameManager.level} levels successfully"; }
            
            StartCoroutine (Utils.RevealText ( LooseText,EndPanelLog,au ));
            StartCoroutine (Utils.waitSeanLoader ( "leaderboard",4 ));
            }
        }
    void setYourScore ( )
        {
        if (GameManager.level == 1) { yourScoreText.text = "Hurry Up... \nUse Your time carefully."; }
        else {
            yourScoreText.text = $"You compleated {GameManager.level-1:00} levels \nwithin {(GameManager.allcompleatedTime / 60):00} min and {(GameManager.allcompleatedTime % 60):00} Secs.";
            }

        }
    void setLeaderScore ( )
        {
        Player player = new Player( PlayerPrefs.GetString("fname" + 0.ToString() , "nisal") , PlayerPrefs.GetString("lname" + 0.ToString() , "Perera"), PlayerPrefs.GetInt("levels" + 0.ToString(), 1) ,PlayerPrefs.GetFloat("secs" + 0.ToString(), 6));
        
        HeighScoreText.text = $"Compleated {player.Levels:00} levels\nwithin {(player.Secs / 60):00} min and {(player.Secs % 60):00} Secs.\nBy :\n{player.FirstName} {player.LastName}.";
        }


    public void CheckCamPasswordNGoSettings ( )
        {
        if(CamPasswordInput.text == "shehan")
            {
            CamSettingsPanel.SetActive ( true );
            }

            CamPasswordInput.text = "";
        }

    public void changeCameraPosY (float y)
        {
        transform.position = new Vector3 ( transform.position.x,y,transform.position.z );
        }
    public void changeCameraPosX (float x )
        {
        transform.position = new Vector3 ( x,transform.position.y,transform.position.z );
        }

    public void changeCamerazoom (float zoom )
        {
        mainCamera.orthographicSize =zoom;
        }


    }

