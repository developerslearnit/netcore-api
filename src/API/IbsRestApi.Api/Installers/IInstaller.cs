﻿namespace IbsRestApi.Api.Installers;

public interface IInstaller
{
    void InstallServices(WebApplicationBuilder builder);
}
