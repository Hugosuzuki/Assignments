using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class Position : MonoBehaviour
{
    const string DLL_NAME = "SaveLoadDll";
    [DllImport(DLL_NAME)]
    private static extern void Save(float x, float y, float z);
    [DllImport(DLL_NAME)]
    private static extern float LoadX();
    [DllImport(DLL_NAME)]
    private static extern float LoadY();
    [DllImport(DLL_NAME)]
    private static extern float LoadZ();

    //movement speed in units per second
    private float movementSpeed = 10f;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Save(transform.position.x, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            float x = LoadX();
            float y = LoadY();
            float z = LoadZ();
            transform.position = new Vector3(x, y, z);
        }

        //get the Input from Horizontal axis
        float horizontalInput = Input.GetAxis("Horizontal");
        //get the Input from Vertical axis
        float verticalInput = Input.GetAxis("Vertical");

        //update the position
        transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, 0, verticalInput * movementSpeed * Time.deltaTime);

    }
}