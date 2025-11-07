using ItCompany1135.CQRS.DTO;
using ItCompany1135.DB;
using MyMediator.Interfaces;
using MyMediator.Types;
using System.Security.Claims;

namespace ItCompany1135.CQRS.Commands
{
    public class CreateDeviceTypeCommand : IRequest
    {
        public Claim Claim { get; set; }
        public DeviceTypeDTO DeviceType { get; set; }
        public class CreateDeviceTypeCommandHandler : IRequestHandler<CreateDeviceTypeCommand, Unit>
        {
            public ItCompany1135Context db { get; set; }
            public CreateDeviceTypeCommandHandler(ItCompany1135Context db)
            {
                this.db = db;
            }

            public async Task<Unit> HandleAsync(CreateDeviceTypeCommand request, CancellationToken ct = default)
            {
                db.DeviceTypes.Add(new DeviceType()
                {
                    Category = request.DeviceType.Category,
                    CreatedAt = request.DeviceType.CreatedAt,
                    CreatedBy = request.DeviceType.CreatedBy,
                    DeletedAt = request.DeviceType.DeletedAt,
                    DeletedBy = request.DeviceType.DeletedBy,
                    IsDeleted = request.DeviceType.IsDeleted,
                    ModifiedAt = request.DeviceType.ModifiedAt,
                    ModifiedBy = request.DeviceType.ModifiedBy,
                    Name = request.DeviceType.Name,
                    WarrantyMonths = request.DeviceType.WarrantyMonths
                });
                db.SaveChanges();
                return Unit.Value;
            }
        }
    }
}
