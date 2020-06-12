using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CompassBehavior : MonoBehaviour
{
    public GameObject compassMark;
    public GameObject inputField;

    public GameObject instanceMark;
    public GameObject instanceInputField;

    private Camera cam1;
    public Canvas canvas;

    public float inputFieldX;
    public float inputFieldY;

    // Start is called before the first frame update
    void Start()
    {
        cam1 = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            instanceMark = Instantiate(compassMark, cam1.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, cam1.nearClipPlane)), Quaternion.identity);
            instanceMark.GetComponent<MarkBehaviour>().following = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            instanceMark.GetComponent<MarkBehaviour>().following = false;
            instanceMark.transform.localScale = new Vector3(3, 3, 3);
            inputFieldX = Input.mousePosition.x;
            inputFieldY = Input.mousePosition.y - 80;
            if (Input.mousePosition.x < 200)
            {
                inputFieldX = Input.mousePosition.x + 80;
            }
            if (Input.mousePosition.x > 880)
            {
                inputFieldX = Input.mousePosition.x - 80;
            }
            if (Input.mousePosition.y < 200)
            {
                inputFieldY = Input.mousePosition.y + 80;
            }
            InstantiateInputField(inputFieldX, inputFieldY, 0);
        }
    }

    public void InstantiateInputField(float x, float y, float z)
    {
        instanceInputField = Instantiate(inputField, new Vector3(x, y, z), Quaternion.identity);
        instanceInputField.transform.SetParent(canvas.transform);
        instanceInputField.GetComponent<TMP_InputField>().ActivateInputField();
    }
}
