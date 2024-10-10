using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class camerasettings : MonoBehaviour
{
    public UIController camera;
    // Start is called before the first frame update
    void Start()
    {
        //camera = camera.GetComponent<UIController> ( );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setCameraY (float Y)
        {
        GameManager.CameraY = Y;
        camera.changeCameraPosY ( Y );

        }
    public void setCameraX ( float X )
        {
        GameManager.CameraX = X;
        camera.changeCameraPosX ( X );

        }
    public void setCamerazoom ( float zoom )
        {
        GameManager.CameraZoom = zoom;
        camera.changeCamerazoom ( zoom );

        }
    public void saveCameraSettings ( )
        {
        PlayerPrefs.SetFloat ( "cameray",GameManager.CameraY  );
        PlayerPrefs.SetFloat ( "camerax",GameManager.CameraX );
        PlayerPrefs.SetFloat ( "camerazoom",GameManager.CameraZoom );
        }


    }
