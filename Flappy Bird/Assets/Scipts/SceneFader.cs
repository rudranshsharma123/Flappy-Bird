using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    // Start is called before the first frame update


    public static SceneFader instance;
    [SerializeField]
    private GameObject fadeCanvas;

    [SerializeField]
    private Animator anim;

    private void Awake()
    {
        makeSingleton();
    }

    void makeSingleton()
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

    public void FadeIn(string level)
    {
        StartCoroutine(fadeIn(level));
    
    }


    private IEnumerator fadeIn(string level)
    {
        fadeCanvas.SetActive(true);
        anim.Play("FadeIn");
        yield return new WaitForSeconds(0.7f);

        SceneManager.LoadScene(level);
        fadeout();
    
    
    }

    public void fadeout()
    {
        StartCoroutine(fadeOut());
    
    }

    private IEnumerator fadeOut()
    {
        anim.Play("FadeOut");
        yield return new WaitForSeconds(1.0f);
        fadeCanvas.SetActive(false);
           
    
    }


}
