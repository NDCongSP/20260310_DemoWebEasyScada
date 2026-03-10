# Demo Blazor Realtime

Project Blazor (MudBlazor) + .NET API Core, Clean Architecture. Code First với Entity Framework, 2 bảng Config và Realtime (nhiệt độ theo khu vực).

## Cấu trúc

- **Domain**: Entities `RevoConfig`, `RealtimeData`, models JSON (LocationConfigItem, TemperaturePoint).
- **Application**: DTOs, interfaces `IRevoConfigService`, `IRealtimeDataService`.
- **Infrastructure**: EF Core, DbContext, services, migrations, `DbInitializer` (seed khi chạy API).
- **API**: ASP.NET Core Web API, controllers Config và Realtime. Khi chạy API sẽ áp dụng migration và seed data nếu cần.
- **UI**: Blazor Server, MudBlazor. Trang **Cấu hình** (config) và trang **Realtime** (reload theo timer, cấu hình thời gian reload trong config).

## Chạy

1. **API** (cần chạy trước):

   ```bash
   cd src/API
   dotnet run
   ```

   Lần đầu sẽ tạo DB (LocalDB mặc định), áp dụng migration và seed: 1 config với 3 địa điểm (2 publish), 2 bản ghi realtime.

2. **UI**:

   ```bash
   cd src/UI
   dotnet run
   ```

   Mở trình duyệt, vào **Cấu hình** để sửa thời gian reload (giây) và bật/tắt Publish địa điểm. Vào **Realtime** để xem nhiệt độ theo thời gian thực (reload mỗi X giây theo config), card hiển thị tên địa điểm, nhiệt độ, mũi tên tăng/giảm so với lần đo trước.

## Cấu hình

- **API**: `src/API/appsettings.json` — `ConnectionStrings:DefaultConnection` (mặc định LocalDB).
- **UI**: `src/UI/appsettings.json` hoặc `appsettings.Development.json` — `ApiBaseUrl` trỏ tới API (mặc định `http://localhost:5089`).

## Bảng

- **RevoConfigs**: Id, C000 (JSON danh sách địa điểm: id, name, publish), ReloadIntervalSeconds, Actived, CreatedAt.
- **RealtimeData**: Id, C00 (JSON nhiệt độ theo locationId), CreatedAt. Trang Realtime lấy dòng mới nhất.
