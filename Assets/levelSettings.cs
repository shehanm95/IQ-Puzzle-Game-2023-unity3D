using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using mymanager;
using UnityEngine.SceneManagement;

public class levelSettings: MonoBehaviour
    {
    public TMP_Text FinalLevelList;
    public TMP_InputField HowManyLevelsText,DefaultTimeText,SpeciaficLevelText , SpecialTimeText , NvigateLevelText;
    int TotalLevels;
    // Start is called before the first frame update
    void Start ( )
        {
        TotalLevels = GetTotalLevels ( );
        HowManyLevelsText.text = $"{TotalLevels:00}";
        DefaultTimeText.text = GameManager.defaultTime.ToString ( );


        createLevelList ( TotalLevels );
        }

    public void createLevelList ( int HowmanyLevels )
        {
        string finalLevelString ="Level Times.\n\n";
        for (int i = 1 ; i <= HowmanyLevels ; i++)
            {
            finalLevelString += $"Level {i:00}. Time : {GameManager.GetTotalTime ( i ):00}.\n";
            }
        FinalLevelList.text = finalLevelString;

        }


    public void RetriveList ( )
        {
        FinalLevelList.text = "";
        PlayerPrefs.SetInt ( "totallevels",Utils.ConvertToInt ( HowManyLevelsText,15 ) );
        TotalLevels =GetTotalLevels ( );
        createLevelList (TotalLevels);
        }

    int GetTotalLevels ( ){
        TotalLevels =  PlayerPrefs.GetInt( "totallevels",15 );
        return TotalLevels;
        }

    public void setDefaultTime ( )
        {
        PlayerPrefs.SetFloat ( "defaultTime",Utils.ConvertToFloat ( DefaultTimeText,120f ) );
        GameManager.defaultTime =  PlayerPrefs.GetFloat ( "defaultTime",Utils.ConvertToFloat ( DefaultTimeText,30f ) );
        createLevelList ( TotalLevels);
        }

    public void SpecificLevelTime ()
        {
        int level = Utils.ConvertToInt(SpeciaficLevelText , 00);
        PlayerPrefs.SetFloat ( "curTimeLevel" + level.ToString ( ),Utils.ConvertToFloat(SpecialTimeText,GameManager.defaultTime));
        createLevelList ( TotalLevels );
        }

    public void GoLevel ( )
        {
        int levelnum = Utils.ConvertToInt ( NvigateLevelText,0 );
        int buildIndex = SceneUtility.GetBuildIndexByScenePath( $"level{levelnum}");
        print ( buildIndex );
        if(buildIndex != -1){
            StartCoroutine ( Utils.waitSeanLoader ( $"level{levelnum}",3 ) ); }
        else
            {
            StartCoroutine ( Utils.waitSeanLoader ( "registration",3 ) );
            }
        }

        public void DeleteAllTimes ( )
        {
        for(int i = 1 ; i <= TotalLevels ; i++)
            {
            PlayerPrefs.DeleteKey ( $"curTimeLevel{i}" );
            createLevelList ( TotalLevels );
            }
        }


    }
