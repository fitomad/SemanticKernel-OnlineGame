
internal record Settings
{
    internal string Model { get; set; }
    internal string ApiKey { get; set; }
    internal string? OrganizationId { get; set;}

    internal Settings()
    {
        Model = string.Empty;
        ApiKey = string.Empty;
        OrganizationId = null;
    }
}