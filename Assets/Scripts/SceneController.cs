using Assets.Scripts.WinMenu;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class SceneController : MonoBehaviour
    {
        public static SceneController instance = null;
        public static UnityAction OnLose { get; set; }
        
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
        public static void Lose()
        {
            if(OnLose != null) OnLose.Invoke();
            GoToLoseMenu();
        }
        public static void GoToLoseMenu()
        {
            SceneManager.LoadScene("LoseMenu", LoadSceneMode.Additive);
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
