using UnityEngine;
using UnityEngine.InputSystem;

public class diceController : MonoBehaviour
{
    private Rigidbody rb;
    private bool isDropped = false;

    public GameObject side1;
    public GameObject side2;
    public GameObject side3;
    public GameObject side4;
    public GameObject side5;
    public GameObject side6;

    public int currentSide = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    public void RotateDice(){
        float randX = Random.Range(100f, 360f) ; 
        float randY = Random.Range(100f, 360f) ; 
        float randZ = Random.Range(100f, 360f) ; 

        transform.rotation = Quaternion.Euler(randX, randY, randZ) ;

    }

    public void DropDice(InputAction.CallbackContext context)
    {
        if (context.performed && !isDropped)
        {
            RotateDice() ;
            rb.useGravity = true;
            isDropped = true;
        }
    }

    void Update()
    {
        if (isDropped && rb.IsSleeping()) 
        {
            float maxY = float.MinValue;
            int sideUp = 0;

            GameObject[] sides = { side1, side2, side3, side4, side5, side6 };

            for (int i = 0; i < sides.Length; i++)
            {
                float y = sides[i].transform.position.y;
                if (y > maxY)
                {
                    maxY = y;
                    sideUp = i + 1; 
                }
            }

            currentSide = sideUp;
        }
    }
}