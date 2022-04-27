using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelControl : MonoBehaviour
{
    public Button[] levels;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            string LevelName = levels[i].name;
            if(PlayerPrefs.GetInt(LevelName) == 1)
            {
                levels[i].interactable = true;
            }
            else
            {
                levels[i].interactable = false;
            }
            levels[0].interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
