using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleReaping : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject pipe;
    [SerializeField]
    private bird b1;

    private float randX;

    private void Awake()
    {
       
        randX = pipe.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private IEnumerator pipeSpawn()
    {
        while(b1.isAlive == true)
        {
            Debug.Log("IM IN");
            randX += 4f;
            float randY = Random.Range(-3.4f, 2.19f);
            Vector3 pos = new Vector3(randX, randY, 0);
            GameObject pipe1 = Instantiate(pipe, pos, Quaternion.identity);
            //pipe1.transform.Translate(Vector3.right * b1.fowardSpeed);
            yield return new WaitForSeconds(1);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (other.name == "PipeCollider")
        {
            Debug.Log("im IMMMMMMM");
            StartCoroutine(pipeSpawn());
        
        }
        
    
    }

}
