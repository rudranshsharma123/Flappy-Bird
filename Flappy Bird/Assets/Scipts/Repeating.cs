using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Repeating : MonoBehaviour
{
    // Start is called before the first frame update
    
    private GameObject[] background;
    private GameObject[] ground;
    float lastBGX;
    float lastGroundX;
    private void Awake()
    {
        background = GameObject.FindGameObjectsWithTag("Background");
        ground = GameObject.FindGameObjectsWithTag("ground");
         lastBGX = background[0].transform.position.x;
         lastGroundX = ground[0].transform.position.x;

        for (int i = 1; i < background.Length; i++)
        {
            if (lastBGX < background[i].transform.position.x)
            {
                lastBGX = background[i].transform.position.x;
            }
        
        }
        for (int i = 1; i < ground.Length;  i++)
        {
            if (lastGroundX < ground[i].transform.position.x)
            {
                lastGroundX = ground[i].transform.position.x;
            }

        
        
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Background")
        {
            Vector3 temp = other.transform.position;
            //typecasting
            float width = ((BoxCollider2D)other).size.x;
           
            temp.x = lastBGX + width;
            Debug.Log("hola");
            other.transform.position = temp;
            lastBGX = temp.x;
        }
        else if (other.tag == "ground")
        {
            Vector3 temp = other.transform.position;
            float width = ((BoxCollider2D)other).size.x;

            temp.x = lastGroundX + width;
            other.transform.position = temp;
            lastGroundX = temp.x;
        
        }   
        else if (other.tag == "Pipe")
        {

            Debug.Log("JFISHFSIDFHSLKDFLKSDDFHLKSDHFLKSDDHFKSL");
            Destroy(other.gameObject);
        }
    }
}
