using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralaxing : MonoBehaviour {

    #region Variable's

        #region GameObject Variable's

            [Header ("Game Object")]
            [SerializeField, Space]
            private GameObject Camera;

        #endregion

        #region Transform Variable's

            [Header ("Transform's")]
            [SerializeField, Space]
            private Transform Object_Transform;

        #endregion

        #region Float's

            [Header ("Float's"), Space]
            [SerializeField, Range (-1f, 1f)]
            private float Parallax_Speed_X;

            [SerializeField, Range (-1f, 1f)]
            private float Parallax_Speed_Y;


            private float Sprite_Length;

            private float StartPos_X, StartPos_Y;

        #endregion

    #endregion

    // Start is called before the first frame update
    void Start() {

        StartPos_X = Object_Transform.position.x;
        StartPos_Y = Object_Transform.position.y;

        if (gameObject.GetComponent <SpriteRenderer> () != null) {

            Sprite_Length = GetComponent <SpriteRenderer> ().bounds.size.x;

        }
        
    }

    // Update is called once per frame
    void Update() {

        float Temporary_Position_X = (Camera.transform.position.x * (1f - Parallax_Speed_X));

        float Distance_X = (Camera.transform.position.x * Parallax_Speed_X);
        float Distance_Y = (Camera.transform.position.y * Parallax_Speed_Y);

        Object_Transform.position = new Vector3 (StartPos_X + Distance_X, StartPos_Y + Distance_Y, Object_Transform.position.z);

        if (Temporary_Position_X > StartPos_X + Sprite_Length) {
            
            StartPos_X += Sprite_Length;

        }

        /* else if (Temporary_Position_X < StartPos_X + Sprite_Length) {
            
            StartPos_X -= Sprite_Length;

            Debug.Log ("The value of Temp is: " + Temporary_Position_X);

        }*/

    }

}
