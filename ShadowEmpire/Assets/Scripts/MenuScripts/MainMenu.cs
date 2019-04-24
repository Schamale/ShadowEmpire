using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShadowEmpire
{
    public class MainMenu : MonoBehaviour
    {
        #region Variables

        #endregion

        #region MyRegion
        public void PlayGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        public void QuitGame()
        {
            Debug.Log("Quit!");
            Application.Quit();
        }
        #endregion
    }

    #region Helper Methods

    #endregion
}
