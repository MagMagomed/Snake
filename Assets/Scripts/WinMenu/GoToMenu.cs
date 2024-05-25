using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.WinMenu
{
    public class GoToMenu : MonoBehaviour
    {
        public void Execute()
        {
            SceneController.GoToMenu();
        }
    }
}