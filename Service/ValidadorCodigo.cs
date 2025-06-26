using ProjetoLoja.Models;
using trabalhoparte1.Entidades;

namespace ProjetoLoja.Services;

public static class ValidadorCodigo
{

    public static bool VerificarCodigoDuplicado(IEntidadeComCodigo[] vetor, int contador, int codigo)
    {
        for (int i = 0; i < contador; i++)
        {
            if (vetor[i] != null && vetor[i].Codigo == codigo)
                return true;
        }
        return false;
    }
}






