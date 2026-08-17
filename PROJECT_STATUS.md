# Project Status

## Verified

- Visual Studio 2026 installed.
- Windows Forms App (.NET Framework) project created.
- .NET Framework 4.8.
- Empty Form execution: confirmed by user-provided baseline; not rerun during this bootstrap.

## Backend Contract

Confirmed endpoint:

- `GET http://localhost:8080/api/lots`
  - Response fields: `lotId`, `productCode`, `processStep`, `status`, `updatedAt`.

Planned endpoints (not implemented):

- `GET /api/lots/{lotId}/inspections`
- `POST /api/lots/{lotId}/analysis-tasks` with `{ "reason": "..." }`

## Next

- LOT list UI
- Inspection result UI
- Analysis request UI
- Backend HTTP integration

## Not Verified Yet

- Backend connection from WinForms
- HTTP error handling
- Analysis end-to-end flow
