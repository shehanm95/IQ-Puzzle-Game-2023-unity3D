using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using mymanager;

public class membership : MonoBehaviour
{
    public TMP_Text HandOverText;
    public GameObject handOverPanelButton;
    string text = GameManager.final_Text;
       
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine( Utils.RevealText ( text,HandOverText,handOverPanelButton,GetComponent<AudioSource> ( ) ));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void displayHandoverText ( )
        {

        }
}
