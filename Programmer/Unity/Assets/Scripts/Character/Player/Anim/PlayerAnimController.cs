using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    Animator animator;
    public PlayerClassAcces playerClass;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        playerClass = GetComponent<PlayerClassAcces>();
    }

    // Update is called once per frame
    void Update()
    {
        // €–S‚Ü‚½‚ÍƒXƒ^ƒ“‚Ì‚Í“ü—Í‚ğˆêØó‚¯•t‚¯‚È‚¢
        if (playerClass.player.state == PlayerClass.State.death || playerClass.player.state == PlayerClass.State.stun)
        {
            return;
        }
        animator.SetBool("Wark", playerClass.player.state == PlayerClass.State.wark);
        animator.SetBool("Idol", playerClass.player.state == PlayerClass.State.normal);
        animator.SetBool("Jump", playerClass.player.state == PlayerClass.State.jump);
    }
}
