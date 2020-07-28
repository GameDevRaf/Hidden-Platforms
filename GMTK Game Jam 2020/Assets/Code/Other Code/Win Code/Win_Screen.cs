using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class Win_Screen : MonoBehaviour {

    public void Quit() {

        Application.Quit ();

    }

    public void Play_Again() {

        SceneManager.LoadScene (Tags.Scene_1);

    }

}
