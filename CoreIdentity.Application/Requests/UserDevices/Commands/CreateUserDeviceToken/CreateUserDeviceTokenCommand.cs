using MediatR;

namespace CoreIdentity.Application.Requests.UserDevices.Commands.GetUserDeviceToken;

public class CreateUserDeviceTokenCommand : IRequest<GetUserDeviceTokenDto>
{
    public Guid UserId { get; set; }
    public string DeviceName { get; set; }
    public string DeviceModel { get; set; }
}
