﻿namespace IbsRestApi.Entities.Secure;

public partial class UserApplication
{
    public int IdUserApplication { get; set; }
    public Guid UserId { get; set; }
    public string IdApplication { get; set; } = null!;
}
