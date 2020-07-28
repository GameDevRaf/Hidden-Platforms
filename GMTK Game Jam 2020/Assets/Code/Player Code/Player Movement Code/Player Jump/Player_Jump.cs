using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Jump : MonoBehaviour {

    #region Variable's

        #region Script's

            [SerializeField]
            private Player_Health Player_health;

        #endregion

        #region Rigidbody2D Variable's

            [SerializeField]
            private Rigidbody2D Player_Rigidbody;

        #endregion

        #region Animator's

            [SerializeField]
            private Animator Player_Animator;

        #endregion

        #region Float Variable's

            [SerializeField]
            private float Jump_Force = 5f;


            [SerializeField]
            private float Jump_Time;

            private float Jump_Time_Counter;

        #endregion

        #region Bool Variable's

            [HideInInspector]
            public bool Player_is_Grounded = false;

            private bool Player_is_Jumping;

        #endregion

    #endregion

    // Update is called once per frame
    void Update() {

        Jump ();
        
    }

    void Jump() {

        if (Input.GetKeyDown (KeyCode.Z) && Player_is_Grounded == true || Input.GetKeyDown (KeyCode.Space) && Player_is_Grounded == true) {

            Player_is_Jumping = true;
            Jump_Time_Counter = Jump_Time;

            FindObjectOfType <Audio_Manager> ().Play (Tags.Player_Jump);

            Player_Rigidbody.velocity = Vector2.up * Jump_Force;

            Player_Animator.SetBool (Tags.Is_Grounded, false);
            
        }

        if (Input.GetKey (KeyCode.Z) && Player_is_Jumping == true || Input.GetKey (KeyCode.Space) && Player_is_Jumping == true) {

            if (Jump_Time_Counter > 0) {
                
                Player_Rigidbody.velocity = Vector2.up * Jump_Force;

                Jump_Time_Counter -= Time.deltaTime;

            }

            else {

                Player_is_Jumping = false;
                
            }
            
        }

        if (Input.GetKeyUp (KeyCode.Z) || Input.GetKeyUp (KeyCode.Space)) {

            Player_is_Jumping = false;
            
        }

    }

    void OnCollisionEnter2D(Collision2D collision) {

        if(collision.collider.tag == Tags.Damage_Ground) {

            Player_health.Take_Damage (2);

        }

    }

}
