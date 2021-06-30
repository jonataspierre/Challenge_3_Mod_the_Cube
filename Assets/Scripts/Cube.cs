using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public float speedRotate;
    public float time = 0f;
    public float timeReverse = 0f;


    void Start()
    {
        InvokeRepeating("ChangeColor", 0.2f, 2.5f);
        InvokeRepeating("ChangeScale", 0.2f, 7f);
    }
    
    void Update()
    {
        ChangeRotate();
    }

    void ChangeColor()
    {        
        Material material = Renderer.material;
        material.color = new Color(Random.value, Random.value, Random.value, Random.value);
    }

    void ChangeScale()
    {
        float rangeX = Random.Range(0f, 2.5f);
        float rangeY = Random.Range(0f, 2.5f);
        float rangeZ = Random.Range(0f, 2.5f);

        transform.localScale = new Vector3(rangeX, rangeY, rangeZ);
    }    

    void ChangeRotate()
    {
        time += Time.deltaTime;        

        if (time < 7f)
        {
            transform.Rotate(speedRotate * Time.deltaTime, 0f, 0f);            
        }
        else if (time >= 7f & time < 14f)
        {
            transform.Rotate(0f, speedRotate * Time.deltaTime, 0f);
        }
        else
        {
            transform.Rotate(0f, 0f, speedRotate * Time.deltaTime);

            if (time > 21f)
            {
                time = 0f;
            }
        }

        timeReverse += Time.deltaTime;

        if (timeReverse > 7f)
        {
            speedRotate *= -1;
            timeReverse = 0f;
        }
    }
}
