using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    // Start is called before the first frame update

    public static GamePlayController instance;
    [SerializeField]
    private Text scoreText, endScore, bestScore, gameOverText;

    [SerializeField]
    private Button restartGameButton;
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private GameObject[] birds;
    [SerializeField]
    private Sprite[] medals;
    [SerializeField]
    private Image medalImage;

    private void Awake()
    {
        makeInstance();
    }

    void makeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    // Update is called once per frame


    public void pauseGame()
    {
        if (bird.myBird != null)
        {
            if (bird.myBird.isAlive)
            {
                pausePanel.SetActive(true);
                gameOverText.gameObject.SetActive(false);
                endScore.text = "" + bird.myBird.score;
                bestScore.text = "" + GameController.instance.getHighScore();
                Time.timeScale = 0f;
                restartGameButton.onClick.RemoveAllListeners();
                restartGameButton.onClick.AddListener(() => resumegame());

            }

        }
    }


    public void goToMenuButton()
    {
        SceneFader.instance.FadeIn("mainMenu");
    }

    public void resumegame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;


    }

    public void restartGame()
    {
        SceneFader.instance.FadeIn("GamePlay");
    
    }

    public void playGame()
    {

        scoreText.gameObject.SetActive(true);
        birds[GameController.instance.getSelectedBird()].SetActive(true);
        Time.timeScale = 1f;



    }

    public void setscore(int score)
    {
        scoreText.text = "" + score;
     
    
    }


    public void playerDieShowScore(int score)
    {

        pausePanel.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);

        endScore.text = "" + score;
        if (score > GameController.instance.getHighScore())
        {
            GameController.instance.setHighScore(score);
        
        }
        bestScore.text = "" + GameController.instance.getHighScore();

        if (score <= 20)
        {
            medalImage.sprite = medals[0];

        }
        else if (score > 20 && score < 40)
        {
            medalImage.sprite = medals[0];

            if (GameController.instance.isTheGreenBirdUnlocked() == 0)
            {
                GameController.instance.UnlockTheGreenBird();
            }
        }
        else 
        {
            medalImage.sprite = medals[2];

            if (GameController.instance.isTheGreenBirdUnlocked() == 0)
            {
                GameController.instance.UnlockTheGreenBird();
            }
        }
        if (GameController.instance.isTheRedBirdUnlocked() == 0)
        {
            GameController.instance.UnlockTherRedBird();
        }

        restartGameButton.onClick.RemoveAllListeners();
        restartGameButton.onClick.AddListener(() => restartGame());
           
    }






    
    void Update()
    {
        
    }
}
