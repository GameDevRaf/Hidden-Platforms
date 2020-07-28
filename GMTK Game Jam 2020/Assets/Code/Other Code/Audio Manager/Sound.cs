using UnityEngine;

[System.Serializable]
public class Sound {
    
    #region Variable's

        #region String Variable's

            public string Name;

        #endregion

        #region Audio Clip's

            [Space]
            public AudioClip clip;

        #endregion

        #region Audio Source

            [HideInInspector]
            public AudioSource Source;

        #endregion

        #region Float Variable's

            [Range (0f,1f)]
            public float Volume;


            [Range (0.1f, 3f)]
            public float Pitch;

        #endregion

        #region Boolean Variable's

            [Space]
            public bool Loop;

        #endregion

    #endregion

}
