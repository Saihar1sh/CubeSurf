using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoSingletonGeneric<UIManager>
{
    [SerializeField]
    private Button playBtn, retryBtn, exitBtn, exitBtn2;

    [SerializeField]
    private Image startImg, retryImg;

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
        startImg.enabled = true;
        retryImg.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void PlayGame()
    {
        CubesManager.Instance.EnableMovement(true);
        startImg.enabled = false;
    }

    public void RetryImageEnable(bool b)
    {
        retryImg.enabled = b;
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
