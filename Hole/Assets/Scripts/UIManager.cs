using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Level Progress UI")]  
    [SerializeField] private Image progressFillImage;

    [SerializeField] TMP_Text goldnumber;

    [SerializeField] Button timeIncreasebutton;
    [SerializeField] Button holeSizebutton;

    [SerializeField] GameObject timeIncreaseText;
    [SerializeField] GameObject upgradeButtons;

    [SerializeField] GameObject circle;

    public static int totalCubes;

    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Enemy.goldınt = PlayerPrefs.GetInt(nameof(Enemy.goldınt), Enemy.goldınt);
        Timer.timeRemaining = PlayerPrefs.GetFloat(nameof(Timer.timeRemaining),Timer.timeRemaining);
        holeSizebutton.onClick.AddListener(HoleIncrease);
        timeIncreasebutton.onClick.AddListener(TimeIncrease);

        totalCubes = 0;
        progressFillImage.fillAmount = 0f;

        timeIncreaseText.SetActive(false);
    }


    private void Update()
    {
        goldnumber.text = Enemy.goldınt.ToString();
        HoleUpgrade();

        if (progressFillImage.fillAmount == 1)
        {
            SceneManager.LoadScene(2);
        }
    }
    public void IncreaseScore()
    {
        float val = 0.8f - ((float)(LevelManager.instance.lastCubes / LevelManager.instance.objectİnScene));        
        progressFillImage.DOFillAmount(val, 0.4f);
    }

    public void IncreaseTotalCubes()
    {
        totalCubes += 1;
        LevelManager.instance.lastCubes -= 1;
    }

    void TimeIncrease()
    {
        timeIncreasebutton.transform.DOScale(0.4f, 0.4f);
        if (Enemy.goldınt >= 20)
        {

            Timer.timeRemaining += 1;
            timeIncreaseText.SetActive(true);
            timeIncreaseText.transform.position = circle.transform.position + new Vector3(0f, 0.5f, 0f);
            Enemy.goldınt -= 20;
            PlayerPrefs.SetFloat(nameof(Timer.timeRemaining), Timer.timeRemaining);
            PlayerPrefs.SetInt(nameof(Enemy.goldınt), Enemy.goldınt);

        }     
        timeIncreasebutton.transform.DOScale(2f, 0.4f);
    }

    void HoleIncrease()
    {
        holeSizebutton.transform.DOScale(0.2f, 0.4f);
        if (Enemy.goldınt >= 10)
        {
            float val = 0.0001f;
            circle.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            Enemy.goldınt -= 10;
            HoleMovement.Scale += val;

            PlayerPrefs.SetInt(nameof(Enemy.goldınt), Enemy.goldınt);          
        }    
        holeSizebutton.transform.DOScale(2f, 0.4f);
    }

    void HoleUpgrade()
    {


        if (totalCubes > 1)
        {
            circle.transform.DOScale(5f, 1f);
            HoleMovement.Scale =0.1f;
            CameraFollow.Instance.UpdateCameraSize();
        }     
        if (totalCubes > 5)
        {

            circle.transform.DOScale(7f, 1f);
            HoleMovement.Scale = 0.13f;
            CameraFollow.Instance.UpdateCameraSize2();
        }
        if (totalCubes > 10)
        {
            circle.transform.DOScale(10f, 1f);
            HoleMovement.Scale = 0.13f;
            CameraFollow.Instance.UpdateCameraSize3();
        }
    } 
}
