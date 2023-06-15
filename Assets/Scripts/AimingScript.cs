//using UnityEngine;

//public class AimingScript : MonoBehaviour
//{
//    [SerializeField] private float _minAngle = -30f;
//    [SerializeField] private float _maxAngle = 30f; 
//    [SerializeField] private float _rotationSpeed = 5f;

//    private float currentAngle; 
//    private bool isAimingUp = true;

//    public static AimingScript inst;

//    private void Awake()
//    {
//        inst = this;
//    }

//    public void Aim()
//    {
//        if (isAimingUp)
//        {
//            currentAngle += _rotationSpeed * Time.deltaTime;
//            if (currentAngle >= _maxAngle)
//            {
//                currentAngle = _maxAngle;
//                isAimingUp = false;
//            }
//        }
//        else
//        {
//            currentAngle -= _rotationSpeed * Time.deltaTime;
//            if (currentAngle <= _minAngle)
//            {
//                currentAngle = _minAngle;
//                isAimingUp = true;
//            }
//        }

//        transform.localRotation = Quaternion.Euler(0f, 0f, currentAngle);
//    }
//}
