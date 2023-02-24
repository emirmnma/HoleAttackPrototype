using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Score : MonoBehaviour
{

    bool ısActive;
    private void OnEnable()
    {
        transform.DOScale(0.1f, 1f);
        Invoke("InActive", 0.5f);
    }

    void InActive()
    {
        
        gameObject.SetActive(false);
        transform.DOScale(0.01f, 1f);
    }
}
