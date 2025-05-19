using StarterAssets;
using UnityEngine;

public class Player : MonoBehaviour
{
    private StarterAssetsInputs starterAssetsInputs;
    [SerializeField] private Ball ball; // Referens till bollens script
    private Animator animator; // Referens till Animator-komponenten

    void Start()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (starterAssetsInputs.shoot && ball.IsStickingToPlayer) // Kontrollera både input och om bollen är klistrad
        {
            // Trigga skjutanimationen
            animator.SetTrigger("Shoot");
            // Skjut bollen i spelarens framåtriktning
            ball.Shoot(transform.forward);
            starterAssetsInputs.shoot = false; // Återställ input
        }
    }
}