# FabInspectionClient 작업 지침

- 이 프로젝트는 합성 제조 검사 WinForms client입니다.
- Visual Studio 2026, C#, .NET Framework 4.8을 사용합니다.
- 기본 WinForms controls를 우선하며, 외부 UI framework와 DevExpress를 추가하지 않습니다.
- backend 통신에는 HTTP/JSON, `HttpClient`, `async`/`await`를 사용하며 UI thread를 block하지 않습니다.
- API base URL은 한 곳에 격리합니다.
- repository에 secret을 저장하지 않습니다.
- 기능을 변경한 뒤에는 반드시 build합니다.
- Visual Studio Designer 호환성을 깨는 무리한 Designer code 재작성을 하지 않습니다.
- 불필요한 architecture나 framework를 추가하지 않습니다.
- 사용자 승인 없이 push하지 않습니다.
- 검증하지 않은 작업을 성공으로 기록하지 않습니다.
- 사용자에게 하는 작업 보고와 프로젝트 설명 문서는 한국어로 작성합니다.
- 코드 식별자, API 경로, DB 객체명, 기술 고유명사는 표준 영어 표기를 유지합니다.
- 필요한 코드 주석은 한국어로 작성할 수 있으나 자명한 코드에 불필요한 주석을 추가하지 않습니다.
