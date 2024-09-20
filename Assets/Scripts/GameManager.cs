using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CoinManager _coinManager;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private GameObject _startmenu;
    [SerializeField] private GameObject _finishWindow;

    private void Start()
    {
        _levelText.text = SceneManager.GetActiveScene().name;
        _finishWindow.SetActive(false);
    }

    public void Play()
    {
        _startmenu.SetActive(false);   
        FindFirstObjectByType<PlayerBehaviour>().Play();
    }

    public void ShowFinishWindow()
    {
        _finishWindow.SetActive(true);
    }
    
    public void NextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.Log("Current index = " + currentIndex);

        if (currentIndex < SceneManager.sceneCountInBuildSettings)
        {
            _coinManager.SaveToProgress();
            Debug.Log("Scene count = " + SceneManager.sceneCountInBuildSettings);
            SceneManager.LoadScene(currentIndex);
        }
    }
}
