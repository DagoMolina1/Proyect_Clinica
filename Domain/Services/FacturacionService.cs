using System;
using System.Collections.Generic;
using System.Linq;
using ClinicaIPS_U.Domain.Entities;
using ClinicaIPS_U.Domain.Interfaces;

namespace ClinicaIPS_U.Domain.Services {
    public class FacturacionService {
        private const decimal ValorCopago = 50000m;
        private const decimal TopeCopagoAnual = 1000000m;

        private readonly IFacturacionRepository _facturacionRepository;
        private readonly PacienteService _pacienteService;
        private readonly OrdenService _ordenService;
        private readonly UsuarioService _usuarioService;

        public FacturacionService(
            IFacturacionRepository facturacionRepository,
            PacienteService pacienteService,
            OrdenService ordenService,
            UsuarioService usuarioService) {
            _facturacionRepository = facturacionRepository;
            _pacienteService = pacienteService;
            _ordenService = ordenService;
            _usuarioService = usuarioService;
        }

        public FacturaDetalle GenerarFactura(int idOrden, bool registrarFactura = true) {
            var orden = _ordenService.BuscarOrden(idOrden) ?? throw new ArgumentException("La orden indicada no existe.");
            var paciente = _pacienteService.BuscarPorId(orden.IdPaciente) ?? throw new ArgumentException("El paciente de la orden no existe.");
            var medico = _usuarioService.BuscarPorId(orden.IdMedico);

            var medicamentos = _ordenService.ListarMedicamentosPorOrden(idOrden);
            var procedimientos = _ordenService.ListarProcedimientosPorOrden(idOrden);
            var ayudas = _ordenService.ListarAyudasPorOrden(idOrden);

            decimal totalServicios = 0m;
            totalServicios += medicamentos.Sum(m => m.Subtotal);
            totalServicios += procedimientos.Sum(p => p.Subtotal);
            totalServicios += ayudas.Sum(a => a.Subtotal);

            var seguro = paciente.SeguroMedico;
            bool polizaActiva = seguro != null && seguro.Estado && seguro.Vigencia >= DateTime.Today;
            decimal copago = 0m;
            decimal valorPaciente;
            decimal valorAseguradora;

            if (polizaActiva) {
                var facturasAnio = _facturacionRepository
                    .GetAll()
                    .Where(f => f.IdPaciente == paciente.IdPaciente && f.Fecha.Year == DateTime.Today.Year);
                decimal copagoAcumulado = facturasAnio.Sum(f => f.Copago);

                if (copagoAcumulado < TopeCopagoAnual) {
                    copago = Math.Min(ValorCopago, totalServicios);
                    if (copagoAcumulado + copago > TopeCopagoAnual) {
                        copago = Math.Max(0, TopeCopagoAnual - copagoAcumulado);
                    }
                }

                valorPaciente = copago;
                valorAseguradora = totalServicios - copago;
            } else {
                valorPaciente = totalServicios;
                valorAseguradora = 0m;
            }

            if (registrarFactura) {
                var factura = new Facturacion {
                    Fecha = DateTime.Now,
                    Copago = copago,
                    Total = totalServicios,
                    IdPaciente = paciente.IdPaciente,
                    IdMedico = orden.IdMedico,
                    IdSeguro = seguro?.IdSeguro
                };
                _facturacionRepository.Add(factura);
            }

            return new FacturaDetalle {
                NombrePaciente = paciente.NombreCompleto,
                CedulaPaciente = paciente.Cedula.Value,
                EdadPaciente = CalcularEdad(paciente.FechaNacimiento),
                NombreMedicoTratante = medico?.NombreCompleto ?? "Sin asignar",
                NombreAseguradora = seguro?.NombreCompania ?? "Sin seguro",
                NumeroPoliza = seguro?.NumeroPoliza ?? string.Empty,
                PolizaActiva = polizaActiva,
                DiasVigencia = seguro != null ? Math.Max(0, (int)(seguro.Vigencia - DateTime.Today).TotalDays) : 0,
                FechaFinPoliza = seguro?.Vigencia ?? DateTime.Today,
                Copago = copago,
                TotalServicios = totalServicios,
                ValorCoberturaAseguradora = valorAseguradora,
                ValorPaciente = valorPaciente,
                Medicamentos = medicamentos,
                Procedimientos = procedimientos,
                AyudasDiagnosticas = ayudas
            };
        }

        public void Registrar(Facturacion factura) => _facturacionRepository.Add(factura);

        public void Actualizar(Facturacion factura) => _facturacionRepository.Update(factura);

        public void Eliminar(int idFactura) => _facturacionRepository.Delete(idFactura);

        public Facturacion BuscarPorId(int idFactura) => _facturacionRepository.GetById(idFactura);

        public List<Facturacion> Listar() => _facturacionRepository.GetAll();

        private static int CalcularEdad(DateTime fechaNacimiento) {
            var hoy = DateTime.Today;
            var edad = hoy.Year - fechaNacimiento.Year;
            if (fechaNacimiento.Date > hoy.AddYears(-edad)) {
                edad--;
            }
            return edad;
        }
    }
}
