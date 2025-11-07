using ItCompany1135.CQRS.DTO;
using ItCompany1135.DB;
using MyMediator.Interfaces;

namespace ItCompany1135.CQRS.Commands
{
    public class GetTypesWarrantyMonthsCommand : IRequest<List<DeviceTypeDTO>>
    {
        public int NMonths { get; set; }
        public class GetTypesWarrantyMonthsCommandHandler : IRequestHandler<GetTypesWarrantyMonthsCommand, List<DeviceTypeDTO>>
        {
            public ItCompany1135Context db { get; set; }
            public GetTypesWarrantyMonthsCommandHandler(ItCompany1135Context db)
            {
                this.db = db;
            }
            public async Task<List<DeviceTypeDTO>> HandleAsync(GetTypesWarrantyMonthsCommand request, CancellationToken ct = default)
            {
                return db.DeviceTypes.Where(s => (DateTime.Now - s.CreatedAt). == request.NMonths).Select(s => new DeviceTypeDTO
                {
                    Category = s.Category,
                    CreatedAt = s.CreatedAt,
                    WarrantyMonths = s.WarrantyMonths,
                    CreatedBy = s.CreatedBy,
                    DeletedAt = s.DeletedAt,
                    DeletedBy = s.DeletedBy,
                    Id = s.Id,
                    IsDeleted = s.IsDeleted,
                    ModifiedAt = s.ModifiedAt,
                    ModifiedBy = s.ModifiedBy,
                    Name = s.Name
                }).ToList();
            }
        }
    }
}
