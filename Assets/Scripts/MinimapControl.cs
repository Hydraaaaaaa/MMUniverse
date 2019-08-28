using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapControl : MonoBehaviour
{
    public Camera m_OrthographicCamera;
    public float size;
    // Start is called before the first frame update
    void Start()
    {
        m_OrthographicCamera.enabled = true;
        if (m_OrthographicCamera)
        {
            //This enables the orthographic mode
            m_OrthographicCamera.orthographic = true;
            m_OrthographicCamera.orthographicSize = 50.0f;
        }
    }

    public void PlusOrthographicCameraSize(float new_size) {
        if (m_OrthographicCamera.orthographicSize <=100)
            m_OrthographicCamera.orthographicSize += new_size;
    }

    public void MinusOrthographicCameraSize(float new_size)
    {
        if (m_OrthographicCamera.orthographicSize >= 10)
            m_OrthographicCamera.orthographicSize -= new_size;
    }
}
