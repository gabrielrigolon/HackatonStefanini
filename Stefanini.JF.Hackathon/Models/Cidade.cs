using System;
using System.Collections.Generic;
using System.Text;

namespace Stefanini.JF.Hackathon.Models
{
    public class Cidade
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int CandidatosAprovados { get; private set; }

        public void ComecarContagemAprovados()
        {
            CandidatosAprovados = 0;
        }

        public void AumentarCandidatoAprovado()
        {
            CandidatosAprovados++;
        }
    }
}
