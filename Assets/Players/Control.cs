using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;


public class Control : MonoBehaviourPunCallbacks, IPunObservable
{
    public CharacterController characterController;
    public PhotonView view;
    public GameObject Camera;
    public GameObject playerMesh;
    public float speed = 3;

    // camera and rotation
    public float mouseSensitivity = 2f;
    public float upLimit = -50;
    public float downLimit = 50;

    public int life = 100;

    // gravity
    private float gravity = 9.87f;
    private float verticalSpeed = 0;
    public float jumpHeight = 1;
    private float upMove = 0;

    private void Start()
    {
        view = GetComponent<PhotonView>();
        if (view.IsMine)
        {
            playerMesh.layer = 3;
        }
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        if (view.IsMine)
        {
            Move();
            Rotate();
            //upMove = 0;

            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out RaycastHit _hit, 15f))
                {
                    if (_hit.collider.CompareTag("Player"))
                    {
                        _hit.collider.GetComponent<Control>().TakeDamage(100);
                    }
                    else if (_hit.collider.CompareTag("Computer") && PhotonNetwork.IsMasterClient)
                    {
                        PhotonNetwork.LoadLevel("GameScene");
                        SceneManager.LoadScene("GameScene");
                    }
                }
            }
            if (Input.GetButtonDown("Jump") && characterController.isGrounded)
            {
                //upMove = jumpHeight;
            }
        }
        else
        {
            Camera.GetComponent<Camera>().enabled = false;
        }
    }

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Rotate()
    {
        float horizontalRotation = Input.GetAxis("Mouse X");
        float verticalRotation = Input.GetAxis("Mouse Y");

        transform.Rotate(0, horizontalRotation * mouseSensitivity, 0);
        Camera.transform.Rotate(verticalRotation * mouseSensitivity * -1, 0, 0);
    }

    private void Move()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        if (characterController.isGrounded) verticalSpeed = 0;
        else verticalSpeed -= gravity * Time.deltaTime;
        Vector3 gravityMove = new Vector3(0, verticalSpeed, 0);
    
        Vector3 move = transform.forward * verticalMove + transform.right * horizontalMove + transform.up * upMove;
        characterController.Move(speed * Time.deltaTime * move + gravityMove * Time.deltaTime);
    }

    public void TakeDamage(int amt)
    {
        life -= amt;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(life);
        }
        else
        {
            life = (int)stream.ReceiveNext();
        }
    }
}