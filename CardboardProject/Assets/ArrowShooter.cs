using UnityEngine;

public class ArrowShooter : MonoBehaviour
{
    public GameObject arrowPrefab; // Prefab de la flecha a disparar
    public Transform shootPoint; // Punto de origen del disparo (normalmente el jugador)
    public float shotDuration = 4f; // Duración del disparo en segundos
    public float shootingForce = 4f;

    private float shotTimer; // Temporizador del disparo

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ShootArrow();
        }

        if (shotTimer > 0f)
        {
            shotTimer -= Time.deltaTime;
            if (shotTimer <= 0f)
            {
                // El disparo ha alcanzado su duración, restablecer valores
                shotTimer = 0f;
                // Aquí podrías realizar acciones adicionales después de que el disparo haya terminado
            }
        }
    }

    void ShootArrow()
    {
        if (shotTimer > 0f)
        {
            // El disparo aún está en curso, no se puede disparar otra flecha
            return;
        }

        // Crear la flecha en el punto de origen del disparo y con la dirección del jugador
        GameObject arrow = Instantiate(arrowPrefab, shootPoint.position, shootPoint.rotation);

        // Obtener el componente Rigidbody de la flecha
        Rigidbody arrowRigidbody = arrow.GetComponent<Rigidbody>();

        // Aplicar una fuerza hacia adelante en la dirección en la que el jugador está mirando
        arrowRigidbody.AddForce(shootPoint.forward * shootingForce, ForceMode.Impulse);

        // Establecer la velocidad y dirección de la flecha basándonos en la rotación del jugador
        arrowRigidbody.velocity = shootPoint.forward * arrowRigidbody.velocity.magnitude;

        // Asignar una referencia al script ArrowCollision para manejar la colisión
        // ArrowCollision arrowCollision = arrow.GetComponent<ArrowCollision>();
        // arrowCollision.SetArrowShooter(this);

        // Comenzar el temporizador del disparo
        shotTimer = shotDuration;
    }

    public void DestroyArrow(GameObject arrow)
    {
        Destroy(arrow);
    }
}
