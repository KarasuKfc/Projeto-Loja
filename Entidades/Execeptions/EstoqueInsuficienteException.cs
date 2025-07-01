using System;

namespace trabalhoparte1.Entidades.Execeptions
{
    public class EstoqueInsuficienteExeception : Exception
    {
        public EstoqueInsuficienteExeception(string mensagem) : base(mensagem)
        {
            
        }
    }
}