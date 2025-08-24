namespace Mvc.Base
{
    public class ErrorResponse(Exception ex, string mensagemPersonalizada)
    {
        public string Message { get; set; } = ex.Message;
        public string? Details { get; set; } = mensagemPersonalizada;
    }
}
