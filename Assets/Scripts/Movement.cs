using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class TopDownCharacterController : MonoBehaviour
{
    public AudioResource[] audios;

    public float moveSpeed = 0.3f;
    public float IdleSpeed = 0.3f;
    public float RunSpeed = 0.6f;
    private float BoostSpeed = 40f;

    private Animator animator;
    public Animator animatorHand;
    private Transform transform;
    private Vector3 Scale = new Vector3();
    static public float horizontalInput;

    public bool MOVE = true;
    static public bool MoveAgr = true;

    public float smoothTime = 0.1f;

    private Rigidbody2D rb;
    private Vector2 velocity;

    static public bool StaminaBool = false;
    static public bool StaminaBoolMo = true;

    public bool shift = false;
    public bool space = false;

    static public int hp = 1;

    Shooting shooting;

    public Joystick joystick;

    void Start()
    {
        shooting = FindFirstObjectByType<Shooting>();

        joystick = FindFirstObjectByType<Joystick>();

        animator = GetComponent<Animator>();
        transform = GetComponent<Transform>();
        Scale = GetComponent<Transform>().localScale;
        rb = GetComponent<Rigidbody2D>();
        MoveAgr = true;
    }

    [SerializeField] private InputActionReference inputActionReference;

    static public bool movee = false;
    static public bool rune = false;

    void Update()
    {
        MOVE = MoveAgr;
        if (MoveAgr)
        {
            float horizontalInput = joystick.Horizontal;
            float verticalInput = joystick.Vertical;

            Vector2 inputDirection = new Vector2(horizontalInput, verticalInput).normalized;

            shooting.direction = inputDirection;
            // Вычисляем целевую скорость
            Vector2 targetVelocity = inputDirection * moveSpeed;

            // Используем SmoothDamp для мягкого изменения текущей скорости к целевой
            rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref velocity, smoothTime);

            if (shift && (StaminaScript.valuesInfo >= 0.2f && StaminaBoolMo) && (inputDirection.x != 0 || inputDirection.y != 0))
            {
                StaminaBool = true;
                moveSpeed = RunSpeed;
                rune = true;
            } else
            {
                rune = false;
            }
            if (StaminaScript.valuesInfo <= 0f)
            {
                StaminaBoolMo = false;
                moveSpeed = IdleSpeed;
            }

            if (space && (StaminaScript.valuesInfo >= 0.2f && StaminaBoolMo) && (inputDirection.x != 0 || inputDirection.x != 0))
            {
                moveSpeed = RunSpeed;
                if (space)
                {
                    StaminaBool = true;
                    Debug.Log("Dodge");
                        

                    // Применяем силу уклона
                    rb.AddForce(inputDirection * BoostSpeed, ForceMode2D.Impulse);

                    StaminaScript.Jumping = true;
                }
                
            }

            if (!shift || StaminaBoolMo == false)
            {
                if(StaminaScript.valuesInfo > 0.2)
                    StaminaBoolMo = true;
                StaminaBool = false;
                moveSpeed = IdleSpeed;
            }

            if (inputDirection.x != 0 || inputDirection.y != 0)
            {
                animator.SetBool("isRunning", true);
                animatorHand.SetBool("IsRun", true);

                movee = true;
            }
            else
            {
                movee = false;
                animator.SetBool("isRunning", false);
                animatorHand.SetBool("IsRun", false);
            }

            if (inputDirection.x > 0)
            {
                Scale.x = 1.0f;
                transform.localScale = Scale;
            }
            else if (inputDirection.x < 0)
            {
                Scale.x = -1.0f;
                transform.localScale = Scale;
            }
        } else
        {
            rb.velocity = Vector2.SmoothDamp(rb.velocity, new Vector2(0,0), ref velocity, smoothTime);
            movee = false;
            rune = false;
        }
        // Ограничение движения
        //transform.position = new Vector3(
        //    Mathf.Clamp(transform.position.x, -5f, 5f),
        //    Mathf.Clamp(transform.position.y, -5f, 5f),
        //    transform.position.z
        //);
    }
    void Dodge()
    {
        
    }
}
