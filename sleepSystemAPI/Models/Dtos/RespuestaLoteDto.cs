using System.Collections.Generic;

namespace sleepSystemAPI.Models.Dtos
{
    public class RespuestaLoteDto
    {
        public int usuarioId { get; set; }
        public List<RespuestaDto> respuestas { get; set; }
    }
}