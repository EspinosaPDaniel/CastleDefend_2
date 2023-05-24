using UnityEngine;

public class ArrowCollision : MonoBehaviour
{
    private ArrowShooter arrowShooter;

    public void SetArrowShooter(ArrowShooter shooter)
    {
        arrowShooter = shooter;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Comprobar si la flecha chocó con otro objeto
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Destruir la flecha
            arrowShooter.DestroyArrow(gameObject);
        }
    }
}