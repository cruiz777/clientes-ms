using clientes_ms.Domain.Entities;
using clientes_ms.Application.Queries.Ssccs;
using System.Linq.Expressions;
using clientes_ms.Domain.Common;

namespace clientes_ms.Domain.Specifications
{
    public class SsccFilterSpecification
    {
        public Expression<Func<Sscc, bool>> Criteria { get; }

        public SsccFilterSpecification(GetSsccByClienteConFiltrosQuery request)
        {
            var predicates = new List<Expression<Func<Sscc, bool>>>();

            // Filtro obligatorio por cliente
            predicates.Add(s => s.IdCliente == request.IdCliente);

            // Aplicar filtros opcionales
            ApplyOptionalFilters(predicates, request);

            // Combinar todos los predicados con AND
            Criteria = CombinePredicates(predicates);
        }

        private void ApplyOptionalFilters(List<Expression<Func<Sscc, bool>>> predicates, GetSsccByClienteConFiltrosQuery request)
        {
            if (request.IdPrefijo.HasValue)
                predicates.Add(s => s.IdPrefijo == request.IdPrefijo.Value);

            if (!string.IsNullOrWhiteSpace(request.Busqueda))
            {
                var busqueda = request.Busqueda.Trim().ToLower();
                predicates.Add(s =>
                    s.Serial.ToLower().Contains(busqueda) ||
                    s.SsccCompleto.ToLower().Contains(busqueda) ||
                    s.Usuario!.ToLower().Contains(busqueda));
            }

            if (!string.IsNullOrWhiteSpace(request.Empaque))
                predicates.Add(s => s.Indicador.ToString() == request.Empaque);

            if (request.Estado.HasValue)
                predicates.Add(s => s.Estado == request.Estado.Value);

            if (request.FechaDesde.HasValue)
                predicates.Add(s => s.FechaCreacion >= request.FechaDesde.Value);

            if (request.FechaHasta.HasValue)
            {
                var fechaHasta = request.FechaHasta.Value.Date.AddDays(1).AddTicks(-1);
                predicates.Add(s => s.FechaCreacion <= fechaHasta);
            }
        }

        private Expression<Func<Sscc, bool>> CombinePredicates(List<Expression<Func<Sscc, bool>>> predicates)
        {
            if (!predicates.Any())
                return s => true;

            var combined = predicates.First();

            foreach (var predicate in predicates.Skip(1))
            {
                combined = CombineWithAnd(combined, predicate);
            }

            return combined;
        }

        private Expression<Func<Sscc, bool>> CombineWithAnd(
            Expression<Func<Sscc, bool>> left,
            Expression<Func<Sscc, bool>> right)
        {
            var parameter = Expression.Parameter(typeof(Sscc), "s");
            var leftBody = ReplaceParameter(left.Body, left.Parameters[0], parameter);
            var rightBody = ReplaceParameter(right.Body, right.Parameters[0], parameter);
            var combinedBody = Expression.AndAlso(leftBody, rightBody);

            return Expression.Lambda<Func<Sscc, bool>>(combinedBody, parameter);
        }

        private Expression ReplaceParameter(Expression expression, ParameterExpression oldParameter, ParameterExpression newParameter)
        {
            return new ParameterReplacer(oldParameter, newParameter).Visit(expression);
        }
    }
}