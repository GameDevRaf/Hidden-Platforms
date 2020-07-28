using UnityEngine.Audio;
using UnityEngine;
using System;

public class Audio_Manager : MonoBehaviour {

    #region Variable's

        #region Script's

            [SerializeField]
            private Sound[] Sounds;

        #endregion

        #region GameObject's

            [SerializeField]
            private GameObject Audio_Sources;

        #endregion

        #region Audio Manager's

            public static Audio_Manager instance;

        #endregion

    #endregion

    // Awake is called before Start and Start is called before the first frame update
    void Awake() {

        if (instance == null) {
            
            instance = this;

        }

        else {

            Destroy (gameObject);

            return;

        }

        DontDestroyOnLoad (gameObject);

        foreach (Sound S in Sounds) {
            
            S.Source = Audio_Sources.AddComponent <AudioSource> ();

            S.Source.clip = S.clip;
            S.Source.volume = S.Volume;
            S.Source.pitch = S.Pitch;
            S.Source.loop = S.Loop;

        }
        
    }

    void Start() {

        Play (Tags.Background_Audio);
        
    }

    public void Play(string name) {

        Sound S = Array.Find (Sounds, Sound => Sound.Name == name);

        if (S == null) {

            Debug.LogWarning ("Sound: " + name + " not found!");

            return;
            
        }

        S.Source.Play ();

    }

    public void Stop(string name) {

        Sound S = Array.Find (Sounds, Sound => Sound.Name == name);

        if (S == null) {

            Debug.LogWarning ("Sound: " + name + " not found!");

            return;
            
        }

        S.Source.Stop ();

    }

}
