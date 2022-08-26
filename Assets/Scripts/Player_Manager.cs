using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Player_Manager : MonoBehaviour
{
    [SerializeField] InputAction WASD; //keyboard inputs
    
    public Text HitCount_Text;
    int HitCount;

    Rigidbody myRB;
    public float movementSpeed;
    Vector2 movementInput;

    private void OnEnable()
    {
        WASD.Enable(); // Enable Inputs
    }

    private void OnDisable()
    {
        WASD.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>(); // Get Reference of Rigidbody
    }

    private void OnTriggerEnter(Collider other) // if something colliders into player object
    {
        if (other.gameObject.tag == "Bullet") // if the collider is a bullet
        {
            HitCount += 1; // increase hit count by 1
            HitCount_Text.text = HitCount.ToString(); // convert integer value and display as text
        }
    }

    // Update is called once per frame
    void Update()
    {
        movementInput = WASD.ReadValue<Vector2>(); // converting inputs into direction
                
        myRB.velocity = movementInput * movementSpeed; //converting direction into velocity
    }
}
