using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraY : MonoBehaviour
{
    float v_rotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        v_rotation += Input.GetAxis("Mouse Y") * -90 * Time.deltaTime;
        v_rotation = Mathf.Clamp(v_rotation, -85, 85);
        transform.localEulerAngles = new Vector3(v_rotation, 0, 0);
    }
}
