using ClinicaIPS_U.Domain.Services;
using ClinicaIPS_U.Infrastructure.Data;

namespace ClinicaIPS_U.Infrastructure.Configuration
{
    /// <summary>
    /// Contenedor básico de servicios para la aplicación WinForms.
    /// </summary>
    public class AppServiceProvider
    {
        public UsuarioService Usuarios { get; }
        public PacienteService Pacientes { get; }
        public MedicamentoService Medicamentos { get; }
        public ProcedimientoService Procedimientos { get; }
        public AyudaDiagnosticaService AyudasDiagnosticas { get; }
        public OrdenService Ordenes { get; }
        public FacturacionService Facturacion { get; }

        public AppServiceProvider()
        {
            var usuarioRepository = new UsuarioRepository();
            var pacienteRepository = new PacienteRepository();
            var medicamentoRepository = new MedicamentoRepository();
            var procedimientoRepository = new ProcedimientoRepository();
            var ayudaRepository = new AyudaDiagnosticaRepository();
            var ordenRepository = new OrdenRepository();
            var ordenMedicamentoRepository = new OrdenMedicamentoRepository();
            var ordenProcedimientoRepository = new OrdenProcedimientoRepository();
            var ordenAyudaRepository = new OrdenAyudaDiagnosticaRepository();
            var facturacionRepository = new FacturacionRepository();

            Usuarios = new UsuarioService(usuarioRepository);
            Pacientes = new PacienteService(pacienteRepository);
            Medicamentos = new MedicamentoService(medicamentoRepository);
            Procedimientos = new ProcedimientoService(procedimientoRepository);
            AyudasDiagnosticas = new AyudaDiagnosticaService(ayudaRepository);
            Ordenes = new OrdenService(
                ordenRepository,
                ordenMedicamentoRepository,
                ordenProcedimientoRepository,
                ordenAyudaRepository);
            Facturacion = new FacturacionService(facturacionRepository, Pacientes, Ordenes, Usuarios);
        }
    }
}
