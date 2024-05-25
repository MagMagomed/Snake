using Assets.Scripts.WinMenu;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class SceneController : MonoBehaviour
    {
        public static SceneController instance = null;
        
        void Start()
        {
            if (instance == null)
            { 
                instance = this; 
            }
            else
            { 
                Destroy(gameObject); 
            }
            
            DontDestroyOnLoad(gameObject);
        }

        public static void GoToMenu()
        {
            SceneManager.LoadScene("Menu");
        }
        public static void GoToLoseMenu()
        {
            SceneManager.LoadScene("LoseMenu");
        }
        public static void GoToWinMenu()
        {
            SceneManager.LoadScene("Win");
        }
        public static void GoToStart()
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
