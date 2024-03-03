namespace CoreIdentity.Application.Requests.UserDevices.Commands.GetUserDeviceToken;

public class UserDeviceTokenDto
{
    public Guid DeviceTokenId { get; set; }
    public string Key { get; set; }
    public string DeviceName { get; set; }
    public string DeviceModel { get; set; }
}
