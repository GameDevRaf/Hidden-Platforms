using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Loop : MonoBehaviour {

    #region Variable's

        #region Camera's

            [SerializeField]
            private Camera Main_Camera;

        #endregion

        #region GameObject's

            [SerializeField]
            private GameObject[] Levels;

        #endregion

        #region Vector3 Variable's

            private Vector3 Last_Screen_Position;

        #endregion

        #region Vector2 Variable's

            private Vector2 Screen_Bounds;

        #endregion

        #region Float Variable's

            [SerializeField]
            private float Choke;

        #endregion

    #endregion

    // Awake is called before Start and Start is called before the first frame update
    void Start() {

        Screen_Bounds = Main_Camera.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, Main_Camera.transform.position.z));
        
        foreach (GameObject Object in Levels) {
            
            Load_Child_Objects (Object);

        }

        Last_Screen_Position = transform.position;

    }

    void Load_Child_Objects (GameObject Object) {

        float Object_Width = Object.GetComponent <SpriteRenderer> ().bounds.size.x - Choke;

        int Childs_Needed = (int) Mathf.Ceil (Screen_Bounds.x * 4 / Object_Width);

        GameObject Clone = Instantiate (Object) as GameObject;

        for (int i = 0; i < Childs_Needed; i++) {
            
            GameObject C = Instantiate (Clone) as GameObject;

            C.transform.SetParent (Object.transform);

            C.transform.position = new Vector3 (Object_Width * i, Object.transform.position.y, Object.transform.position.z);

            C.name = Object.name + i;

        }

        Destroy (Clone);

        Destroy (Object.GetComponent <SpriteRenderer> ());

    }

    void LateUpdate() {

        foreach (GameObject Object in Levels) {
            
            Reposition_Child_Objects (Object);

            float Parallax_Speed = 1 - Mathf.Clamp01 (Mathf.Abs (transform.position.z / Object.transform.position.z));

            float Difference = transform.position.x - Last_Screen_Position.x;

            Object.transform.Translate ((Vector3.right * Difference * Parallax_Speed) * 2);

        }
        
        Last_Screen_Position = transform.position;

    }

    void Reposition_Child_Objects(GameObject Object) {

        Transform[] Children = Object.GetComponentsInChildren <Transform> ();

        if (Children.Length > 1) {

            GameObject First_Child = Children [1].gameObject;

            GameObject Last_Child = Children [Children.Length - 1].gameObject;
            
            float Half_Object_Width = Last_Child.GetComponent <SpriteRenderer> ().bounds.extents.x - Choke;

            if (transform.position.x + Screen_Bounds.x > Last_Child.transform.position.x + Half_Object_Width) {
                
                First_Child.transform.SetAsLastSibling ();

                First_Child.transform.position = new Vector3 (Last_Child.transform.position.x + Half_Object_Width * 2, Last_Child.transform.position.y, Last_Child.transform.position.z);

            }

            else if (transform.position.x + Screen_Bounds.x < First_Child.transform.position.x + Half_Object_Width) {
                
                Last_Child.transform.SetAsLastSibling ();

                Last_Child.transform.position = new Vector3 (Last_Child.transform.position.x + Half_Object_Width * 2, Last_Child.transform.position.y, Last_Child.transform.position.z);

            }

        }

    }

}
