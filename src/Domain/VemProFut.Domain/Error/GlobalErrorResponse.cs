namespace VemProFut.Domain.Error
{
    public record GlobalErrorResponse
    {
        public string Message { get; } = "Um erro ocorreu. Por favor, tente novamente.";
    }
}
