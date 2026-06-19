using UnityEngine;
public class PlayerController : MonoBehaviour
{
    // Variável visível no Inspector para Designers testarem
    public float velocidadeDoJogador = 6.0f;
    public float velocidadeDeRotacao = 150.0f;
    // Variáveis privadas de controle interno
    private float inputHorizontal;
    private float inputVertical;

    private Vector3 posJogador = Vector3.zero;
    private Vector3 posInimigo = new Vector3(5f, 0f, 0f);

    void Start()
    {
        Debug.Log("Sistema de Input acoplado ao Eco.");

        //1.Teletransporte Ecológico
        transform.position = new Vector3(0f, 5f, 0f);

        //2. Crescimento da Árvore (Escala)
        transform.localScale = new Vector3(2f, 2f, 2f);

        //3. Atalhos de Direção
        transform.position += Vector3.up * 3f;

        //5. Distância entre Objetos
        float distancia = Vector3.Distance(posJogador, posInimigo);
        Debug.Log("Distância entre Jogador e Inimigo: " + distancia);

    }

    void Update()
    {
        // 1. Ler inputs de forma imediata (Raw)
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
        // 2. Construir vetor de direção
        Vector3 direcaoDoMovimento = new Vector3(inputHorizontal, 0, 0);
        // 3. Mover independente da taxa de frames
        transform.Translate(direcaoDoMovimento * velocidadeDoJogador * Time.deltaTime, Space.World);

        Vector3 direcaoDaRotacao = new Vector3(0, 0, inputVertical);
        transform.Rotate(new Vector3(inputVertical, inputHorizontal, 0) * velocidadeDeRotacao * Time.deltaTime);

        //4. Botão de Pânico (Reset de Posição)
        if (Input.GetKeyDown(KeyCode.R)){
            transform.position = Vector3.zero;

        //6. Detector de Direção Bruta (Eixo X)

            float horizontal = Input.GetAxisRaw("Horizontal");

            if (horizontal > 0){
                Debug.Log("Movendo para a Direita");
            } else if (horizontal < 0){
                Debug.Log("Movendo para a Esquerda");
            } else {
                Debug.Log("Parado");
            }

         //7.Eixo Vertical Suave    

            float vertical = Input.GetAxis("Vertical");

          


        }




    }
}



