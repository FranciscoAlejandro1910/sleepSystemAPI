namespace sleepSystemAPI.Models.Dtos
{
    public class EvaluacionRequest
    {
        public int usuarioId { get; set; }

        public List<RespuestaDto> Respuestas { get; set; } 


    }
}
