namespace VemProFut.Domain.Error
{
    public record GlobalErrorResponse
    {
        public string Message { get; init; } = "Um erro ocorreu. Por favor, tente novamente.";
    }
}
