using System;

namespace trabalhoparte1.Entidades.Execeptions
{
    public class ProdutoNaoEncontradoException : Exception
    {
        public ProdutoNaoEncontradoException(string mensagem) : base(mensagem)
        {
        }
    }
}


