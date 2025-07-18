FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["src/EmployeeLeaveManagementSystem.Web.Host/EmployeeLeaveManagementSystem.Web.Host.csproj", "src/EmployeeLeaveManagementSystem.Web.Host/"]
COPY ["src/EmployeeLeaveManagementSystem.Web.Core/EmployeeLeaveManagementSystem.Web.Core.csproj", "src/EmployeeLeaveManagementSystem.Web.Core/"]
COPY ["src/EmployeeLeaveManagementSystem.Application/EmployeeLeaveManagementSystem.Application.csproj", "src/EmployeeLeaveManagementSystem.Application/"]
COPY ["src/EmployeeLeaveManagementSystem.Core/EmployeeLeaveManagementSystem.Core.csproj", "src/EmployeeLeaveManagementSystem.Core/"]
COPY ["src/EmployeeLeaveManagementSystem.EntityFrameworkCore/EmployeeLeaveManagementSystem.EntityFrameworkCore.csproj", "src/EmployeeLeaveManagementSystem.EntityFrameworkCore/"]
WORKDIR "/src/src/EmployeeLeaveManagementSystem.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/EmployeeLeaveManagementSystem.Web.Host", "src/EmployeeLeaveManagementSystem.Web.Host"]
COPY ["src/EmployeeLeaveManagementSystem.Web.Core", "src/EmployeeLeaveManagementSystem.Web.Core"]
COPY ["src/EmployeeLeaveManagementSystem.Application", "src/EmployeeLeaveManagementSystem.Application"]
COPY ["src/EmployeeLeaveManagementSystem.Core", "src/EmployeeLeaveManagementSystem.Core"]
COPY ["src/EmployeeLeaveManagementSystem.EntityFrameworkCore", "src/EmployeeLeaveManagementSystem.EntityFrameworkCore"]
WORKDIR "/src/src/EmployeeLeaveManagementSystem.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "EmployeeLeaveManagementSystem.Web.Host.dll"]
