using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private Vector3 cameraOffset;
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 targetedPos;
    [SerializeField] private float speed;

    public static CameraFollow Instance;
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
        _camera = Camera.main;
    }


    private void FixedUpdate()
    {
        targetedPos = player.transform.position + cameraOffset;
        transform.position = Vector3.Lerp(transform.position, targetedPos, speed * Time.fixedDeltaTime);
    }

    public void UpdateCameraSize()
    {
        cameraOffset = new Vector3(0f, 3.26f, -3.7f);
    }
    public void UpdateCameraSize2()
    {
        cameraOffset = new Vector3(0f, 4.26f, -5.7f);
    }
    public void UpdateCameraSize3()
    {
        cameraOffset = new Vector3(0f, 5.26f, -5.7f);
    }
}
