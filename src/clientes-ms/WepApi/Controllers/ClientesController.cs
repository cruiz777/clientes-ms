using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using clientes_ms.Application.Queries.Clientes;
using clientes_ms.Application.Handlers.Cliente;
using clientes_ms.Application.Commands.Clientes;
using clientes_ms.Infrastructure.Persistence.Context;

namespace clientes_ms.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _context;

        public ClientesController(
            IMediator mediator,
            ApplicationDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        // =========================================================
        // GET TODOS
        // =========================================================

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result =
                await _mediator.Send(
                    new GetAllClientesQuery()
                );

            return Ok(result);
        }

        // =========================================================
        // RESUMEN
        // =========================================================

        [HttpGet("resumen")]
        public async Task<IActionResult> GetClientesResumen(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? busquedaGeneral = null,
            [FromQuery] string? prefijoBusqueda = null)
        {
            var result =
                await _mediator.Send(
                    new GetClientesByResumen(
                        pageNumber,
                        pageSize,
                        busquedaGeneral,
                        prefijoBusqueda
                    )
                );

            return Ok(result);
        }

        // =========================================================
        // RESUMEN PAGINADO
        // =========================================================

        [HttpGet("resumeng")]
        public async Task<IActionResult> GetClientesPaged(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? busquedaGeneral = null,
            [FromQuery] string? prefijoBusqueda = null)
        {
            var query =
                new GetClientesPaged
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    BusquedaGeneral = busquedaGeneral,
                    PrefijoBusqueda = prefijoBusqueda
                };

            var result =
                await _mediator.Send(query);

            return Ok(new
            {
                data = result.Data,
                count = result.Count
            });
        }

        // =========================================================
        // BUSCAR POR NOMBRE
        // =========================================================

        [HttpGet("buscar-por-nombre")]
        public async Task<IActionResult> BuscarPorNombre(
            [FromQuery] string nombre)
        {
            var resultado =
                await _mediator.Send(
                    new GetClientesByNombreLikeQuery(nombre)
                );

            return Ok(resultado);
        }

        // =========================================================
        // GET POR ID
        // =========================================================

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result =
                await _mediator.Send(
                    new GetClientesByIdQuery(id)
                );

            if (result == null)
            {
                return NotFound(new
                {
                    message = "Cliente no encontrado"
                });
            }

            return Ok(result);
        }

        // =========================================================
        // GET POR RUC
        // =========================================================

        [HttpGet]
        [Route("/api/ruc")]
        public async Task<IActionResult> GetByRuc(string ruc)
        {
            var result =
                await _mediator.Send(
                    new GetClientesByRucQuery(ruc)
                );

            return Ok(result);
        }

        // =========================================================
        // CREATE
        // =========================================================

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] ClientesRequest request)
        {
            var result =
                await _mediator.Send(
                    new CreateClientesCommand(request)
                );

            return Ok(result);
        }

        // =========================================================
        // VALIDAR CLIENTE SRI
        // =========================================================

        [HttpPost("validar")]
        public async Task<IActionResult> ValidarClienteSri(
            [FromBody] long clienteId)
        {
            var result =
                await _mediator.Send(
                    new ValidarClienteSriQuery(clienteId)
                );

            if (result.Data == null)
            {
                return NotFound(new
                {
                    message = result.Message
                });
            }

            return Ok(result);
        }

        // =========================================================
        // VALIDAR CLIENTES MASIVO
        // =========================================================

        [HttpPost("validar-masivo")]
        public async Task<IActionResult> ValidarClientesSriMasivo(
            [FromBody] List<long> clienteIds)
        {
            var result =
                await _mediator.Send(
                    new ValidarClientesSriMasivoQuery(clienteIds)
                );

            if (
                result.Data == null ||
                result.Data.Count == 0
            )
            {
                return NotFound(new
                {
                    message =
                        "No se pudo validar ningún cliente"
                });
            }

            return Ok(result);
        }

        // =========================================================
        // UPDATE
        // =========================================================

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            long id,
            [FromBody] ClientesRequest request)
        {
            var result =
                await _mediator.Send(
                    new UpdateClientesCommand(
                        id,
                        request
                    )
                );

            return Ok(result);
        }

        // =========================================================
        // DELETE
        // =========================================================

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result =
                await _mediator.Send(
                    new DeleteClientesCommand(id)
                );

            return Ok(result);
        }

        // =========================================================
        // BUSCAR CLIENTES
        // =========================================================

        [HttpGet("buscar")]
        public async Task<
            ActionResult<
                ApiResponse<List<ClienteSummaryResponse>>
            >
        > BuscarClientes(
            [FromQuery] string filtro)
        {
            if (string.IsNullOrWhiteSpace(filtro))
            {
                return BadRequest(
                    "Debe proporcionar un nombre o RUC como filtro."
                );
            }

            var query =
                new GetClientesByNomcliAsyncQuery(
                    filtro
                );

            var resultado =
                await _mediator.Send(query);

            return Ok(resultado);
        }

        // =========================================================
        // BUSCAR POR NOMCLI
        // =========================================================

        [HttpGet("buscar-por-nomcli")]
        public async Task<
            ActionResult<
                ApiResponse<List<ClienteSummaryResponse>>
            >
        > BuscarClientesPorNombre(
            [FromQuery] string nomcli)
        {
            if (string.IsNullOrWhiteSpace(nomcli))
            {
                return BadRequest(
                    "Debe proporcionar un nombre para buscar."
                );
            }

            var query =
                new GetClientesByNomcliAsyncQuery(
                    nomcli
                );

            var resultado =
                await _mediator.Send(query);

            return Ok(resultado);
        }

        // =========================================================
        // RESUMEN TIPO CLIENTE AÑO / MES
        // =========================================================

        [HttpGet(
            "resumen-tipo-cliente/{anio:int}/{mes:int}"
        )]
        public async Task<
            ActionResult<
                ApiResponse<
                    ResumenTipoClienteAnioMesResponse
                >
            >
        > GetResumenTipoCliente(
            int anio,
            int mes,
            CancellationToken ct)
        {
            var result =
                await _mediator.Send(
                    new GetResumenTipoClienteAnioMesQuery(
                        anio,
                        mes
                    ),
                    ct
                );

            return Ok(result);
        }

        // =========================================================
        // RESUMEN TOTAL
        // =========================================================

        [HttpGet(
            "resumen-tipo-cliente-total"
        )]
        public async Task<
            ActionResult<
                ApiResponse<
                    ResumenTipoClienteTotalResponse
                >
            >
        > GetResumenTipoClienteTotal(
            CancellationToken ct)
        {
            var result =
                await _mediator.Send(
                    new GetResumenTipoClienteTotalQuery(),
                    ct
                );

            return Ok(result);
        }

        // =========================================================
        // AFILIADAS AÑO / MES
        // =========================================================

        [HttpGet(
            "resumen-tipo-cliente-afiliadas/{anio:int}/{mes:int}"
        )]
        public async Task<
            ActionResult<
                ApiResponse<
                    ResumenTipoClienteAnioMesResponse
                >
            >
        > GetResumenTipoClienteAfiliadas(
            int anio,
            int mes,
            CancellationToken ct)
        {
            var result =
                await _mediator.Send(
                    new GetResumenTipoClienteAnioMesAfiliadasQuery(
                        anio,
                        mes
                    ),
                    ct
                );

            return Ok(result);
        }

        // =========================================================
        // AFILIADAS TOTAL
        // =========================================================

        [HttpGet(
            "resumen-tipo-cliente-total-afiliadas"
        )]
        public async Task<
            ActionResult<
                ApiResponse<
                    ResumenTipoClienteTotalResponse
                >
            >
        > GetResumenTipoClienteTotalAfiliadas(
            CancellationToken ct)
        {
            var result =
                await _mediator.Send(
                    new GetResumenTipoClienteTotalAfiliadasQuery(),
                    ct
                );

            return Ok(result);
        }

        // =========================================================
        // DESAFILIADAS AÑO / MES
        // =========================================================

        [HttpGet(
            "resumen-tipo-cliente-desafiliadas/{anio:int}/{mes:int}"
        )]
        public async Task<
            ActionResult<
                ApiResponse<
                    ResumenTipoClienteAnioMesResponse
                >
            >
        > GetResumenTipoClienteDesafiliadas(
            int anio,
            int mes,
            CancellationToken ct)
        {
            var result =
                await _mediator.Send(
                    new GetResumenTipoClienteAnioMesDesafiliadasQuery(
                        anio,
                        mes
                    ),
                    ct
                );

            return Ok(result);
        }

        // =========================================================
        // DESAFILIADAS TOTAL
        // =========================================================

        [HttpGet(
            "resumen-tipo-cliente-total-desafiliadas"
        )]
        public async Task<
            ActionResult<
                ApiResponse<
                    ResumenTipoClienteTotalResponse
                >
            >
        > GetResumenTipoClienteTotalDesafiliadas(
            CancellationToken ct)
        {
            var result =
                await _mediator.Send(
                    new GetResumenTipoClienteTotalDesafiliadasQuery(),
                    ct
                );

            return Ok(result);
        }

        // =========================================================
        // ACTUALIZAR DATOS ADICIONALES
        // =========================================================

        [HttpPut(
            "actualizar-datos-adicionales"
        )]
        public async Task<IActionResult>
            ActualizarDatosAdicionalesCliente(
                [FromBody]
                ActualizarDatosAdicionalesClienteRequest request)
        {
            var result =
                await _mediator.Send(
                    new ActualizarDatosAdicionalesClienteCommand(
                        request
                    )
                );

            return Ok(result);
        }

        // =========================================================
        // REGISTRAR AUDITORÍA
        //
        // POST:
        // /api/Clientes/auditoria-datos-adicionales
        // =========================================================

        [HttpPost(
            "auditoria-datos-adicionales"
        )]
        public async Task<IActionResult>
            RegistrarAuditoriaDatosAdicionales(
                [FromBody]
                AuditoriaDatoAdicionalClienteRequest request,
                CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message =
                            "La solicitud es obligatoria."
                    });
                }

                if (request.ClientesCodigo <= 0)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message =
                            "CLIENTES_CODIGO inválido."
                    });
                }

                // =================================================
                // VALIDAR CAMPO
                // =================================================

                var camposPermitidos =
                    new[]
                    {
                        "PREFIJO",
                        "O.COMPRA",
                        "OTROS"
                    };

                var campo =
                    (
                        request.Campo ??
                        string.Empty
                    )
                    .Trim()
                    .ToUpperInvariant();

                if (
                    !camposPermitidos.Contains(campo)
                )
                {
                    return BadRequest(new
                    {
                        success = false,
                        message =
                            "Campo de auditoría inválido."
                    });
                }

                // =================================================
                // NORMALIZAR NOMBRE
                // =================================================

                var nombreCliente =
                    string.IsNullOrWhiteSpace(
                        request.NombreCliente
                    )
                        ? null
                        : request.NombreCliente.Trim();

                // =================================================
                // INSERT AUDITORÍA
                // =================================================

                var filasInsertadas =
                    await _context.Database
                        .ExecuteSqlInterpolatedAsync(
                            $@"
                            INSERT INTO
                            SIC.AUDITORIA_DATOS_ADICIONALES_CLIENTE
                            (
                                CLIENTES_CODIGO,
                                NOMBRE_CLIENTE,
                                CAMPO,
                                VALOR_ANTERIOR,
                                VALOR_NUEVO,
                                ID_USUARIO,
                                FECHA
                            )
                            VALUES
                            (
                                {request.ClientesCodigo},
                                {nombreCliente},
                                {campo},
                                {request.ValorAnterior},
                                {request.ValorNuevo},
                                {request.IdUsuario},
                                {DateTime.Now}
                            )
                            ",
                            cancellationToken
                        );

                if (filasInsertadas <= 0)
                {
                    return StatusCode(
                        StatusCodes.Status500InternalServerError,
                        new
                        {
                            success = false,
                            message =
                                "No se pudo registrar la auditoría."
                        }
                    );
                }

                return Ok(new
                {
                    success = true,

                    message =
                        "Auditoría registrada correctamente.",

                    clientesCodigo =
                        request.ClientesCodigo,

                    nombreCliente =
                        nombreCliente,

                    campo =
                        campo,

                    valorAnterior =
                        request.ValorAnterior,

                    valorNuevo =
                        request.ValorNuevo,

                    idUsuario =
                        request.IdUsuario
                });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        success = false,

                        message =
                            "Error registrando auditoría.",

                        error =
                            ex.Message
                    }
                );
            }
        }

        // =========================================================
        // CONSULTAR AUDITORÍA
        //
        // GET:
        // /api/Clientes/auditoria-datos-adicionales
        // =========================================================

        [HttpGet(
    "auditoria-datos-adicionales"
)]
        public async Task<IActionResult>
    ObtenerAuditoriaDatosAdicionales(
        CancellationToken cancellationToken)
        {
            try
            {
                var resultado =
                    new List<
                        AuditoriaDatosAdicionalesClienteResponse
                    >();

                var connection =
                    _context.Database
                        .GetDbConnection();

                var estabaCerrada =
                    connection.State !=
                    ConnectionState.Open;

                if (estabaCerrada)
                {
                    await connection.OpenAsync(
                        cancellationToken
                    );
                }

                try
                {
                    await using var command =
                        connection.CreateCommand();

                    command.CommandText =
                        @"
                SELECT
                    A.ID_AUDITORIA,
                    A.CLIENTES_CODIGO,
                    A.NOMBRE_CLIENTE,
                    A.CAMPO,
                    A.VALOR_ANTERIOR,
                    A.VALOR_NUEVO,
                    A.ID_USUARIO,
                    A.FECHA,

                    U.NOMBRE_USUARIO AS USUARIO

                FROM
                    SIC.AUDITORIA_DATOS_ADICIONALES_CLIENTE A

                LEFT JOIN
                    SEGURIDADES.USUARIOS U
                        ON U.ID_USUARIO =
                           A.ID_USUARIO

                ORDER BY
                    A.ID_AUDITORIA DESC
                ";

                    await using var reader =
                        await command
                            .ExecuteReaderAsync(
                                cancellationToken
                            );

                    while (
                        await reader.ReadAsync(
                            cancellationToken
                        )
                    )
                    {
                        var item =
                            new AuditoriaDatosAdicionalesClienteResponse
                            {
                                IdAuditoria =
                                    Convert.ToInt64(
                                        reader[
                                            "ID_AUDITORIA"
                                        ]
                                    ),

                                ClientesCodigo =
                                    Convert.ToInt32(
                                        reader[
                                            "CLIENTES_CODIGO"
                                        ]
                                    ),

                                NombreCliente =
                                    reader[
                                        "NOMBRE_CLIENTE"
                                    ] == DBNull.Value
                                        ? null
                                        : reader[
                                            "NOMBRE_CLIENTE"
                                        ].ToString(),

                                Campo =
                                    reader[
                                        "CAMPO"
                                    ] == DBNull.Value
                                        ? null
                                        : reader[
                                            "CAMPO"
                                        ].ToString(),

                                ValorAnterior =
                                    reader[
                                        "VALOR_ANTERIOR"
                                    ] != DBNull.Value &&
                                    Convert.ToBoolean(
                                        reader[
                                            "VALOR_ANTERIOR"
                                        ]
                                    ),

                                ValorNuevo =
                                    reader[
                                        "VALOR_NUEVO"
                                    ] != DBNull.Value &&
                                    Convert.ToBoolean(
                                        reader[
                                            "VALOR_NUEVO"
                                        ]
                                    ),

                                IdUsuario =
                                    reader[
                                        "ID_USUARIO"
                                    ] == DBNull.Value
                                        ? null
                                        : Convert.ToInt64(
                                            reader[
                                                "ID_USUARIO"
                                            ]
                                        ),

                                Fecha =
                                    reader[
                                        "FECHA"
                                    ] == DBNull.Value
                                        ? DateTime.MinValue
                                        : Convert.ToDateTime(
                                            reader[
                                                "FECHA"
                                            ]
                                        ),

                                Usuario =
                                    reader[
                                        "USUARIO"
                                    ] == DBNull.Value
                                        ? null
                                        : reader[
                                            "USUARIO"
                                        ].ToString()
                            };

                        resultado.Add(
                            item
                        );
                    }
                }
                finally
                {
                    if (
                        estabaCerrada &&
                        connection.State ==
                        ConnectionState.Open
                    )
                    {
                        await connection.CloseAsync();
                    }
                }

                return Ok(new
                {
                    success = true,

                    count =
                        resultado.Count,

                    data =
                        resultado
                });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        success = false,

                        message =
                            "Error consultando la auditoría.",

                        error =
                            ex.Message
                    }
                );
            }
        }
    }
}