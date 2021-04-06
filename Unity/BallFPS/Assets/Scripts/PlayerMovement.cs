using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SFramework;

public class PlayerMovement : MonoBehaviourSimplify
{
    public static PlayerMovement instance;
    private PlayerMovement() { }
    public static PlayerMovement GetInstance() { return instance; }


    Rigidbody rb;

    [SerializeField]
    Vector3 velocity;

    public Transform pointTrans;

    [SerializeField]
    private float movSpeed = 5;
    [SerializeField]
    private float flySpeed = 5;

    public bool canFly = false;
    public float fuelAmount = 100;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Cursor.visible = false;
        GameObject point = new GameObject("point");
        pointTrans = point.transform;

        rb = GetComponent<Rigidbody>();
        fuelAmount = 100;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
        }
        if (canFly)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                fuelAmount -= Time.deltaTime * 45;
            }
            else
            {
                fuelAmount += Time.deltaTime * 15;
            }
        }
        else
        {

            fuelAmount += Time.deltaTime * 15;
        }
        
        
        if (fuelAmount > 100)
        {
            fuelAmount = 100;
            canFly = true;
        }
        else if (fuelAmount < 0)
        {
            fuelAmount = 0;
            canFly = false;
        }
    }

    private void FixedUpdate()
    {
        var tmp_x = GetInput("x") * movSpeed * Time.fixedDeltaTime;
        var tmp_z = GetInput("z") * movSpeed * Time.fixedDeltaTime;
        var tmp_y = GetInput("Jump") * flySpeed * Time.fixedDeltaTime;

        if (tmp_x != 0 || tmp_z != 0 || tmp_y != 0)
        {
            if (rb.freezeRotation)
            {
                rb.freezeRotation = false;
            }

            if (canFly)
            {
                velocity = pointTrans.forward * tmp_z + pointTrans.right * tmp_x + pointTrans.up * tmp_y;
            }
            else
            {
                velocity = pointTrans.forward * tmp_z + pointTrans.right * tmp_x;
            }

            UpdateMovement();
        }
        else
        {
            if (!rb.freezeRotation)
            {
                rb.freezeRotation = true;
            }
            
        }

        if (transform.position.y >= 50)
        {
            TransformSimplify.SetLocalPosY(transform, 50f);
        }
    }

    public void UpdateMovement()
    {
        rb.AddForce(velocity, ForceMode.Force);
    }


}
