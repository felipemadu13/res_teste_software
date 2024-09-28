namespace eCommerce.Domain.DTO
{
    public class EstoqueBaixaDTO
    {
        public bool Sucesso { get; init; }

        public EstoqueBaixaDTO(bool sucesso)
        {
            Sucesso = sucesso;
        }
    }
}