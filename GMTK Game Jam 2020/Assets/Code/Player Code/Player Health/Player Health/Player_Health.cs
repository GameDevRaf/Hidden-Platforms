using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour {

    #region Variable's

        #region Script's

            public Health_Bar Health_bar;

            public Player_Move Player_move;

        #endregion

        #region Animator

            [SerializeField]
            private Animator Player_Animator;

        #endregion

        #region Integer Variable's

            [Space]
            public int Max_Health = 6;

            public int Current_Health;

        #endregion

    #endregion

    void Start() {

        Current_Health = Max_Health;

        Health_bar.Set_Max_Health (Max_Health);

    }

    void Update() {

        if (Input.GetKeyDown (KeyCode.Q)) {

            Take_Damage (2);
            
        }

        if(Input.GetKeyDown (KeyCode.E)) {

            Gain_Health (2);

        }

    }

    public void Take_Damage(int Damage_Amount) {

        Current_Health -= Damage_Amount;

        if (Current_Health <= 0) {
            
            Current_Health = 0;

            SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);

        }

        Health_bar.Set_Health (Current_Health);

        StartCoroutine (Play_Damage_Animation ());

    }

    public void Gain_Health(int Gain_Health_Amount) {

        Current_Health += Gain_Health_Amount;

        if (Current_Health > Max_Health) {
            
            Current_Health = Max_Health;

        }

        Health_bar.Set_Health (Current_Health);

        Player_Animator.SetBool (Tags.Is_Grounded, true);
        Player_Animator.SetFloat (Tags.Speed, -1);

    }

    IEnumerator Play_Damage_Animation() {

        Player_Animator.SetBool (Tags.Damage_Taken, true);

        yield return new WaitForSeconds (0.32f);

        Player_Animator.SetBool (Tags.Damage_Taken, false);

    }

}
