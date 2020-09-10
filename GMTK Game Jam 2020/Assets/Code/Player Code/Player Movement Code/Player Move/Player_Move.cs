using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Player_Move : MonoBehaviour {

    #region Variable's

        #region Script's

            [SerializeField]
            private Player_Jump Player_jump;

        #endregion

        #region Transform's

            [SerializeField]
            private Transform Player_Transform;

        #endregion

        #region Particle's

            [SerializeField]
            private ParticleSystem Dust_Cloud;

        #endregion

        #region Animators

            [SerializeField]
            private Animator Player_Animator;

        #endregion

        #region Audio Source's

            [SerializeField]
            private AudioSource Player_Walking_Sound;

        #endregion

        #region Input Action's

            private Input_Master Controls;

        #endregion

        #region Float Variable's

            [SerializeField]
            private float Move_Speed = 5f;

            [HideInInspector]
            public float X_Movement;

        #endregion

        #region Boolean Variable's

            private bool Player_is_Facing_Right;

        #endregion

    #endregion

    void Awake() {

        Controls = new Input_Master ();

    }

    void Update() {
    
        X_Movement = Controls.Player.Movement.ReadValue <float> ();

        Move ();

    }

    void Move() {

        #region Flip Player ( When Moving Left )

            if (Player_is_Facing_Right == true) {

                if (X_Movement > 0) {
            
                    Player_Transform.eulerAngles = new Vector3 (0f, 0f, 0f);

                }

                else if(X_Movement < 0) {

                    if (Player_jump.Player_is_Grounded == true) {

                        Dust_Cloud.Play ();

                    }

                    Player_is_Facing_Right = false;

                }

            }

            else if (Player_is_Facing_Right == false) {

                if(X_Movement < 0) {

                    Player_Transform.eulerAngles = new Vector3 (0f, 180f, 0f);

                }

                else if(X_Movement > 0) {

                    if (Player_jump.Player_is_Grounded == true) {

                        Dust_Cloud.Play ();

                    }

                    Player_is_Facing_Right = true;

                }

            }

        #endregion

        Vector3 Movement = new Vector3 (X_Movement * Time.deltaTime * Move_Speed, 0, 0);

        Player_Transform.position += Movement;

        Player_Animator.SetFloat (Tags.Speed, Mathf.Abs (X_Movement));

        #region Player Walking Sound

            if (Player_jump.Player_is_Grounded == true && X_Movement > 0 && Player_Walking_Sound.isPlaying == false || 
            Player_jump.Player_is_Grounded == true && X_Movement < 0 && Player_Walking_Sound.isPlaying == false) {
            
                Player_Walking_Sound.volume = Random.Range (0.18f, 0.42f);
                Player_Walking_Sound.pitch = Random.Range (0.7f, 1.1f);

                Player_Walking_Sound.Play ();


            }


            else if(Player_jump.Player_is_Grounded == false && Player_Walking_Sound.isPlaying == true || X_Movement == 0) {

                Player_Walking_Sound.Stop ();

            }

        #endregion

    }

    #region Enable and Disable Controls

        private void OnEnable() {

            Controls.Enable ();
        
        }

        private void OnDisable() {

            Controls.Disable ();
        
        }

    #endregion

}
