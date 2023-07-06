using UnityEngine;

public class ConeDeVisao : MonoBehaviour
{
    public float raio = 5f;
    public float angulo = 60f;

    private void OnDrawGizmos() // - Este � um m�todo especial do Unity que � chamado durante o desenho do Gizmo no Editor.
    {
        Gizmos.color = Color.yellow; //- Define a cor do Gizmo como amarelo.

        Vector2 direcaoInicial = Quaternion.Euler(0, 0, -angulo / 2) * transform.up; // Calcula a dire��o inicial do cone de vis�o. Usando um Quaternion, rotaciona o vetor transform.up (vetor para cima do objeto) por metade do �ngulo em torno do eixo Z.
        Vector2 direcaoFinal = Quaternion.Euler(0, 0, angulo / 2) * transform.up;

        Gizmos.DrawWireSphere(transform.position, raio); // Desenha uma esfera de arame (wireframe) para representar a �rea de alcance do cone de vis�o.
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + direcaoInicial * raio);// Desenha uma linha que vai do centro do objeto at� o limite inicial do cone de vis�o.
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + direcaoFinal * raio); //Desenha uma linha que vai do centro do objeto at� o limite final do cone de vis�o.

        float step = 0.1f; // - Define o incremento para interpola��o linear entre as dire��es inicial e final.
        float t = 0; // Vari�vel de controle para a interpola��o linear.

        while (t <= 1) //- Inicia um loop para realizar a interpola��o linear entre as dire��es inicial e final.
        {
            Vector2 lerpedDirection = Vector2.Lerp(direcaoInicial, direcaoFinal, t); //Realiza uma interpola��o linear entre as dire��es inicial e final, com base no valor atual de t.
            Gizmos.DrawRay(transform.position, lerpedDirection * raio); // Desenha um raio a partir do centro do objeto na dire��o interpolada, multiplicado pelo raio do cone de vis�o.
            t += step; // - Incrementa o valor de t para a pr�xima itera��o da interpola��o linear.
        }
    }
}
