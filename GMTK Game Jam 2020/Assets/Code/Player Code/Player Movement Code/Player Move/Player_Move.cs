using System.Collections;
using System.Collections.Generic;
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

        #region Animators

            [SerializeField]
            private Animator Player_Animator;

        #endregion

        #region Audio Source's

            [SerializeField]
            private AudioSource Player_Walking_Sound;

        #endregion

        #region Vector3 Variable's
        
            private Vector3 Movement;

        #endregion

        #region Float Variable's

            [SerializeField]
            private float Move_Speed = 5f;

            [HideInInspector]
            public float X_Movement;

        #endregion

    #endregion

    // Update is called once per frame
    void Update() {

        #region Flip Player ( When Moving Left )

            if (Movement.x > 0) {
            
                Player_Transform.eulerAngles = new Vector3 (0f, 0f, 0f);

            }

            else if(Movement.x < 0) {

                Player_Transform.eulerAngles = new Vector3 (0f, 180f, 0f);

            }

        #endregion

        X_Movement = Input.GetAxisRaw (Tags.Horizontal_Movement);

        Movement.x = X_Movement;

        Player_Transform.position += Movement * Time.deltaTime * Move_Speed;

        Player_Animator.SetFloat (Tags.Speed, Mathf.Abs (X_Movement));

        #region Player Walking Sound

            if (Player_jump.Player_is_Grounded == true && Movement.x > 0 && Player_Walking_Sound.isPlaying == false || Player_jump.Player_is_Grounded == true && Movement.x < 0 && Player_Walking_Sound.isPlaying == false) {
            
                Player_Walking_Sound.volume = Random.Range (0.18f, 0.42f);
                Player_Walking_Sound.pitch = Random.Range (0.7f, 1.1f);

                Player_Walking_Sound.Play ();

                Debug.Log ("Playing Walking Sound");


            }


            else if(Player_jump.Player_is_Grounded == false && Player_Walking_Sound.isPlaying == true || Movement.x == 0) {

                Player_Walking_Sound.Stop ();

                Debug.Log ("Stopping Walking Sound");

            }

        #endregion

    }

}
