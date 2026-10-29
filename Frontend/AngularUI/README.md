# AngularUI

This project was generated using [Angular CLI](https://github.com/angular/angular-cli) version 22.2.5.

## Application overview

The app uses a main page with a menu and route-based forms:

- Proposal Editing (`/proposal-editing`)
- Masterdata Items (`/masterdata/items`)
- Masterdata Warehouses (`/masterdata/warehouses`)
- Settings (`/settings`)
- About (`/about`)
- Contact (`/contact`)

## API configuration

The frontend base URL is configured in `src/environments/environment.ts`:

- `apiBaseUrl: ''` (relative paths such as `/api/...`)

During local development, Angular uses [proxy.conf.json](./proxy.conf.json) so `/api/*` requests are proxied to:

- `https://localhost:7283`

Implemented backend calls:

- `GET /api/items`
- `GET /api/Warehouses`
- `GET /api/Proposals`

## Development server

To start a local development server, run:

```bash
ng serve
```

Once the server is running, open your browser and navigate to `http://localhost:4200/`. The application will automatically reload whenever you modify any of the source files.

## Code scaffolding

Angular CLI includes powerful code scaffolding tools. To generate a new component, run:

```bash
ng generate component component-name
```

For a complete list of available schematics (such as `components`, `directives`, or `pipes`), run:

```bash
ng generate --help
```

## Building

To build the project run:

```bash
ng build
```

This will compile your project and store the build artifacts in the `dist/` directory. By default, the production build optimizes your application for performance and speed.

## Running unit tests

To execute unit tests with the [Vitest](https://vitest.dev/) test runner, use the following command:

```bash
ng test
```

## Running end-to-end tests

For end-to-end (e2e) testing, run:

```bash
ng e2e
```

Angular CLI does not come with an end-to-end testing framework by default. You can choose one that suits your needs.

## Additional Resources

For more information on using the Angular CLI, including detailed command references, visit the [Angular CLI Overview and Command Reference](https://angular.dev/tools/cli) page.
