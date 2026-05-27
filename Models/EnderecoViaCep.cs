namespace DataBridge.Models
{
    public class EnderecoViaCep
    {
        public string Cep { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public string Localidade { get; set; } = string.Empty;
        public string Uf { get; set; } = string.Empty;  
        public bool Erro { get; set; }
    }
}
