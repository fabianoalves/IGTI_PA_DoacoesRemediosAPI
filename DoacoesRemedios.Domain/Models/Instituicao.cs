using System;
using System.Collections.Generic;
using System.Data;

namespace DoacoesRemedios.Domain
{
    public class Instituicao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string CEP { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}
