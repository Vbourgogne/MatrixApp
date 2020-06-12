using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkBehaviour : MonoBehaviour
{
    public bool following;
    private Camera cam1;

    // Start is called before the first frame update
    void Start()
    {
        cam1 = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (following)
        {
            transform.position = cam1.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam1.nearClipPlane));
        }
    }
}
