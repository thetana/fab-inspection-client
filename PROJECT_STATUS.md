# 프로젝트 상태

## 확인됨

- Visual Studio 2026이 설치되어 있습니다.
- Windows Forms App (.NET Framework) 프로젝트가 생성되어 있습니다.
- .NET Framework 4.8을 사용합니다.
- 빈 Form 실행: 사용자가 제공한 기준에서 확인되었으며, 이번 bootstrap에서는 다시 실행하지 않았습니다.

## Backend 계약

확정된 endpoint:

- `GET http://localhost:8080/api/lots`
  - 응답 필드: `lotId`, `productCode`, `processStep`, `status`, `updatedAt`

예정된 endpoint(미구현):

- `GET /api/lots/{lotId}/inspections`
- `POST /api/lots/{lotId}/analysis-tasks` 요청 본문: `{ "reason": "..." }`

## 다음 작업

- LOT 목록 UI
- Inspection result UI
- Analysis request UI
- Backend HTTP integration

## 아직 확인되지 않음

- WinForms에서의 Backend 연결
- HTTP error handling
- Analysis end-to-end 흐름
