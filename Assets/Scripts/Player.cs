using Cavacos.ScriptsCavacos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Player : MonoBehaviour
{

    public States state;
    public static Player instance { get; private set; }
    public static CharacterControls _controls { get; private set; }
    public static UnityEvent<States> OnChangeState = new UnityEvent<States>();
    public Transform body;
    [SerializeField] SpriteRenderer direction;
    public Rigidbody2D rb2D;
    public PlayerHealth healthSystem;
    public bool isDead = false;
    public Parry parry;
    public Animator animator;
    public PlayerRotation playerRotation;
    private void Awake()
    {
        if (instance!=null)
        {
            Destroy(gameObject);
        }
        instance = this;
        _controls = new CharacterControls();
        isDead = false;
        animator.SetBool("Dead", false);
    }
    private void Start()
    {        
        ChangeState(States.IDLE);
    }

    private void OnEnable()
    {
        _controls.Character.Movement.Enable();
        _controls.Character.Direction.Enable();
        _controls.Character.Roll.Enable();
        _controls.Character.Block.Enable();
        _controls.Character.Attack.Enable();
        _controls.Character.Style0.Enable();
        _controls.Character.Style1.Enable();
        _controls.Character.Style2.Enable();
        _controls.Character.Style3.Enable();
    }
    private void OnDisable()
    {
        _controls.Character.Movement.Disable();
        _controls.Character.Direction.Disable();
        _controls.Character.Roll.Disable();
        _controls.Character.Block.Disable();
        _controls.Character.Attack.Disable();
        _controls.Character.Style0.Disable();
        _controls.Character.Style1.Disable();
        _controls.Character.Style2.Disable();
        _controls.Character.Style3.Disable();
    }
    public void ChangeState(States s)
    {
        state = s;
        OnChangeState?.Invoke(s); 
    }
    
    public void KillPlayer()
    {
        if (!isDead)
        {
            var components = GetComponents<PlayerComponent>();
            Debug.LogWarning($"Player components ammount : {components.Length}");
            foreach (var c in components)
            {
                c.OnDie();
                c.enabled = false;
            }
            isDead = true;
            rb2D.isKinematic = true;
            rb2D.velocity = Vector2.zero;
            //Feedback
            body.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
            direction.color = new Color(255, 255, 255, 0.5f);
            GetComponent<Collider2D>().enabled = false;
            animator.SetBool("Dead", true);
        }
        
    }
}
public enum States
{
    IDLE,
    ROLL,
    BLOCK,
    ATK,
    DEAD
}
