using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip bgmusic , typeSound , click1 , clickPong ,clickPop , defeated;
    public static AudioSource au;
    // Start is called before the first frame update
    void Start()
    {
        au = GetComponent<AudioSource> ( );
        bgmusic = Resources.Load<AudioClip> ( "Sounds/UI sounds/bg-victory" );
        click1 = Resources.Load<AudioClip> ( "Sounds/UI sounds/click1" );
        typeSound = Resources.Load<AudioClip> ( "Sounds/UI sounds/typing" );
        clickPong = Resources.Load<AudioClip> ( "Sounds/UI sounds/click-pong" );
        clickPop = Resources.Load<AudioClip> ( "Sounds/UI sounds/click-pop" );
        defeated = Resources.Load<AudioClip> ( "Sounds/UI sounds/defeated" );
        au.PlayOneShot ( bgmusic );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void playsound (AudioClip AudioClip)
        {
        au.PlayOneShot ( AudioClip );
        }

    public static void stopSound ( )
        {
        au.Pause ( );
        }
}
