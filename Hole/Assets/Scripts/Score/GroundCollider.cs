using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollider : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] GameObject scoresRed;
    [SerializeField] GameObject scoresPink;
    [SerializeField] Camera cam;

    public static int redCube;
    public static int pinkCube;

    [SerializeField] AudioClip collect;
    
    private void Start()
    {
        redCube = 0;
        pinkCube = 0;
        cam = Camera.main;
    }

    private void Update()
    {
        transform.LookAt(transform.position + cam.transform.forward);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RedCube"))
        {
            SoundManager.ınstance.PlaySound(collect);
            redCube += 1;
            AfterHoleRed();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("PinkCube"))
        {
            SoundManager.ınstance.PlaySound(collect);

            pinkCube += 1;
            AfterHolePink();
            Destroy(other.gameObject);
        }
    }
    private void AfterHoleRed()
    {
        scoresRed.SetActive(true);
        scoresRed.transform.position = player.position + new Vector3(0f, 0.1f, 0f);
        UIManager.Instance.IncreaseTotalCubes();
        UIManager.Instance.IncreaseScore();
    }

    private void AfterHolePink()
    {
        scoresPink.SetActive(true);
        scoresPink.transform.position = player.position + new Vector3(0f, 0.1f, 0f);
        UIManager.Instance.IncreaseTotalCubes();
        UIManager.Instance.IncreaseScore();
    }

}
