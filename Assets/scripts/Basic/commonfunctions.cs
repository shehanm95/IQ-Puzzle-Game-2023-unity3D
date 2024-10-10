using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mymanager;

public class commonfunctions : MonoBehaviour
{
    AudioSource au;

    private void Start ( )
        {
        au = GetComponent<AudioSource> ( );
        }
    public void GoToscene ( string seanName )
        {
        StartCoroutine ( Utils.waitSeanLoader ( seanName,1f , au ) );
        }

    }
