using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class MathCollision : MonoBehaviour
{
    public TextMeshPro leftNumberText;
    public TextMeshPro rightNumberText;
    public TextMeshPro operationText;

    public GameObject wallLeft;   // GameObject da parede (com Collider)
    public GameObject wallRight;  // GameObject da parede (com Collider)
    public TextMeshPro wallLeftText;  // TextMeshPro para o número na parede esquerda
    public TextMeshPro wallRightText; // TextMeshPro para o número na parede direita

    public GameObject charModel;
    public GameObject player;

    private int leftNumber;
    private int rightNumber;
    private int answer;
    private string operation;

    private bool leftWall=false;
    private bool rightWall=false;

    private string[] operations = { "+", "-", "*" };

    void Start()
    {
        GenerateMathProblem();
    }

    void GenerateMathProblem()
    {
        leftNumber = Random.Range(1, 10);
        rightNumber = Random.Range(1, 10);

        operation = operations[Random.Range(0, operations.Length)];

        switch (operation)
        {
            case "+":
                answer = leftNumber + rightNumber;
                break;
            case "-":
                answer = leftNumber - rightNumber;
                break;
            case "*":
                answer = leftNumber * rightNumber;
                break;
        }

        leftNumberText.text = leftNumber.ToString();
        rightNumberText.text = rightNumber.ToString();
        operationText.text = operation;

        Debug.Log("Answer:" + answer);
        AssignAnswersToWalls();
    }

    void AssignAnswersToWalls()
    {
        int wrongAnswer = answer + Random.Range(-2, 3); 
        if (wrongAnswer == answer)
        {
            wrongAnswer += 1; 
        }

        if (Random.value < 0.5f)
    {
        wallLeftText.text = answer.ToString();
        wallRightText.text = wrongAnswer.ToString();
        rightWall = false;
        leftWall = true;
        Debug.Log("Respostas atribuídas: esquerda = correta, direita = errada");
    }
    else
    {
        wallLeftText.text = wrongAnswer.ToString();
        wallRightText.text = answer.ToString();
        rightWall = true;
        leftWall = false;
        Debug.Log("Respostas atribuídas: direita = correta, esquerda = errada");
    }
    
    }

void OnTriggerEnter(Collider other)
{
    // Obtém a posição do jogador no eixo X
    float playerX = player.transform.position.x;
    Debug.Log("Player x pos: " + playerX);

    // Verifica se o jogador colidiu com a parede correta
    if (rightWall)
    {
        if (playerX > 0)
        {
            Debug.Log("Parede correta");
        }
        else if (playerX<0)
        {
            Debug.Log("Parede Incorreta");
            Debug.Log("PlayerX final:"+ playerX);
            Debug.Log("rightWall:"+rightWall);
            HandleIncorrectWall();
        }
    }
    else if (leftWall)
    {
        if (playerX < 0)
        {
            Debug.Log("Parede correta");
        }
        else if (playerX > 0)
        {
            Debug.Log("Parede Incorreta");
            Debug.Log("PlayerX final:"+ playerX);
            Debug.Log("Left wall:"+leftWall);
            HandleIncorrectWall();
        }
    }
}

void HandleIncorrectWall()
{
    // Desativa o collider da parede para impedir futuras colisões
    this.gameObject.GetComponent<BoxCollider>().enabled = false;
    // Desativa o movimento do jogador
    player.GetComponent<PlayerMovement>().enabled = false;
    // Reproduz a animação de tropeço
    charModel.GetComponent<Animator>().Play("Stumble Backwards");

}

}
