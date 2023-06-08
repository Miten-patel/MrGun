using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] public Transform _player;


    public static Player inst;

    private void Awake()
    {
        inst = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("working");    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
