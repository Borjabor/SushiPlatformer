 
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField]
    GameObject _creditsScreen;

    private void Start() {
        Cursor.visible = true;
    }

    public void StartGame() {
        CollectiblesCounter.TotalPoints = 0;
        Cursor.visible = false;
        SceneManager.LoadScene("Level_1");
        Time.timeScale = 1;
    }

    public void StartGym() {
        CollectiblesCounter.TotalPoints = 0;
        Cursor.visible = false;
        SceneManager.LoadScene("Level_Gym2");
        Time.timeScale = 1;
    }

    public void Exit() {
        Application.Quit();
    }

    public void ShowCredits() {
        _creditsScreen.SetActive(true);
        //SceneManager.LoadScene("Credits");
    }

    public void GoBackToMenu() {
        _creditsScreen.SetActive(false);
    }
}
