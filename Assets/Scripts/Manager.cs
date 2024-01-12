using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{

    [SerializeField] private Text userNameText;   
    [SerializeField] private Text userPositionText;

   
    [SerializeField] public int userName;
    [SerializeField] private Vector3 userPosition;

    Transform playerPosition; 

    
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.Find("Player").GetComponent<Transform>();
        LoadData();
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("name", userName);    
        PlayerPrefs.SetFloat("positionX", playerPosition.position.x);
        PlayerPrefs.SetFloat("positionY", playerPosition.position.y);
        PlayerPrefs.SetFloat("positionZ", playerPosition.position.z);

        LoadData();
    }

    void LoadData()
    {
        userNameText.text = "User name:" + PlayerPrefs.GetInt("name");
        userPositionText.text = "Player position:" + PlayerPrefs.GetFloat("positionX", 985.2742f).ToString() + "x" +
                                PlayerPrefs.GetFloat("positionY", 548.4684f).ToString() + "y" + 
                                PlayerPrefs.GetFloat("positionZ", 32.57221f).ToString() + "z";
    }

       
}
