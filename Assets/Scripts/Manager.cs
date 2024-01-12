using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{

    [SerializeField] private Text checkpointText;   
    [SerializeField] private Text userPositionText;

   
    [SerializeField] private string checkpointText;
    [SerializeField] private Vector3 userPosition;

    
    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }


    void LoadData()
    {
        checkpointText.text = "Checkpoint:" + PlayerPrefs.GetString("checkpoint", "No point");
        userPositionText.text = "Player position:" + PlayerPrefs.GetFloat("positionX", 0).ToString() + "x" +
                                PlayerPrefs.GetFloat("positionY", 0).ToString() + "y" + 
                                PlayerPrefs.GetFloat("positionZ", 0).ToString() + "z";
    }

}
