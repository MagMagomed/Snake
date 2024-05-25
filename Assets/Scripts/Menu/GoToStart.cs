using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menu
{
    public class GoToStart : MonoBehaviour
    {
        public void Execute()
        {
            SceneController.GoToStart();
        }
    }
}