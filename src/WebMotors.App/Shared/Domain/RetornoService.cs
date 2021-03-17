using System.Collections.Generic;

namespace WebMotors.App.Shared.Domain
{
    public class RetornoService
    {
        public RetornoService()
        {
            Erros = new List<string>();
        }

        public object Retorno { get; set; }
        public string Mensagem { get; set; }
        public List<string> Erros { get; set; }

        public bool hasErrors => Erros.Count > 0;

        public void AddError(string error) =>
            Erros.Add(error);

    }
}
