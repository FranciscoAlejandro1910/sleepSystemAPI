using sleepSystemAPI.Models.Dtos;

namespace sleepSystemAPI.Services
{
    public interface IEvaluacionService
    {
        EvaluacionResponse procesarEvaluacion(EvaluacionRequest request);
    }
}
