using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using mymanager;

public class intro : MonoBehaviour
{
    public float delayBetweenLetters = 0.3f;
    public TMP_Text textComponent;
    public GameObject goGameButton;
    AudioSource au;
    string fullText ="This Game Is Originally Created by \n  BCI Coding Club in 2023...";
    void Start ()
    {
        au = GetComponent<AudioSource> ( );
        StartCoroutine ( Utils.RevealText (fullText, textComponent, goGameButton, au));
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.round = 0;
    }

    

    public void GoToTheGame ( )
        {
        StartCoroutine ( Utils.waitSeanLoader ( "level1",1f ) );
        }

   }