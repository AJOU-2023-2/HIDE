using UnityEngine;
using static System.Net.Mime.MediaTypeNames;


namespace Michsky.UI.Dark
{
    public class ExitToSystem : MonoBehaviour
    {
        public void ExitGame()
        {

            #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
            #else
                        Application.Quit();
            #endif


        }
    }

}