using UnityEngine;
using System.Collections;
using TMPro;


public class UserMovement : MonoBehaviour
{

    private int totalDiplomas;
    private int collectedDiplomas;

    public float jumpSpeed = 30.0f;
    public float gravity = 55.0f;
    public float runSpeed = 70.0f;
    public float runSpeed1 = 70.0f;
    public float runSpeed2 = 140.0f;
    private float walkSpeed = 90.0f;
    private float rotateSpeed = 150.0f;

    public bool grounded;
    private Vector3 moveDirection = Vector3.zero;
    private bool isWalking;
    private string moveStatus = "idle";

    public GameObject camera1;
    public CharacterController controller;
    public bool isJumping;
    private float myAng = 0.0f;
    public bool canJump = true;

    public GameObject panel;
    public Material material;
    public TextMeshProUGUI buildingText;
    public gameTimer timer;

    private float startX;
    private float startY;
    private float startZ;

    public AudioClip collectObjectSound;
    public float volume;
    public AudioSource audio;
    private GameObject[] diplomas;
    private bool canMove;
    bool gameOver = true;
    bool haveSentFinish = false;
    public GameObject bigF;


    void Start()
    {

        if(SavedSettings.GameMode == true)
        {
            diplomas = GameObject.FindGameObjectsWithTag("diploma");
        }
        canMove = true;
        //player = GameObject.FindGameObjectWithTag("Player");
        startX = (float)SavedSettings.StartX;
        startY = (float)SavedSettings.StartY;
        startZ = (float)SavedSettings.StartZ;
        float userRunSpeed = (float)SavedSettings.RunSpeed;
        transform.position = new Vector3(startX, startY, startZ);
        runSpeed = userRunSpeed;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    { 

        //if the user runs off the edge of the map, reset position, (if this is game mode, lose a life or add time to total time)
        if (transform.position.y < -50)
        {
            transform.position = new Vector3(startX, startY, startZ);
        }

        float usersRunSpeed = (float)SavedSettings.RunSpeed;
        runSpeed = usersRunSpeed;

        //if we are in game mode, check if we've yet finished the game (so we dont keep calling finish)
        //if we haven't and the game is over, finish the game
        if (SavedSettings.GameMode == true)
        {
            if (haveSentFinish == false)
            {
                if (checkGameOver())
                {
                    canMove = false;
                    timer.finishTimer();
                    haveSentFinish = true;
                    return;
                }
            }
        }


        //if we can move the player (i.e. the game isn't over or any other blocker)
        if (canMove == true)
        {
            //force controller down slope. Disable jumping
            if (myAng > 50)
            {

                canJump = false;
            }
            else
            {

                canJump = true;
            }

            //if the user isnt jumping
            if (grounded)
            {

                isJumping = false;

                //if the user is in first person camera mode
                if (camera1.transform.gameObject.transform.GetComponent<UserCamera>().inFirstPerson == true)
                {
                    moveDirection = new Vector3((Input.GetMouseButton(0) ? Input.GetAxis("Horizontal") : 0), 0, Input.GetAxis("Vertical"));
                }

                moveDirection = new Vector3((Input.GetMouseButton(1) ? Input.GetAxis("Horizontal") : 0), 0, Input.GetAxis("Vertical"));

                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= isWalking ? walkSpeed : runSpeed;

                moveStatus = "idle";



                if (moveDirection != Vector3.zero)
                    moveStatus = isWalking ? "walking" : "running";

                //jump if user presses space and isnt already jumping (i.e is grounded)
                if (Input.GetKeyDown(KeyCode.Space) && canJump)
                {
                    moveDirection.y = jumpSpeed;
                    isJumping = true;
                }

            }


            // Allow turning at anytime. Keep the character facing in the same direction as the Camera if the right mouse button is down.
            if (camera1.transform.gameObject.transform.GetComponent<UserCamera>().inFirstPerson == false)
            {
                if (Input.GetMouseButton(1))
                {
                    transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
                }
                else
                {
                    transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime, 0);

                }
            }
            else
            {
                if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
                {
                    transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
                }

            }

            //Apply gravity
            moveDirection.y -= gravity * Time.deltaTime;


            //Move controller
            CollisionFlags flags;
            if (isJumping)
            {
                flags = controller.Move(moveDirection * Time.deltaTime);
            }
            else
            {
                flags = controller.Move((moveDirection + new Vector3(0, -100, 0)) * Time.deltaTime);
            }

            grounded = (flags & CollisionFlags.Below) != 0;
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {

        myAng = Vector3.Angle(Vector3.up, hit.normal);
    }

    private bool checkGameOver()
    {
        bool gameOver = true;
        
        for (int i = 0; i < diplomas.Length; i++)
        {
            if (diplomas[i].activeSelf == true)
            {
                gameOver = false;
                break;
            }

        }

        return gameOver;
    }



    //function for changing users position when using jump to building settings
    public void ChangePosition(double x, double y, double z)
    {
        float newX = (float)x;
        float newY = (float)y;
        float newZ = (float)z;
        transform.position = new Vector3(newX, newY, newZ);
    }


    bool triggered = false;
    //function for player interaction with triggers such as info pads and collectables
    private void OnTriggerEnter(Collider other)
    {
        
        //when walking on a pad, display correct information
        if (other.gameObject.CompareTag("Pad"))
        {
            
            switch (other.name)
            {
                case "HaroldCohenStartArea":
                    buildingText.text = "Harold Cohen Library";
                    break;
                case "AshtonStartArea":
                    buildingText.text = "Ashton Building, Department of Computer Science";
                    break;
                case "ClockTowerStartArea":
                    buildingText.text = "Victoria Gallery. 150 Bronwlow Hill";
                    break;
                case "GuildStartArea":
                    buildingText.text = "Liverpool Guild of Students. 160 Mount Pleasant";
                    break;
                case "AJStartArea":
                    buildingText.text = "The Augustus John. Peach Street";
                    break;
                case "LifeSciencesStartArea":
                    buildingText.text = "Life Science Building. Crown Street";
                    break;
                case "AdminCenterStartArea":
                    buildingText.text = "Student Admin Centre. 160 Mount Pleasant";
                    break;
                case "CentralTeachingHubStartArea":
                    buildingText.text = "Central Teaching Hub, Central Teaching Laboratories";
                    break;
                case "ChadwickStartArea":
                    buildingText.text = "Chadwick Building. Peach Street";
                    break;
                case "SportsHallStartArea":
                    buildingText.text = "Sports and Fitness Centre. Bedford Street North";
                    break;
                case "AbercombySquareStartArea":
                    buildingText.text = "Abercomby Square";
                    break;
                case "SydneyJonesStartArea":
                    buildingText.text = "Sydney Jones Library, Chatham Street";
                    break;
                case "BrodieTowerStartArea":
                    buildingText.text = "Brodie Tower. Brownlow Street";
                    break;
                case "SherringtonStartArea":
                    buildingText.text = "Sherrington Building. Ashton Street";
                    break;
                case "ElectricalStartArea":
                    buildingText.text = "Electrical Engineering Building. Department of Electrical Engineering and Electronics";
                    break;
                case "GeorgeHoltStartArea":
                    buildingText.text = "George Holt Building. Computer Science Labs";
                    break;
                case "HarrisonHughesStartArea":
                    buildingText.text = "Harrison Hughes Building. School of Engineering";
                    break;
            }          

            panel.SetActive(true);
            other.GetComponent<Renderer>().material.color = Color.green;


        //if walking over a diploma, disable the objecet so it cant be repeatedly collected
        }else if(other.gameObject.CompareTag("diploma"))
        {
            audio.PlayOneShot(collectObjectSound, volume);
            other.gameObject.SetActive(false);
        }else if (other.gameObject.CompareTag("speedboost"))
        {
            StartCoroutine(Boost());
        }else if (other.gameObject.CompareTag("speedslow"))
        {
            StartCoroutine(Slow());
        }else if (other.gameObject.CompareTag("patrol"))
        {
            transform.position = new Vector3(startX, startY, startZ);
        }else if (other.gameObject.CompareTag("triggerPad"))
        {
            
            float force = 700;
            if (triggered == false)
            {
                bigF.GetComponent<Rigidbody>().isKinematic = false;
                bigF.GetComponent<Rigidbody>().AddForce(Vector3.left * force);
                triggered = true;
            }
            
        }else if (other.gameObject.CompareTag("f"))
        {
            transform.position = new Vector3(startX, startY, startZ);
        }
    }

    IEnumerator Boost()
    {
        
        float boostTime = 3f;
        float previousSpeed = runSpeed;
       
       SavedSettings.RunSpeed = 600;

        float time = 0;
        while (time < boostTime)
        {
            time += Time.deltaTime;
            yield return null;
        }

        SavedSettings.RunSpeed = 200;
        
    }

    IEnumerator Slow()
    {

        float boostTime = 3f;
        float previousSpeed = runSpeed;

        SavedSettings.RunSpeed = 10;

        float time = 0;
        while (time < boostTime)
        {
            time += Time.deltaTime;
            yield return null;
        }

        SavedSettings.RunSpeed = 200;

    }

    //when user leaves the pad, hide the info screen
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Pad"))
        {
            panel.SetActive(false);
            other.GetComponent<Renderer>().material.color = Color.red;
        }
    }

}