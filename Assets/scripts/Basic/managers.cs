using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

namespace mymanager
    {
    public class Player
        {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Levels { get; set; }
        public float Secs { get; set; }
        public Player ( string first_name,string last_name,int levels, float secs )
            {
            FirstName = first_name;
            LastName = last_name;
            Levels = levels;
            Secs = secs;
            }
        }

    static class Utils
        {

        public static int ConvertToInt (string InputString , int Default )
            {
            try
                {
                return System.Int32.Parse(InputString);
               
                }
            catch (System.FormatException)
                {
                return Default;
                }
            }
        public static int ConvertToInt ( TMP_InputField InputField,int Default)
            {
            try
                {
                return System.Int32.Parse ( InputField.text );

                }
            catch (System.FormatException)
                {
                InputField.text = $"{Default:00}";
                System.Console.WriteLine( "returnDefault" );
                return Default;
                }
            }

        public static float ConvertToFloat ( TMP_InputField InputField,float Default )
            {
            try
                {
                return float.Parse ( InputField.text );

                }
            catch (System.FormatException)
                {
                InputField.text = $"{Default:00}";
                System.Console.WriteLine ( "returnDefault" );
                return Default;
                }
            }


        public static string FirstLetterUpper (string Word)
            {
            string UpperWord = Word.First ( ).ToString ( ).ToUpper ( ) + Word.Substring ( 1 );
            return UpperWord;
            }

        public static IEnumerator waitSeanLoader ( string SceneName,float waitTime )
            {
            yield return new WaitForSeconds ( waitTime );
            SceneManager.LoadScene ( SceneName );
            }
        public static IEnumerator waitSeanLoader ( string SceneName,float waitTime , AudioSource au )
            {
            au.PlayOneShot ( SoundManager.click1 );
            yield return new WaitForSeconds ( waitTime );
            SceneManager.LoadScene ( SceneName );
            }



        public static void textUpdater ( TMP_Text textObj,string text_value )
            {
            textObj.text = text_value;
            }


        public static IEnumerator RevealText (string fullText , TMP_Text textComponent , GameObject ObjectToActivate)
            {
            SoundManager.playsound ( SoundManager.typeSound );
            foreach (char c in fullText)
                {
                textComponent.text += c;
                float delaytime =Random.Range ( 0.1f,0.3f );
                yield return new WaitForSeconds ( delaytime );
                }
            SoundManager.stopSound ( );
            yield return new WaitForSeconds ( 1f );
            ObjectToActivate.gameObject.SetActive ( true );

            }

        public static IEnumerator RevealText ( string fullText,TMP_Text textComponent,GameObject ObjectToActivate,AudioSource audioSource )
            {
            audioSource.PlayOneShot ( SoundManager.typeSound );
            foreach (char c in fullText)
                {
                textComponent.text += c;
                float delaytime =Random.Range ( 0.01f,0.1f );
                yield return new WaitForSeconds ( delaytime );
                }
            audioSource.Stop ( );
            yield return new WaitForSeconds ( 1f );
            audioSource.PlayOneShot ( SoundManager.clickPop );
            ObjectToActivate.gameObject.SetActive ( true );

            }
        public static IEnumerator RevealText ( string fullText,TMP_Text textComponent,AudioSource audioSource )
            {
            audioSource.PlayOneShot ( SoundManager.typeSound );
            foreach (char c in fullText)
                {
                textComponent.text += c;
                float delaytime =Random.Range ( 0.01f,0.1f );
                yield return new WaitForSeconds ( delaytime );
                }
            audioSource.Stop ( );
            yield return new WaitForSeconds ( 1f );

            }
        }



   

    }