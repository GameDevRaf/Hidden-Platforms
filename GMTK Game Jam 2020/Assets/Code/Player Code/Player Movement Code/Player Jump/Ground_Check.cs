using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Check : MonoBehaviour {

    #region Variable's

        #region Script's

            [SerializeField]
            private Player_Jump Player_jump;

            [SerializeField]
            private Player_Health Player_health;

        #endregion

        #region Animator's

            [SerializeField]
            private Animator Player_Animator;

        #endregion

    #endregion

    void OnTriggerEnter2D(Collider2D collider) {

        if (collider.tag == Tags.Ground) {

            Player_jump.Player_is_Grounded = true;

            FindObjectOfType <Audio_Manager> ().Play (Tags.Player_Land);

            Player_Animator.SetBool (Tags.Is_Grounded, true);
            
        }

        else if(collider.tag == Tags.Damage_Ground) {

            Player_jump.Player_is_Grounded = true;

            Player_Animator.SetBool (Tags.Is_Grounded, true);

        }
    
        else if(collider.tag == Tags.Healing_Ground) {

            Player_jump.Player_is_Grounded = true;

            FindObjectOfType <Audio_Manager> ().Play (Tags.Player_Heal);

            Player_Animator.SetBool (Tags.Is_Grounded, true);

            Player_health.Gain_Health (2);
            
        }

    }

    void OnTriggerExit2D(Collider2D collider) {

        if (collider.tag == Tags.Ground || collider.tag == Tags.Damage_Ground || collider.tag == Tags.Healing_Ground) {

            Player_jump.Player_is_Grounded = false;
            
        }
        
    }

}
