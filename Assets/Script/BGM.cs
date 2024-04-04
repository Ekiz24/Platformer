using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    //all the scences have Audio Source with this script

    static BGM Music; //is used to store the unique instance of background music

    void Awake()
    {
        switch (Music)
        {
            case null: //checks whether there is already an existing music instance
                Music = this; //if not existing, it assigns the current instance to Music
                break;

            default: //if so, then destroy the current instance
                Destroy(gameObject);
                break;
                //these are for keeping background music playing even if we are testing other scences
                //and assuring there is always only one background music throughout the play
        }

        DontDestroyOnLoad(gameObject);

    }


}
