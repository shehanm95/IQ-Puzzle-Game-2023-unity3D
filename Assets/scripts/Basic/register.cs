using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using mymanager;

public class register : MonoBehaviour
{
    public TMP_InputField first_name ,  last_name , password;
    public TMP_Text log_text;
    public GameObject settingsPanel , LevelsSettingsPanel;
    public Color32 red , green;
    AudioSource au;
    // Start is called before the first frame update
    void Start()
    {
       au = GetComponent<AudioSource> ( );
       // PlayerPrefs.DeleteAll ( );
                                                         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RegisterFunction ( )
        {
        if (first_name.text.Length > 3 && last_name.text.Length > 3)
            {
            au.PlayOneShot ( SoundManager.click1 );

            GameManager.first_name =Utils.FirstLetterUpper( first_name.text);
            GameManager.last_name = Utils.FirstLetterUpper( last_name.text);
            log_text.text = "<color=green>thank you";
            StartCoroutine ( Utils.waitSeanLoader ( "intro" , 1f) );
            }
        else {
            au.PlayOneShot ( SoundManager.clickPong );
            log_text.text = "Please fill your first and last name correctly.";

            }
        }

    public void ActivateSettingsPanel ( )
        {
        if (password.text == "shehan")
            settingsPanel.SetActive ( true );
        }
    public void ActivateLevelSettingsPanel ( )
        {
        if (password.text == "shehan")
            LevelsSettingsPanel.SetActive ( true );
        }

    }
