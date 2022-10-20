using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI CountText;
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI finishText;
    public GameObject finishScreen;

    private Rigidbody rb;

    private float movementX;
    private float movementY;
    private int currentLevel;
    private int pickupCount;

    public AudioSource pickSFX;
    public AudioSource greetingSFX;
    // Start is called before the first frame update
    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        finishScreen.SetActive(false);
        rb=GetComponent<Rigidbody>();
        pickupCount=0;
        SetCountText();
        LevelText.text="Level: 0"+ currentLevel.ToString();

    }
    private void OnMove(InputValue movementValue){
        Vector2 movementVactor=movementValue.Get<Vector2>();
        movementX= movementVactor.x;
        movementY=movementVactor.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       Vector3 movement = new Vector3(movementX, 0.0f, movementY);
       rb.AddForce(movement*speed);
    }
    private void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Pick"))
        {
            other.gameObject.SetActive(false);
            pickupCount += 1;
            SetCountText();
            pickSFX.Play();
            
        }
    }
    void SetCountText(){
        CountText.text = "Score: 0" + pickupCount.ToString();
        if (pickupCount >= currentLevel){
            finishScreen.SetActive(true);
            finishText.text = "Level 0" + currentLevel.ToString() + "        completed with Score 0"+ pickupCount.ToString();
            greetingSFX.Play();
        }
    }
}
