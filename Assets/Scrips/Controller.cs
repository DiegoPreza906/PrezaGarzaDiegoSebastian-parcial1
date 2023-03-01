using UnityEngine;

public class Controller : MonoBehaviour
{
    private Rigidbody2D rigidB;

    private float horizontalMovement = 0f;//Entrada de controles

    [SerializeField] private float speedMovement; //Para que aparezca en el inspector y velocidad de Personajes

    [SerializeField] private float suavizado;

    private Vector3 velocidad = Vector3.zero; //en 0 para que no se mueva

    private bool LookR = true;

    [Header("Salto")]

    [SerializeField] private float JumpForce;
    [SerializeField] private LayerMask WIFloor;
    [SerializeField] private Transform controladorFloor;
    [SerializeField] Vector3 DBox;
    [SerializeField] private bool inFloor;
    private bool jumpC = false;


    [Header("Animacion")]
    private Animator animator;


    private void Start()
    {
        rigidB=GetComponent<Rigidbody2D>();

        animator=GetComponent<Animator>();
    }

    private void Update()//controles del jugador
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal") * speedMovement; //Toma la dirección del control
        animator.SetFloat("Horizontal", Mathf.Abs(horizontalMovement));
        if (Input.GetButtonDown("Jump"))
        {
            jumpC = true;
        }
    }

    private void FixedUpdate()//cambios en las físicas
    {
        inFloor = Physics2D.OverlapBox(controladorFloor.position, DBox, 0f, WIFloor);
        animator.SetBool("Ground", inFloor);
        //Mover
        Mover(horizontalMovement * Time.fixedDeltaTime,jumpC);

        jumpC = false;
    }

    private void Mover(float move, bool saltar)
    {
        Vector3 velocidadOb = new Vector2(move, rigidB.velocity.y); //velocidad de movimiento, y en del RgidiBody

        rigidB.velocity = Vector3.SmoothDamp(rigidB.velocity,velocidadOb,ref velocidad,suavizado); //Nos da suavizado de movimiento(velocidad,la que queremos llegar, que tan rapido)
        if(move>0 && !LookR)
        {
            Girar();
        }
        else if(move<0 && LookR)
        {
            Girar();
        }

        if(inFloor && saltar)
        {
            inFloor= false;
            rigidB.AddForce(new Vector2(0f, JumpForce));
        }
    
    }
    private void Girar()
    {
        LookR = !LookR;
        Vector3 escala = transform.localScale;
        escala.x *= -1;//para cambiar la dirección del personaje
        transform.localScale = escala;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorFloor.position, DBox);
    }
}

