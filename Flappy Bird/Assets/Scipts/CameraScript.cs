using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private bird b1;
    public static float offsetX;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (b1.isAlive)
        {
            moveCamera();
        }
    }

    void moveCamera()
    {
        Vector3 temp = transform.position;
        temp.x = b1.myXpos() + offsetX;
        transform.position = temp;
    
    }
}
