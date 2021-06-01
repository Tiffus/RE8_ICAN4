using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class FPS_Controller : MonoBehaviour
{
    //Camera
    public Camera playerCamera;
 
    //Composant qui permet de faire bouger le joueur
    CharacterController characterController;
 
    //Vitesse de marche
    public float walkingSpeed = 7.5f;
 
    //Vitesse de course
    public float runningSpeed = 15f;
 
    //Vitesse de saut
    public float jumpSpeed = 8f;
 
    //Gravité
    public float gravity = 9.8f;
 
    //Déplacement
    Vector3 moveDirection;
 
    //Marche ou court ?
    private bool isRunning = false;
 
    //Rotation de la caméra
    float rotationX = 0;
    public float rotationSpeed = 2.0f;
    public float rotationXLimit = 45.0f;
     
 
    void Start()
    {
        //Cacher ou pas le curseur de la souris
        Cursor.visible = false;
        // lock le curseur 
        Cursor.lockState = CursorLockMode.Locked;

        characterController = GetComponent<CharacterController>();  
    }
 
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
 
 
        // Z = axe arrière/avant
        float speedZ = Input.GetAxis("Vertical");
 
        // X = axe gauche/droite
        float speedX = Input.GetAxis("Horizontal");
 
        // Y = axe haut/bas
        float speedY = moveDirection.y;
 
 
        if (Input.GetKey(KeyCode.LeftShift)) {
            //En train de courir
            isRunning = true;
        }
        else {
            //En train de marcher
            isRunning = false;
        }
 
        if (isRunning) {
            speedX = speedX * runningSpeed;
            speedZ = speedZ * runningSpeed;
        }
        else {

            speedX = speedX * walkingSpeed;
            speedZ = speedZ * walkingSpeed;
        }
 
        // Calcul du mouvement 
        moveDirection = forward * speedZ + right * speedX;
 
        
        // Bouton de saut = Espace
        if (Input.GetButton("Jump") && characterController.isGrounded) {
 
            moveDirection.y = jumpSpeed;
        }
        else {

            moveDirection.y = speedY;
        }
 
 
        if (!characterController.isGrounded) {
            //Applique la gravité si le joueur ne touche pas le sol
            moveDirection.y -= gravity * Time.deltaTime;
        }
 
 
        //Applique le mouvement
        characterController.Move(moveDirection * Time.deltaTime);
 
 
 
        //Rotation de la caméra 
        rotationX += -Input.GetAxis("Mouse Y") * rotationSpeed; 
        rotationX = Mathf.Clamp(rotationX, -rotationXLimit, rotationXLimit); 
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0); 
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * rotationSpeed, 0);
    }

    
}