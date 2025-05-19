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
        if (starterAssetsInputs.shoot && ball.IsStickingToPlayer) // Kontrollera b�de input och om bollen �r klistrad
        {
            // Trigga skjutanimationen
            animator.SetTrigger("Shoot");
            // Skjut bollen i spelarens fram�triktning
            ball.Shoot(transform.forward);
            starterAssetsInputs.shoot = false; // �terst�ll input
        }
    }
}