using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class bird : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Animator anim;
    
    [SerializeField]
    private Rigidbody2D myRigidBody;
    
    
    public static bird myBird;
    private Button b1;

    private bool didFlap;

    public bool isAlive;
    [SerializeField]
    public float fowardSpeed = 3.0f;
    private float flapSpeed = 200.0f;


    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip flap, die, point;
    public int score = 0;
    private void Awake()
    {
        if (myBird == null)
        {
            myBird = this;
        }
        isAlive = true;

        b1 = GameObject.Find("FlapButton").GetComponent<Button>();
       
        // this is basically the code for adding the button onClickEvent like we do from the inspector panel
        b1.onClick.AddListener(() => MakeFlap());
        camOffset();
    
    }
    void Start()
    {
        myRigidBody.velocity = Vector2.right * fowardSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isAlive == true)
        {

            
            if (didFlap)
            {
                didFlap = false;
               

                myRigidBody.AddForce(Vector2.up * flapSpeed);
                anim.SetTrigger("Flap");
                audioSource.PlayOneShot(flap);
            }

            if (myRigidBody.velocity.y >= 0)
            {
                transform.rotation = quaternion.Euler(0, 0, 0);


            }
            else 
            {
                float angle = 0f;
                angle = Mathf.Lerp(0f, -90f, 0.25f);
                transform.rotation = quaternion.Euler(0, 0, Mathf.Clamp(Mathf.Lerp(0,-90, -myRigidBody.velocity.y/12  * Time.deltaTime), -90, 0 ));

            }
        }
    }
    private void camOffset()
    {

        CameraScript.offsetX = Camera.main.transform.position.x - transform.position.x -1;
    }
    public void MakeFlap()
    {
        didFlap = true;
    
    }

    public float myXpos()
    {
        return transform.position.x;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Pipe" || other.gameObject.tag == "ground")
        {
            if (isAlive)
            {
                isAlive = false;
                audioSource.PlayOneShot(die);
                anim.SetTrigger("BirdDie");

                GamePlayController.instance.playerDieShowScore(score);
            }
        
        }
    
    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PipeHolder")
        {
            score++;
            GamePlayController.instance.setscore(score);
            audioSource.PlayOneShot(point);
            
        }
    }

}
