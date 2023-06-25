using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    private Renderer objectRenderer;
    [SerializeField] Color[] newColor;
    public float speedRotate = 200f;
    private int indexColor = 0;
    [SerializeField] GameObject[] lights;
    [SerializeField] Light DirectionLight;
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        foreach (GameObject light in lights) 
        {
            light.SetActive(false);
        }
    }
    void Update()
    {
        transform.Rotate(Vector3.up, speedRotate * Time.deltaTime, Space.World);
    }
    private void OnMouseDown()
    {
        // Проверяем, был ли клик по объекту
        if (Input.GetMouseButtonDown(0))
        {
            if (indexColor > newColor.Length-1) indexColor = 0;
            objectRenderer.material.color = newColor[indexColor];
            foreach (GameObject light in lights)
            {
                light.SetActive(false);
            }
            lights[indexColor].SetActive(true);
            DirectionLight.color = newColor[indexColor];
            indexColor++;
        }
    }

}
