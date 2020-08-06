using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameController instance;
    private const string HighScore = "High Score";
    private const string SelectedBird = "Selected Bird";
    private const string GreenBird = "Green Bird";
    private const string RedBird = "Red Bird";
    private void Awake()
    {
        makesingleton();
        isTheGameRunForTheFirstTime();
        //PlayerPrefs.DeleteAll();

    }

    // Update is called once per frame

    private void makesingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);

        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    private void isTheGameRunForTheFirstTime()
    {
        if (!PlayerPrefs.HasKey("isTheGameRunForTheFirstTime"))
        {
            PlayerPrefs.SetInt(HighScore, 0);
            PlayerPrefs.SetInt(SelectedBird, 0);
            PlayerPrefs.SetInt(GreenBird, 1);
            PlayerPrefs.SetInt(RedBird, 1);
            PlayerPrefs.SetInt("isTheGameRunForTheFirstTime", 0);

        }

    }
    public void setHighScore(int high)
    {
        PlayerPrefs.SetInt(HighScore, high);
    }
    public int getHighScore()
    {
        return PlayerPrefs.GetInt(HighScore);

    }
    public void setSelectedBird(int bird)
    {
        PlayerPrefs.SetInt(SelectedBird, bird);
    }
    public int getSelectedBird()
    {
        return PlayerPrefs.GetInt(SelectedBird);
    }
    public void UnlockTheGreenBird()
    {
        PlayerPrefs.SetInt(GreenBird, 1);
    }

    public int isTheGreenBirdUnlocked()
    {
        return PlayerPrefs.GetInt(GreenBird);
    }
    public void UnlockTherRedBird()
    {
        PlayerPrefs.SetInt(RedBird, 1);
    }
    public int isTheRedBirdUnlocked()
    {
        return PlayerPrefs.GetInt(RedBird);
    }
    

    void Update()
    {
        
    }
}
