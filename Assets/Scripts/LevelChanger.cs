
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    private string _levelToLoad;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)) {
            FadeToLevel("Level_1");
        }
        
    }

    public void FadeToLevel (string levelName) {
        _levelToLoad = levelName;
        _animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete() {
        SceneManager.LoadScene(_levelToLoad);
    }
}
