using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;

    [SerializeField] int movementSpeed;

    private float h;
    private float v;
    private bool isHorizontal;
    private Vector3 directionVec;
    private GameObject scannedObject;
    private Rigidbody2D rigid;
    private Animator animator;

    //Mobile Keys
    private int upValue;
    private int downValue;
    private int leftValue;
    private int rightValue;
    private bool upDown;
    private bool downDown;
    private bool leftDown;
    private bool rightDown;
    private bool upUp;
    private bool downUp;
    private bool leftUp;
    private bool rightUp;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //PC
        h = gameManager.isScanning ? 0 : Input.GetAxisRaw("Horizontal") + rightValue + leftValue;
        v = gameManager.isScanning ? 0 : Input.GetAxisRaw("Vertical") + upValue + downValue;

        bool hDown = gameManager.isScanning ? false : Input.GetButtonDown("Horizontal") || rightDown || leftDown;
        bool vDown = gameManager.isScanning ? false : Input.GetButtonDown("Vertical") || upDown || downDown;
        bool hUp = gameManager.isScanning ? false : Input.GetButtonUp("Horizontal") || rightUp || leftUp;
        bool vUp = gameManager.isScanning ? false : Input.GetButtonUp("Vertical") || upUp || downUp;

        if (hDown)
            isHorizontal = true;
        else if (vDown)
            isHorizontal = false;
        else if (hUp || vUp)
            isHorizontal = h != 0;

        if (animator.GetInteger("hAxisRaw") != h)
        {
            animator.SetBool("directionChanged", true);
            animator.SetInteger("hAxisRaw", (int)h);
        }
            
        else if (animator.GetInteger("vAxisRaw") != v)
        {
            animator.SetBool("directionChanged", true);
            animator.SetInteger("vAxisRaw", (int)v);
        }
        else
            animator.SetBool("directionChanged", false);

        //direction
        if (vDown && v == 1)
            directionVec = Vector3.up;
        else if (vDown && v == -1)
            directionVec = Vector3.down;
        else if (hDown && h == 1)
            directionVec = Vector3.right;
        else if (hDown && h == -1)
            directionVec = Vector3.left;

        //scan object
        if (Input.GetButtonDown("Jump") && scannedObject != null)
        {
            gameManager.Scan(scannedObject);
        }

        //Mobile
        upDown = false;
        downDown = false;
        leftDown = false;
        rightDown = false;
        upUp = false;
        downUp = false;
        leftUp = false;
        rightUp = false;
}
    
    void FixedUpdate()
    {
        Vector2 moveVec = isHorizontal ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * movementSpeed;

        Debug.DrawRay(transform.position, directionVec * 0.7f, Color.green);
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, directionVec, 0.7f, LayerMask.GetMask("Object"));

        if (rayHit.collider)
        {
            scannedObject = rayHit.collider.gameObject;
        }
        else
        {
            scannedObject = null;
        }

    }

    public void ButtonDown(string type)
    {
        switch (type)
        {
            case "U":
                upValue = 1;
                upDown = true;
                break;
            case "D":
                downValue = -1;
                downDown = true;
                break;
            case "L":
                leftValue = -1;
                leftDown = true;
                break;
            case "R":
                rightValue = 1;
                rightDown = true;
                break;
            case "A":
                if (scannedObject != null)
                {
                    gameManager.Scan(scannedObject);
                }
                break;
            case "C":
                gameManager.SubMenuActive();
                break;

        }
    }
    public void ButtonUp(string type)
    {
        switch (type)
        {
            case "U":
                upValue = 0;
                upUp = true;
                break;
            case "D":
                downValue = 0;
                downUp = true;
                break;
            case "L":
                leftValue = 0;
                leftUp = true;
                break;
            case "R":
                rightValue = 0;
                rightUp = true;
                break;
        }
    }


}
