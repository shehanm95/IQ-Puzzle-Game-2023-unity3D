using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
     public static string first_name,last_name , final_Text ="";
     public static int score , round , level =1 , listcapacity = 6 , maxTries;
    public static float allcompleatedTime , remainingTime , defaultTime , CameraY , CameraX, CameraZoom;
     public static bool gameover;
    void Start()
    {
        CameraY= PlayerPrefs.GetFloat ( "cameray",0 );
        CameraX =PlayerPrefs.GetFloat ( "camerax",0 );
        CameraZoom =PlayerPrefs.GetFloat ( "camerazoom",5 );
        defaultTime = PlayerPrefs.GetFloat ( "defaultTime",120f );
        float defaulftime= PlayerPrefs.GetFloat ( "defaulftime" + level.ToString ( ),30f );
        final_Text = "Your chances are finished.\n\n" +
        "* If you like, you can join our coding club:" +
        "\n\n" +
        "   - Learn Game Development.\n" +
        "   - Learn Web Development.\n" +
        "   - Learn Hacking and Cybersecurity.\n\n" +
        "Please go to the Registration desk and register now.\n\n" +
        "Hand over this PC to the next player.";
        maxTries = PlayerPrefs.GetInt ( "maxtries",3 );
        listcapacity = PlayerPrefs.GetInt ( "listcapacity",6 );
        }
public static float GetTotalTime ( int level )
    {
        float currenttime = PlayerPrefs.GetFloat ( "curTimeLevel" + level.ToString ( ),defaultTime);
        return currenttime;
    }
 }


