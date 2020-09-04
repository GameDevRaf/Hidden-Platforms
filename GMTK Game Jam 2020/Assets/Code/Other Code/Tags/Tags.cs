using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tags : MonoBehaviour {
    
    #region Variable's

        #region Strings

            #region Player Strings

                public static string Horizontal_Movement = "Horizontal";

                public static string Ground = "Ground";

                public static string Speed = "Speed";

                public static string Is_Grounded = "Is_Grounded";

                public static string Damage_Taken = "Damage_Taken";

                public static string Healing_Ground = "Healing Ground";

                public static string Damage_Ground = "Damage Ground";

            #endregion

            #region Tileset Strings

                public static string Player = "Player";

            #endregion

            #region Scene Manegment Strings

                public static string Win_Scene = "Win_Screen";

                public static string Scene_1 = "Level 1";

                public static string Start_Trigger = "Start";

            #endregion

            #region Audio Strings

                public static string Background_Audio = "Background Audio";

                public static string Player_Jump = "Player Jump";

                public static string Player_Damage = "Player Damage";

                public static string Player_Heal = "Player Heal";

                public static string Player_Land = "Player Land";

                public static string Player_Win = "Player Win";

                public static string Inverted_to_Normal = "Inverted to Normal";

                public static string Normal_to_Inverted = "Normal to Inverted";

            #endregion

        #endregion

        public bool Tileset_is_Inverted = false;

    #endregion

}