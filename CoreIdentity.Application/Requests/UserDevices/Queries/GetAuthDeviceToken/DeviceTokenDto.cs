namespace CoreIdentity.Application.Requests.UserDevices.Queries.GetAuthDeviceToken;

public class DeviceTokenDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Token { get; set; }
    public string ClientId { get; set; }
    public string Type { get; set; }
    public long ExpirationDate { get; set; }
}