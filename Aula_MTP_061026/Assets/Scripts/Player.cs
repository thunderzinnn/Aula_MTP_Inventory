using UnityEngine;


public class Player : MonoBehaviour
{
    private Rigidbody rb;

    public float velocidade = 6.0f;
    

  


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.freezeRotation = true;
    }

    void Update()
    {
  
        
    }

    void FixedUpdate()
    {
        float moverX = Input.GetAxisRaw("Horizontal");
        float moverZ = Input.GetAxisRaw("Vertical");

      
        Vector3 direcao = (transform.right * moverX + transform.forward * moverZ).normalized;

      
        rb.linearVelocity = new Vector3(direcao.x * velocidade, rb.linearVelocity.y, direcao.z * velocidade);
    }

   
}
