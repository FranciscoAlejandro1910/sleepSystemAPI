using sleepSystemAPI.Models.Dtos;
using sleepSystemAPI.Models; // Para usar la clase Pregunta

namespace sleepSystemAPI.Services
{
    public class PsqiCalculator
    {
        public EvaluacionResponse Calcular(List<RespuestaDto> respuestas, List<Pregunta> preguntas)
        {
            int c1 = CalcularComponente(respuestas, preguntas, 1);
            int c2 = CalcularComponente2(respuestas);
            int c3 = CalcularComponente3(respuestas);
            int c4 = CalcularComponente4(respuestas);
            int c5 = CalcularComponente5(respuestas);
            int c6 = CalcularComponente(respuestas, preguntas, 6);
            int c7 = CalcularComponente7(respuestas);

            return new EvaluacionResponse
            {
                componente1 = c1,
                componente2 = c2,
                componente3 = c3,
                componente4 = c4,
                componente5 = c5,
                componente6 = c6,
                componente7 = c7,
                puntajeTotal = c1 + c2 + c3 + c4 + c5 + c6 + c7
            };
        }


        private int CalcularComponente(List<RespuestaDto> respuestas, List<Pregunta> preguntas, int componente)
        {
            var ids = preguntas
           .Where(p => p.ItemPsqi == componente || p.ItemPsqi.ToString().Contains(componente.ToString()))
           .Select(p => p.IdPregunta)
           .ToList();



            return respuestas
                .Where(r => ids.Contains(r.preguntaId))
                .Sum(r => r.valor);
        }

        private int CalcularComponente2(List<RespuestaDto> respuestas)
        {
            var suma = respuestas
                .Where(r => r.preguntaId == 2 || r.preguntaId == 5)
                .Sum(r => r.valor);

            if (suma > 0 && suma <= 2)
            {
                return 1;
            }
            else if (suma > 2 && suma <= 4)
            {
                return 2;
            }
            else
            {
                return 3;
            }

        }

        private double ParseHorasDormidas(string? horasDormidasStr)
        {
            if (string.IsNullOrEmpty(horasDormidasStr))
                return 0;

            return horasDormidasStr.Trim() switch
            {
                "< 5 horas" => 4.5,
                "5 - 6 horas" => 5.5,
                "6 - 7 horas" => 6.5,
                "> 7 horas" => 7.5,
                _ => double.TryParse(horasDormidasStr, System.Globalization.CultureInfo.InvariantCulture, out var val) ? val : 0
            };
        }

        private int CalcularComponente3(List<RespuestaDto> respuestas)
        {
            var horasDormidasStr = respuestas.FirstOrDefault(r => r.preguntaId == 4)?.texto;
            double horasDormidas = ParseHorasDormidas(horasDormidasStr);

            if (horasDormidas >= 7)
                return 0;
            else if (horasDormidas >= 6)
                return 1;
            else if (horasDormidas >= 5)
                return 2;
            else
                return 3;
        }

        private int CalcularComponente4(List<RespuestaDto> respuestas)
        {
            var acostarse = respuestas.FirstOrDefault(r => r.preguntaId == 1)?.texto;
            var levantarse = respuestas.FirstOrDefault(r => r.preguntaId == 3)?.texto;
            var horasDormidasStr = respuestas.FirstOrDefault(r => r.preguntaId == 4)?.texto;

            if (string.IsNullOrEmpty(acostarse) || string.IsNullOrEmpty(levantarse) || string.IsNullOrEmpty(horasDormidasStr))
                return 0;

            var horaAcostarse = TimeSpan.Parse(acostarse);
            var horaLevantarse = TimeSpan.Parse(levantarse);

            double horasEnCama = (horaLevantarse - horaAcostarse).TotalHours;
            if (horasEnCama < 0)
                horasEnCama += 24;

            double horasDormidas = ParseHorasDormidas(horasDormidasStr);

            double eficiencia = (horasDormidas / horasEnCama) * 100;

            if (eficiencia >= 85)
                return 0;
            else if (eficiencia >= 75)
                return 1;
            else if (eficiencia >= 65)
                return 2;
            else
                return 3;
        }

        private int CalcularComponente5(List<RespuestaDto> respuestas)
        {
            var suma = respuestas
                .Where(r => r.preguntaId == 6 || r.preguntaId == 7 || r.preguntaId == 8 || r.preguntaId == 9 || r.preguntaId == 10 || r.preguntaId == 11 || r.preguntaId == 12 || r.preguntaId == 13)
                .Sum(r => r.valor);

            if (suma == 0)
            {
                return 0;
            }
            else if (suma >= 1 && suma <= 9)
            {
                return 1;
            }
            else if (suma >= 10 && suma <= 18)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }

        private int CalcularComponente7(List<RespuestaDto> respuestas)
        {
            var suma = respuestas
                .Where(r => r.preguntaId == 16 || r.preguntaId == 17 )
                .Sum(r => r.valor);

            if (suma == 0)
            {
                return 0;   
            }
            else if (suma >= 1 && suma <= 2)
            {
                return 1;
            }
            else if (suma >= 3 && suma <= 4)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }
    }
}