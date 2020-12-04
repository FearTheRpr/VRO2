using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {

    public static BallSpawner current;

    public GameObject pooledBall; //the prefab of the object in the object pool
    public int amountOfBalls;
    public List<GameObject> Balls;
    public static int numberOfBalls;

    void Awake()
    {
        current = this;
    }
    private void Start()
    {
        

        Balls = new List<GameObject>();
        for (int i = 0; i < amountOfBalls; i++)
        {
            GameObject ball = Instantiate(pooledBall);
            ball.SetActive(false);
            Balls.Add(ball);
        }
        InvokeRepeating("SpawnBall", 0f, 0.5f);
    }
    
    public GameObject GetPooledObject()
    {
        for (int i = 0; 1 < Balls.Count; i++)
        {
            if (!Balls[i].activeInHierarchy)
            {
                return Balls[i];
            } 
        }
        return null;
    }
    
   	
    void SpawnBall()
    {
        GameObject selectedBall = BallSpawner.current.GetPooledObject();

        if (selectedBall != null)
        {
            selectedBall.SetActive(true);
            Rigidbody selectedRigidBody = selectedBall.GetComponent<Rigidbody>();
            selectedRigidBody.velocity = new Vector3(0, 0, 0 ); //resets ball velocity
            selectedBall.transform.position = transform.position;
        }

        numberOfBalls++;
        if (numberOfBalls >= amountOfBalls)
        {
            numberOfBalls = 0;
        }
    }
	

   
    
       
    
}
