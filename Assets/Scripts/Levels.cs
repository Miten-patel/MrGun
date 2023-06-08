using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{

    [SerializeField] private List<GameObject> _PlatformPrefabs;




}



//{

//    [SerializeField] private List<PlatformData> _platforms;

//    private int _currentIndex;



//    // Start is called before the first frame update
//    void Start()
//    {
//        _currentIndex = 0;

//        if (_platforms.Count > 0)
//        {
//            SetupPlatform(_platforms[_currentIndex]);
//        }
//    }

//    private void Update()
//    {
//        PlatformData currentPlatform = _platforms[_currentIndex];

//        if(Input.GetKeyDown(KeyCode.Space))
//        {
//            _currentIndex++;
//        }

//    }


//    private void SetupPlatform(PlatformData platformData)
//    {
//        Platform.inst._moveSpeed = platformData.moveSpeed;
//    }

//}

//[System.Serializable]
//public class PlatformData
//{

//    public float moveSpeed;
//}
