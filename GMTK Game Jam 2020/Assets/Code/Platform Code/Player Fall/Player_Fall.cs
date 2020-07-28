using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class Player_Fall : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider) {

        if (collider.tag == Tags.Player) {
            
            SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);

        }
        
    }

}
