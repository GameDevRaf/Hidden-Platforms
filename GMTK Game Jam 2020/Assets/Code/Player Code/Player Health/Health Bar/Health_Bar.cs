using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Health_Bar : MonoBehaviour {

    #region Variable's

        #region Slider's

            public Slider Health_Slider;

        #endregion

        #region Image's

            public Image Health;

        #endregion

    #endregion

    public void Set_Max_Health(int Max_health) {

        Health_Slider.maxValue = Max_health;
        Health_Slider.value = Max_health;

    }

    public void Set_Health(int health) {

        Health_Slider.value = health;

    }

}
