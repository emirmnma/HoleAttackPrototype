using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Enemy : MonoBehaviour
{
    //Fire
    [SerializeField] private Image enemyImage;
    [SerializeField] private TMP_Text goldtext;
    public static int goldınt=0;

    [SerializeField] GameObject part;
    //Move
    [Header("Movement")]
    GameObject holePos;
    [SerializeField] float enemySpeed;
    public static bool enemyCollideWHole;
    void Start()
    {
        enemyImage.fillAmount = 1f;
        holePos = GameObject.FindGameObjectWithTag("Hole");
        enemyCollideWHole = false;
        PlayerPrefs.GetInt(nameof(goldınt), goldınt);

    }


    void Update()
    {
        goldtext.text = goldınt.ToString();
        MoveEnemy();
    }


    void MoveEnemy()
    {
        if (transform.position == holePos.transform.position)
        {
            enemyCollideWHole = true;
        }
        transform.position = Vector3.MoveTowards(transform.position, holePos.transform.position, enemySpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BossRed") || other.gameObject.CompareTag("BossPink"))
        {
            GameObject newPart = Instantiate(part, transform.position+new Vector3(0f,4f,0f), Quaternion.identity);
            Destroy(newPart, 0.5f);
            int randomNumber = Random.Range(0, 10);
            goldınt += randomNumber;
            enemyImage.fillAmount -= 0.01f;
            Destroy(other.gameObject);
            PlayerPrefs.SetInt(nameof(goldınt), goldınt);
        }
     
    }
}
