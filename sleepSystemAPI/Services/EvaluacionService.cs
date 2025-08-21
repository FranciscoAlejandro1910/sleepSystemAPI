using sleepSystemAPI.Models.Dtos;
using sleepSystemAPI.Models;

namespace sleepSystemAPI.Services
{
    public class EvaluacionService : IEvaluacionService
    {
        private readonly PsqiCalculator _calculator;
        private readonly SleepSystemContext _context;

        public EvaluacionService(PsqiCalculator calculator, SleepSystemContext context)
        {
            _calculator = calculator;
            _context = context;
        }

        public EvaluacionResponse procesarEvaluacion(EvaluacionRequest request)
        {
            // Obtiene todas las preguntas de la base de datos
            var preguntasDeLaBase = _context.Preguntas.ToList();

            // Calcula el resultado usando las respuestas y las preguntas
            var resultado = _calculator.Calcular(request.Respuestas, preguntasDeLaBase);

            return resultado;
        }
    }
}
