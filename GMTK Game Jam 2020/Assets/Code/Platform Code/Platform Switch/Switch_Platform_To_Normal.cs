using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Platform_To_Normal : MonoBehaviour {

    #region Variable's

        #region Script's

            public Tags Tag;

        #endregion

        #region GameObject'

            [SerializeField] 
            private GameObject Normal_Tileset;

            [SerializeField]
            private GameObject Inverted_Tileset;

        #endregion

    #endregion

    void OnTriggerEnter2D(Collider2D collider) {

        if (collider.tag == Tags.Player) {

            if (Tag.Tileset_is_Inverted == true) {
                
                Inverted_Tileset.SetActive (false);
                Normal_Tileset.SetActive (true);

                FindObjectOfType <Audio_Manager> ().Play (Tags.Inverted_to_Normal);

                Tag.Tileset_is_Inverted = false;

            }

        }
        
    }

}
