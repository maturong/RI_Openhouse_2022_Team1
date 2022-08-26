using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bad_Boss_Manager : MonoBehaviour
{
    //Define variables 
    public GameObject Bullet;
    public GameObject Target;
    public float Bullet_Speed;
    Vector3 Bullet_Direction;
    Vector3 Destination;
    public float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spam_Bullets()); // Executes spamming of bullets
        StartCoroutine(Random_Movement()); // Executes spamming of bullets
    }

    //Spams Bullets
    IEnumerator Spam_Bullets()
    {
        while (true)
        {
            GameObject new_Bullet = Instantiate(Bullet, transform.position, Quaternion.identity); // spawns bullet at the boss's position

            Bullet_Direction = Target.transform.position - transform.position; // Finding the Direction of target relative to origin of bullet (Boss's position)

            new_Bullet.GetComponent<Rigidbody>().AddForce(Bullet_Direction * Bullet_Speed); // Sets the direction and speed of bullet

            yield return new WaitForSeconds(3.0f); //Interval between bullets, current set at 3 seconds
        }
    }

    IEnumerator Random_Movement()
    {
        while (true)
        {
            Destination = new Vector3(Random.Range(-7f, 7f), Random.Range(-4f, 4f), 0f);

            yield return new WaitForSeconds(3.0f); //Interval between bullets, current set at 3 seconds
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Destination, movementSpeed);
    }
}
