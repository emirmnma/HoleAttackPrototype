
using UnityEngine;

public class Throw : MonoBehaviour
{
    void Update()
    {
        ForceCube();
    }


    private void ForceCube()
    {
        transform.Translate(new Vector3(0f, 0.01f, 0.4f));
    }
}
