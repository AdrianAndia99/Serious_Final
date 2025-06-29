using UnityEngine;

public class VehicleRotation : MonoBehaviour
{
    [Tooltip("Arrastra aquí el objeto que estás rotando manualmente")]
    public Transform objetoReferencia;

    [Header("Opciones")]
    [Tooltip("Si está activado, copia la rotación exacta instantáneamente")]
    public bool sincronizacionInstantanea = true;
    
    [Tooltip("Velocidad de rotación suavizada (solo si no es instantánea)")]
    [Range(1f, 20f)] public float velocidadSuavizado = 5f;
    
    void Update()
    {
        if (objetoReferencia == null) return;

        if (sincronizacionInstantanea)
        {
            // Rotación instantánea
            transform.rotation = objetoReferencia.rotation;
        }
        else
        {
            // Rotación suavizada (interpolación)
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                objetoReferencia.rotation,
                velocidadSuavizado * Time.deltaTime
            );
        }
    }
}