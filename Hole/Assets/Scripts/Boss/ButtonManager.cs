using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{

    [Header("For Boss")]
    [SerializeField] private Button redButton;
    [SerializeField] private Button pinkButton;

    [SerializeField] private GameObject redCube;
    [SerializeField] private GameObject pinkCube;
    [SerializeField] private GameObject tryAgainPanel;

    [SerializeField] private TMP_Text redText;
    [SerializeField] private TMP_Text pinkText;

   

    void Start()
    {
        redButton.onClick.AddListener(CreateRed);
        pinkButton.onClick.AddListener(CreatePink);
        tryAgainPanel.SetActive(false);
    }

    
    void Update()
    {
        redText.text=GroundCollider.redCube.ToString();
        pinkText.text = GroundCollider.pinkCube.ToString();     
        CheckForPrefabs();
    }

    private void CheckForPrefabs()
    {
        if (GroundCollider.redCube == 0 && GroundCollider.pinkCube == 0)
        {
            tryAgainPanel.SetActive(true);
        }
        else if (Enemy.enemyCollideWHole)
        {
            tryAgainPanel.SetActive(true);

        }
    }

    private void CreateRed()
    {
        if (GroundCollider.redCube > 0)
        {
            GameObject newCubeRed=Instantiate(redCube, transform.position, Quaternion.identity);
            GroundCollider.redCube--;
        }
        else
        {
            return;
        }
        
    }

    private void CreatePink()
    {

        if (GroundCollider.pinkCube > 0)
        {
            GameObject newCubePink=Instantiate(pinkCube, transform.position, Quaternion.identity);
            GroundCollider.pinkCube--;
        }
        else
        {
            return;
        }
       
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
}
