using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private Text userNameText;   
    [SerializeField] private Text userScoreText;
    [SerializeField] private Text userPositionText;

   
    [SerializeField] private string userName;
    [SerializeField] private int userScore;
    [SerializeField] private Vector3 userPosition;

    
    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }

    public void SaveSata()
    {
        PlayerPrefs.SetString("name", userName);    
        PlayerPrefs.SetInt("score", userScore);
        PlayerPrefs.SetFloat("positionX", userPosition.x);
        PlayerPrefs.SetFloat("positionY", userPosition.y);
        PlayerPrefs.SetFloat("positionZ", userPosition.z);

        LoadData();
    }

    void LoadData()
    {
        userNameText.text = "User name:" + PlayerPrefs.GetString("name", "No name");
        userScoreText.text = "User score:" + PlayerPrefs.GetInt("score", 0).ToString();
        userPositionText.text = "Player position:" + PlayerPrefs.GetFloat("positionX", 0).ToString() + "x" +
                                PlayerPrefs.GetFloat("positionY", 0).ToString() + "y" + 
                                PlayerPrefs.GetFloat("positionZ", 0).ToString() + "z";
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteKey("name");
        PlayerPrefs.DeleteKey("score");
        PlayerPrefs.DeleteKey("psotionX");
        PlayerPrefs.DeleteKey("psotionY");
        PlayerPrefs.DeleteKey("psotionZ");

        PlayerPrefs.DeleteAll();

        LoadData();
    }

}
