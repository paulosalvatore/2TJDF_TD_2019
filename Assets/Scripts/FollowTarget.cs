using System;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [Header("Target")]
    public Transform target;
    public string targetTag;

    [Header("Movimento")]
    public float velocidadeMovimento = 1f;

    [Header("Rotação")]
    public float velocidadeRotacao = 1f;
    public bool lookAt = false;

    void Start()
    {
	}

	void Update()
    {
        Movimentar();
        Rotacionar();
    }

    private void Movimentar()
    {
        // Se a variável lookAt estiver marcada ou se não
        // possuímos uma informação de target, movimentamos
        // em linha reta
        if (lookAt || target == null)
        {
            // Movimenta em linha reta
            transform.Translate(
                Vector3.forward * velocidadeMovimento * Time.deltaTime
            );
        }
        // Caso contrário, se tivermos um target
        else if (target != null)
        {
            Vector3 direcao = (target.position - transform.position).normalized;
            transform.Translate(
                direcao * velocidadeMovimento * Time.deltaTime,
                Space.World
            );
        }
    }

    private void Rotacionar()
    {
        if (lookAt && target != null)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(
                    target.position - transform.position
                ),
                Time.deltaTime * velocidadeRotacao
            );
        }
    }
}
