using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float velocidade = 5f;
    public float velocidadeRotacao = 150f;
    public float distanciaDash = 4f;

    private Vector3 posJogador = new Vector3(0f, 0f, 0f);
    private Vector3 posInimigo = new Vector3(5f, 0f, 0f);

    
    private bool podeSeMover = true;
    private float multiplicadorTempo = 1f;
    private float tempoSobrevivido = 0f;

    
    private float velocidadePatrulha = 3f;

    void Start()
    {
        Debug.Log("Sistema iniciado");

        //1. Teletransporte
        transform.position = new Vector3(0f, 5f, 0f);

        //2. Escala
        transform.localScale = new Vector3(2f, 2f, 2f);

        //3. Atalho Vector3.up
        transform.position += Vector3.up * 3f;

        //5. Distância
        float distancia = Vector3.Distance(posJogador, posInimigo);
        Debug.Log("Distância: " + distancia);
    }

    void Update()
    {
        

        float horizontalRaw = Input.GetAxisRaw("Horizontal");

        if (horizontalRaw > 0)
            Debug.Log("Direita");
        else if (horizontalRaw < 0)
            Debug.Log("Esquerda");
        else
            Debug.Log("Parado");

        float verticalSuave = Input.GetAxis("Vertical");
        Debug.Log("Vertical suave: " + verticalSuave);

        
        //9. FREIO
        

        if (Input.GetKeyDown(KeyCode.F))
        {
            podeSeMover = false;
            Debug.Log("Movimentação travada");
        }

        

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(horizontal, vertical, 0f).normalized;

        if (podeSeMover)
        {
            //12. SHIFT (SLOW MOTION)
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                multiplicadorTempo = 0.5f;
            else
                multiplicadorTempo = 1f;

            transform.Translate(direcao * velocidade * multiplicadorTempo * Time.deltaTime);
        }

        
        //8. PULO
       

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(Vector3.up);
        }

        
        //13. DASH
        

        if (Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0))
        {
            if (direcao == Vector3.zero)
                direcao = Vector3.right;

            transform.Translate(direcao * distanciaDash);
        }

        
        //4. RESET
        

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = Vector3.zero;
        }

        
        //10. ERRO INTENCIONAL
        

        transform.Translate(Vector3.right);
        Debug.Log("Movimento MUITO rápido (sem deltaTime)");

        
        //14. CRONÔMETRO
        

        tempoSobrevivido += Time.deltaTime;
        Debug.Log("Tempo: " + tempoSobrevivido.ToString("F2"));

        
        //15. PATRULHA
        

        transform.Translate(Vector3.right * velocidadePatrulha * Time.deltaTime);

        if (transform.position.x > 5f || transform.position.x < -5f)
        {
            velocidadePatrulha *= -1f;
        }
    }
}