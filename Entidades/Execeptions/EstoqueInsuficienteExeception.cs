using System;

namespace trabalhoparte1.Entidades.Execeptions
{
    public class EstoqueInsuficienteException : Exception
    {
        public EstoqueInsuficienteException(string mensagem) : base(mensagem)
        {
            
        }
    }
}