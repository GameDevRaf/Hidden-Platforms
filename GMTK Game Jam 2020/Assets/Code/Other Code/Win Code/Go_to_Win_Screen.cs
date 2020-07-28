using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class Go_to_Win_Screen : MonoBehaviour {

    #region Variable's

        #region Script's

            [SerializeField]
            private Level_Loader Level_loader;

        #endregion

        #region Float Variable's

            [SerializeField]
            private float Delay_to_Win_Screen = 3.8f;

        #endregion

    #endregion

    void OnCollisionEnter2D(Collision2D collision) {

        FindObjectOfType <Audio_Manager> ().Play (Tags.Player_Win);

        Level_loader.Load_Next_Level ();
        
    }

}
