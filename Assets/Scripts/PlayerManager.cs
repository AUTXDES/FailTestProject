using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static int playerHP;
    public static bool isGameOver;
    public TextMeshProUGUI playerHPText;
    public GameObject BloodOverlay;

     void Start()
    {
        playerHP = 100;
        isGameOver = false;
        
    }

  
    void Update()
    {
        playerHPText.text = "" + playerHP;
        if (isGameOver)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
            

    public IEnumerator Damage (int damageCount)
    {
        BloodOverlay.SetActive(true);
        playerHP -= damageCount;
        if (playerHP <= 0)
            isGameOver = true;

        yield return new WaitForSeconds(1f);
        BloodOverlay.SetActive(false);
    }
}
