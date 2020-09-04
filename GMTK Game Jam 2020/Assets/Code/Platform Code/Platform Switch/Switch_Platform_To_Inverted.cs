using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Platform_To_Inverted : MonoBehaviour {

    #region Variable's

        #region Script's

            [SerializeField]
            private Tags Tag;

        #endregion

        #region GameObject's

            [SerializeField]
            private GameObject Normal_Tileset;

            [SerializeField]
            private GameObject Inverted_Tileset;

        #endregion

        #region Array's

            [Header ("Array's"), Space]
            [SerializeField]
            private GameObject[] Lights;

            [SerializeField]
            private GameObject[] Hidden_Lights;

        #endregion

    #endregion

    void OnTriggerEnter2D(Collider2D collider) {

        if (collider.tag == Tags.Player) {
            
            if (Tag.Tileset_is_Inverted == false) {
                
                Normal_Tileset.SetActive (false);
                Inverted_Tileset.SetActive (true);

                FindObjectOfType <Audio_Manager> ().Play (Tags.Normal_to_Inverted);

                #region Change The Lights

                    for (int i = 0; i < Hidden_Lights.Length; i++) {
                
                        Hidden_Lights[i].SetActive (true);
                
                    }

                    for (int i = 0; i < Lights.Length; i++) {

                        Lights[i].SetActive (false);
                
                    }

                #endregion

                Tag.Tileset_is_Inverted = true;

            }

        }
        
    }

}
