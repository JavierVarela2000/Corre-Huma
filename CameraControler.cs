using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    //variables
    public Transform target;//variable a seguir(objetivo)
    public Vector3 oftset = new Vector3(0.1f,0f,-10f);//distancia con la que debe seguir la camara
    public float dampTime = 0.3f; // tiempo antes de que la camara empiece a seguir
    public Vector3 velocity= Vector3.zero; // velocidad a la que sigue la camara 
    public float CorreccionDeCamaraX = -70f;

    // Start is called before the first frame update
    private void Awake()
    {
        Application.targetFrameRate = 60;//indica que intente renderizar al numero de frames si esque puede
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);//siga al target con los parametros del inicio
        Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(oftset.x,oftset.y,point.z)); //incremento: cuanto debe moverse la camara para seguir al jugador
        Vector3 destination = point + delta;
        destination = new Vector3(target.position.x-CorreccionDeCamaraX, oftset.y, oftset.z);//corrige el desplazamiento irreversible de la camara en y
        this.transform.position = Vector3.SmoothDamp(this.transform.position, destination, ref velocity, dampTime);//asigna la posicion de la camara al destino de forma suave
            
    }
}
