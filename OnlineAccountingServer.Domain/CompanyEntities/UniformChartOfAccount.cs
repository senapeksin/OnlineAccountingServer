using OnlineAccountingServer.Domain.Abstractions;

namespace OnlineAccountingServer.Domain.CompanyEntities
{
    public sealed class UniformChartOfAccount : BaseEntity
    {
        // Uniform Chart Of Account : Hesap Planı
        public string Code { get; set; }
        public string Name { get; set; }
        public char Type { get; set; } // Ana Grup, Alt Grup (Grup), Muavin 
    }
}
