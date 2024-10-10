using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using mymanager;
using System;

public class settingsPanel : MonoBehaviour
{
    public TMP_InputField MaxAttemptsText , FinalTextsText , MaxLeaderboardText;

    // Start is called before the first frame update
    void Start()
    {
        MaxAttemptsText.text = GameManager.maxTries.ToString ("00" );
        MaxLeaderboardText.text = GameManager.listcapacity.ToString ( "00" );
        FinalTextsText.text = GameManager.final_Text.ToString ( );

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveMaxAttempts ( )
        {
        print ( "tried" );
        try
            {
            if (Int32.Parse ( MaxAttemptsText.text ).GetType ( ) == typeof ( int ))
                {
                int maxt = Int32.Parse ( MaxAttemptsText.text );
                if (maxt == 0) maxt = 3;
                PlayerPrefs.SetInt ( "maxtries",maxt);
                maxt = PlayerPrefs.GetInt ( "maxtries",100 );
                MaxAttemptsText.text= maxt.ToString("00");
                print ( "correctly saved");
                }
            }
        catch (Exception e)
            {
            //handle error
            PlayerPrefs.SetInt ( "maxtries",3 );
            int maxt = PlayerPrefs.GetInt ( "maxtries",100 );
            MaxAttemptsText.text = maxt.ToString ( "00" );
            Debug.Log ( e.Message );
            print ( "error catched" );
            }
        }

    public void SaveMaxLeaderBoardValue ( )
        {
        print ( "tried" );
        try
            {
            if (Int32.Parse ( MaxLeaderboardText.text ).GetType ( ) == typeof ( int ))
                {
                int maxt = Int32.Parse ( MaxLeaderboardText.text );
                if (maxt == 0) maxt = 6;
                PlayerPrefs.SetInt ( "listcapacity",maxt );
                maxt = PlayerPrefs.GetInt ( "listcapacity",100 );
                MaxLeaderboardText.text = maxt.ToString ( "00" );
                print ( "correctly saved" );
                }
            }
        catch (Exception e)
            {
            //handle error
            PlayerPrefs.SetInt ( "listcapacity",6 );
            int maxt = PlayerPrefs.GetInt ( "listcapacity",100 );
            MaxLeaderboardText.text = maxt.ToString ( "00" );
            Debug.Log ( e.Message );
            print ( "error catched" );
            }
        }

    public void SaveFinalText ( )
        {
        try
            {
            if (FinalTextsText.text.Length > 30)
                {
                PlayerPrefs.SetString ( "final_text",FinalTextsText.text );
                string finaltxt = PlayerPrefs.GetString ( "final_text",GameManager.final_Text );
                FinalTextsText.text = finaltxt;
                print ( "final_text" );
                }
            }
        catch (Exception e)
            {
            //handle error
            string finaltxt = PlayerPrefs.GetString ( "final_text",GameManager.final_Text );
            FinalTextsText.text = finaltxt;
            Debug.Log ( e.Message );
            print ( "error catched" );
            }
        }


    public void deleteAll ( )
        {
        print ( "all saved items are deleted" );
        PlayerPrefs.DeleteAll ( );

        }

    public void deleteLeaderBoardValues ( )
        {
        print ( "all saved items are deleted" );
        for (int i = 0 ; i < GameManager.listcapacity ; i++)
            {
            PlayerPrefs.DeleteKey ( "fname" + i.ToString ( ));
            PlayerPrefs.DeleteKey ( "lname" + i.ToString ( ) );
            PlayerPrefs.DeleteKey ( "score" + i.ToString());
            
            }

        }

    }
