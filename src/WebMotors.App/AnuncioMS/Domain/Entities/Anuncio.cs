using WebMotors.App.Shared.Domain;

namespace WebMotors.App.AnuncioMS.Domain.Entities
{
    public class Anuncio: Base
    {
        public Anuncio()
        {

        }
        public void SetAnuncio(string marca, string modelo, string versao, int ano, int quilometragem, string observacao)
        {
            this.Marca = marca;
            this.Modelo = modelo;
            this.Versao = versao;
            this.Ano = ano;
            this.Quilometragem = quilometragem;
            this.Observacao = observacao;
        }

        public void SetId(int id)
        {
            this.Id = id;
        }

        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public string Versao { get; private set; }
        public int Ano { get; private set; }
        public int Quilometragem { get; private set; }
        public string Observacao { get; private set; }
    }
}
