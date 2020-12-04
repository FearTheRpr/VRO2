using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{


    private void OnCollisionEnter(Collision col)
    {

        

        if (col.gameObject.tag == "Trampoline") //if this object collides with another tagged "Trampoline"
        {
            gameObject.SetActive(false);
           
            
        }
    }
}
