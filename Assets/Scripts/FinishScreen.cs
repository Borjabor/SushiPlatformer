using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class FinishScreen : MonoBehaviour
{

    private void Start() {
        Cursor.visible = true;
    }

    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit() {
        Application.Quit();
    }



}
