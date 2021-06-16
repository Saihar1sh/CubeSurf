using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoSingletonGeneric<UIManager>
{
    [SerializeField]
    private Button playBtn, retryBtn, exitBtn, exitBtn2;

    [SerializeField]
    private Image startImg, retryImg, lvlCompleteImg;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    protected override void Awake()
    {
        base.Awake();
        playBtn.onClick.AddListener(PlayGame);
        retryBtn.onClick.AddListener(RetryScene);
        exitBtn.onClick.AddListener(ExitGame);
        exitBtn2.onClick.AddListener(ExitGame);

    }
    // Start is called before the first frame update
    void Start()
    {
        startImg.gameObject.SetActive(true);
        retryImg.gameObject.SetActive(false);
        lvlCompleteImg.gameObject.SetActive(false);
        scoreText.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score : " + CubesManager.Instance.boxesCollected;
    }

    private void PlayGame()
    {
        startImg.gameObject.SetActive(false);
        CubesManager.Instance.EnableMovement(true);
        scoreText.enabled = true;
    }

    public void LvlCompleted()
    {
        lvlCompleteImg.gameObject.SetActive(true);
    }

    public void RetryImageEnable(bool b)
    {
        retryImg.gameObject.SetActive(b);
    }

    private void RetryScene()
    {
        SceneManager.LoadScene(0);
        RetryImageEnable(false);

    }
    private void ExitGame()
    {
        Application.Quit();
    }
}
