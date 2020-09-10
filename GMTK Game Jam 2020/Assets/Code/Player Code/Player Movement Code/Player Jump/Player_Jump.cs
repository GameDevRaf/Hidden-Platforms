using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
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

        #region Particle's

            [SerializeField]
            private ParticleSystem Dust_Cloud;

        #endregion

        #region Animator's

            [SerializeField]
            private Animator Player_Animator;

        #endregion

        #region Input System's

            Keyboard keyboard;

            Gamepad Controller;

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



            private bool Controller_is_Connected = false;

            private bool Keyboard_is_Connected = false;

        #endregion

    #endregion

    void Start() {


        
    }

    void Update() {

        Jump ();

        #region Check what Input Device's are Connected

            // See if the Controller is Connected
            if (Gamepad.current != null) {

                Controller = Gamepad.current;

                Controller_is_Connected = true;

                Debug.Log ("The Controller is: " + Controller_is_Connected);

                return;

            }

            else {

                Controller_is_Connected = false;

            }
            // End Comment.





        }

    #endregion

    void Jump() {

        if (Keyboard_is_Connected == true) {

            if (Keyboard.current.zKey.wasPressedThisFrame && Player_is_Grounded == true || 

            Keyboard.current.upArrowKey.wasPressedThisFrame && Player_is_Grounded == true || 

            Keyboard.current.wKey.wasPressedThisFrame && Player_is_Grounded == true || 

            Keyboard.current.spaceKey.wasPressedThisFrame && Player_is_Grounded == true) {

                Player_is_Jumping = true;
                Jump_Time_Counter = Jump_Time;

                Dust_Cloud.Play ();

                FindObjectOfType <Audio_Manager> ().Play (Tags.Player_Jump);

                Player_Rigidbody.velocity = Vector2.up * Jump_Force;

                Player_Animator.SetBool (Tags.Is_Grounded, false);

            }

            if (Keyboard.current.zKey.isPressed && Player_is_Jumping == true || 

            Keyboard.current.upArrowKey.isPressed && Player_is_Jumping == true || 

            Keyboard.current.wKey.isPressed && Player_is_Jumping == true || 

            Keyboard.current.spaceKey.isPressed && Player_is_Jumping == true) {

                if (Jump_Time_Counter > 0) {

                    Player_Rigidbody.velocity = Vector2.up * Jump_Force;

                    Jump_Time_Counter -= Time.deltaTime;

                }

                else {

                    Player_is_Jumping = false;

                }

            }

            if (Keyboard.current.zKey.wasReleasedThisFrame || 

            Keyboard.current.upArrowKey.wasReleasedThisFrame || 

            Keyboard.current.wKey.wasReleasedThisFrame || 

            Keyboard.current.spaceKey.wasReleasedThisFrame) {

                Player_is_Jumping = false;

            }

        }

        if (Controller_is_Connected == true) {

            if (Controller.buttonSouth.wasPressedThisFrame && Player_is_Grounded == true || 

                Controller.dpad.up.wasPressedThisFrame && Player_is_Grounded == true) {

                Player_is_Jumping = true;
                Jump_Time_Counter = Jump_Time;

                Dust_Cloud.Play ();

                FindObjectOfType <Audio_Manager> ().Play (Tags.Player_Jump);

                Player_Rigidbody.velocity = Vector2.up * Jump_Force;

                Player_Animator.SetBool (Tags.Is_Grounded, false);

            }

            if (Controller.buttonSouth.isPressed && Player_is_Jumping == true || 

            Controller.dpad.up.isPressed && Player_is_Jumping == true) {

                if (Jump_Time_Counter > 0) {

                    Player_Rigidbody.velocity = Vector2.up * Jump_Force;

                    Jump_Time_Counter -= Time.deltaTime;

                }

                else {

                    Player_is_Jumping = false;

                }

            }

            if (Controller.buttonSouth.wasReleasedThisFrame || 

            Controller.dpad.up.wasReleasedThisFrame) {

                Player_is_Jumping = false;

            }

        }

    }

    void FixedUpdate() {

        // See if the Keyboard is connected
        if (Keyboard.current != null) {

            keyboard = Keyboard.current;

            Keyboard_is_Connected = true;

            Debug.Log ("The Keyboard is: " + Keyboard_is_Connected);

            return;

        }

        else {

            Keyboard_is_Connected = false;

        }
        // End Comment.

    }

    void OnCollisionEnter2D(Collision2D collision) {

        if(collision.collider.tag == Tags.Damage_Ground) {

            Player_health.Take_Damage (2);

        }

    }

}
