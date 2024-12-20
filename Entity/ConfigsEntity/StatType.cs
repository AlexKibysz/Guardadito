using Guardadito.Entity.Contracts;

namespace Guardadito.Entity;
public class StatType : BaseEntity, IConfigurationEntity
{
    public string Name { get; set; }

    /*
     BalanceMensual,
     GastosPorCategoria,
     TendenciaAhorro,
     ProyeccionGastos
     */
}