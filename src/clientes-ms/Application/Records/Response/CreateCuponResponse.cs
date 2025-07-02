namespace clientes_ms.Application.Records.Response
{
    public record CreateCuponResponse
    {
        public List<string> CuponesGenerados { get; init; } = new();
        public List<string> CuponesDuplicados { get; init; } = new();
    }

}
