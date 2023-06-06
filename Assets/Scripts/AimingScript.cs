using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingScript : MonoBehaviour
{

    public static AimingScript inst;



    public float degreesPerSecond;
    bool isRotatingup;


    private void Awake()
    {
        inst = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        isRotatingup = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RotateDown()
    {
        isRotatingup = false;
    }

    public void RotateUp()
    {
        isRotatingup = true;
    }

    public void Aiming()
    {

        Debug.Log("Aim Started");
        if (isRotatingup)
        {
            transform.Rotate(new Vector3(0, 0, degreesPerSecond) * Time.deltaTime);

            Invoke("RotateDown", 1);
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, -degreesPerSecond) * Time.deltaTime);

            Invoke("RotateUp", 1);
        }
    }
}
