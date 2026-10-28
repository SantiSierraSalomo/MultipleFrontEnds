# Error handling contract

The API uses centralized exception handling and returns RFC7807 `application/problem+json` responses.

## Response shape

All unhandled exceptions return `ProblemDetails` with:
- `type`
- `title`
- `status`
- `detail` (generic and non-sensitive)
- `instance`
- `traceId` (inside `extensions`)

Internal exception details are not returned to clients. Full exception details are logged server-side.

## Exception mappings

- `DomainNotFoundException` / `KeyNotFoundException` -> `404 Not Found`
- `DomainValidationException` / `ArgumentException` -> `400 Bad Request`
- `DomainConflictException` / `InvalidOperationException` -> `409 Conflict`
- Any other exception -> `500 Internal Server Error`

## Validation endpoints

`ExceptionController` provides test endpoints:
- `GET /api/Exception/not-found`
- `GET /api/Exception/validation`
- `GET /api/Exception/conflict`
- `GET /api/Exception/unexpected`
