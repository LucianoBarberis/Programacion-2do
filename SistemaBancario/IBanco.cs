using SistemaBancario.Clases;

namespace SistemaBancario
{
    public interface IBanco
    {
        void AgregarCuenta(CuentaBancaria cuenta);
        IEnumerable<CuentaBancaria> ListarCuentas();
        CuentaBancaria ObtenerCuenta(int numeroCuenta);
    }
}