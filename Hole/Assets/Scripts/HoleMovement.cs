using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;

public class HoleMovement : MonoBehaviour
{	
	[Header("Movement and Scale")]
	public static float Scale= 0.1f;
	[SerializeField] private GameObject CircleDotSprite;

	//**************************************************************************
	[SerializeField] PolygonCollider2D hole2DCollider;
	[SerializeField] PolygonCollider2D ground2DCollider;
	[SerializeField] MeshCollider GenerateMeshCollider;
	Mesh GenerateMesh;
	//**************************************************************************
	[Header("Joystick")]
	[SerializeField] private FloatingJoystick floatingJoystick;
	[SerializeField] private float moveeSpeed;	
	private Vector3 moveVector;

	[Header("UpgradeButtonsAnimations")]
	[SerializeField] Animator anim;
	[SerializeField] Animator anim2;


	public static bool timeCanStart;


	void Start()
	{
		anim.SetBool("CanPass", false);
		anim2.SetBool("CanPass2", false);

		timeCanStart = false;
		PlayerPrefs.GetFloat(nameof(Scale),Scale);


	}

	void FixedUpdate()
	{

		Debug.Log(Scale);
		if (transform.hasChanged == true)
		{
			transform.hasChanged = false;
			hole2DCollider.transform.position = new Vector2(transform.position.x, transform.position.z);
			hole2DCollider.transform.localScale = transform.localScale * Scale;
			


			MakeHole2D();
			Make3DMeshCollider();		
		}
	}

	void Update()
	{
		Move();
	}
	void Move()
	{
		moveVector = Vector3.zero;
		moveVector.x = floatingJoystick.Horizontal * moveeSpeed * Time.deltaTime;
		moveVector.z = floatingJoystick.Vertical * moveeSpeed * Time.deltaTime;
		CircleDotSprite.transform.Rotate(new Vector3(0f, 0f, 0.4f));

		if (floatingJoystick.Horizontal != 0 || floatingJoystick.Vertical != 0)
        {
			timeCanStart = true;
			anim.SetBool("CanPass", true);
			anim2.SetBool("CanPass2", true);
			transform.position += new Vector3(moveVector.x,0f,moveVector.z)* moveeSpeed * Time.deltaTime;
        }
	}
	
	private void MakeHole2D()
	{
		Vector2[] PointsPositions = hole2DCollider.GetPath(0);

		for (int i = 0; i < PointsPositions.Length; i++)
		{
			PointsPositions[i] = hole2DCollider.transform.TransformPoint(PointsPositions[i]);
		}

		ground2DCollider.pathCount = 2;
		ground2DCollider.SetPath(1, PointsPositions);
	}

	private void Make3DMeshCollider()
	{
		if (GenerateMesh != null) Destroy(GenerateMesh);
		GenerateMesh = ground2DCollider.CreateMesh(true, true);
		GenerateMeshCollider.sharedMesh = GenerateMesh;
	}

	
}
