namespace sleepSystemAPI.Models.Dtos
{
    public class RespuestaDto
    {
        public int preguntaId { get; set; }
        public int valor { get; set; }
        public string? texto { get; set; } // Para respuestas tipo hora o número de horas
    }
}
