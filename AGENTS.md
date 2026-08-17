# FabInspectionClient Agent Guide

- This project is a synthetic manufacturing inspection WinForms client.
- Use Visual Studio 2026, C#, and .NET Framework 4.8.
- Prefer built-in WinForms controls. Do not add external UI frameworks or DevExpress.
- Use HTTP/JSON for backend communication, `HttpClient`, and `async`/`await`; never block the UI thread.
- Keep the API base URL isolated in one location.
- Never store secrets in the repository.
- Build after every functional change.
- Do not aggressively rewrite Designer code in ways that break Visual Studio Designer compatibility.
- Do not add unnecessary architecture or frameworks.
- Do not push without user approval.
- Do not record unverified work as successful.
