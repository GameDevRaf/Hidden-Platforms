using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class Level_Loader : MonoBehaviour {

    #region Variable's

        #region Animator's

            public Animator Transition;

        #endregion

        #region Float Variable's

            public float Transition_Time;

        #endregion

    #endregion

    public void Load_Next_Level () {

        StartCoroutine (Load_Level (SceneManager.GetActiveScene().buildIndex + 1));

    }

    public IEnumerator Load_Level(int Level_Index) {

        Transition.SetTrigger (Tags.Start_Trigger);

        yield return new WaitForSeconds (Transition_Time);

        SceneManager.LoadScene (Level_Index);

    }

}
