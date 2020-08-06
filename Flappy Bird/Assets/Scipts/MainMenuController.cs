using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public static MainMenuController instance;
    [SerializeField]
    private GameObject[] birds;
    private bool isGreenBirdUnlocked = true;
    private bool isRedBirdUnlocked = true;

    private void Start()
    {
        birds[GameController.instance.getSelectedBird()].SetActive(true);
        checkGreenBird();
        checkRedBird();
    }
    private void Awake()
    {
        makeInstance();

    }

    // Update is called once per frame

    public void Playgame()
    {
        SceneFader.instance.FadeIn("GamePlay");
    }
    void makeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    
    }
    void Update()
    {
        
    }
    void checkRedBird()
    {
        if (GameController.instance.isTheRedBirdUnlocked() == 1)
        {
            isRedBirdUnlocked = true;
        }
    }
    void checkGreenBird()
    {
        if (GameController.instance.isTheGreenBirdUnlocked() == 1)
        {
            isGreenBirdUnlocked = true;
        }
    }

    public void birdyyy()
    {
        birds[0].SetActive(false);
    }
   

    public void changeBird()
    {
        Debug.Log(GameController.instance.getSelectedBird());
        if (GameController.instance.getSelectedBird() == 0)
        {
            Debug.Log("hello");
            if (isGreenBirdUnlocked)
            {
                Debug.Log("bye");
                birds[0].SetActive(false);
                GameController.instance.setSelectedBird(1);
                birds[GameController.instance.getSelectedBird()].SetActive(true);
            }
        }
        else if (GameController.instance.getSelectedBird() == 1)
        {
            if (isRedBirdUnlocked)
            {
                Debug.Log("2");
                birds[1].SetActive(false);
                GameController.instance.setSelectedBird(2);
                birds[GameController.instance.getSelectedBird()].SetActive(true);
            }


            else
            {
                Debug.Log("3");
                birds[1].SetActive(false);
                GameController.instance.setSelectedBird(0);
                birds[GameController.instance.getSelectedBird()].SetActive(true);

            }

        }
        else if (GameController.instance.getSelectedBird() == 2)
        {
            Debug.Log("4");
            birds[2].SetActive(false);
            GameController.instance.setSelectedBird(0);
            birds[GameController.instance.getSelectedBird()].SetActive(true);


        }
        
    
    }


}

