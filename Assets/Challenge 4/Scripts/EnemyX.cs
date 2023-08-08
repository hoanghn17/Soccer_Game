using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public List<Color> Colors = new List<Color>();

    public float speed;

    private Rigidbody enemyRb;

    private GameObject playerGoal;

    private SpawnManagerX spawnManager;

    //public int pointValue = 0;

    private GameManager gameManagerX;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();

        playerGoal = GameObject.Find("Player Goal");

        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManagerX>();

        ChangeColor();
    }

    // Update is called once per frame
    void Update()
    {
        speed = spawnManager.increaseSpeed;
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);
    }
    private void ChangeColor()
    {
        GetComponent<MeshRenderer>().material.color = Colors[Random.Range(0, Colors.Count)];
    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
            //gameManagerX.UpdateScore(pointValue);
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }
    }

}
