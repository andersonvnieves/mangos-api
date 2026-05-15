
![Logo](https://mangos-assets.s3.sa-east-1.amazonaws.com/mangos.png)


Mangos is a personal finance web application developed as a side project to study and experiment with modern full stack, serverless architecture. It helps users track income, expenses, investments, and financial goals through a clean and responsive interface.



## 
[![GPLv3 License](https://img.shields.io/badge/License-GPL%20v3-yellow.svg)](https://opensource.org/licenses/)

## Requirements

- Node.js (>=20)
- .NET 8 SDK
- AWS CLI configured



## Environment variables

To run this project, you will need the following environment variables on your .env file

`VITE_API_GATEWAY_ENDPOINT`

`VITE_COGNITO_AUTHORITY`

`VITE_COGNITO_DOMAIN`

`VITE_COGNITO_LOGOUT_URI`

`VITE_COGNITO_POST_LOGOUT_REDIRECT_URI`

`VITE_COGNITO_REDIRECT_URI`

`VITE_COGNITO_RESPONSE_TYPE`

`VITE_COGNITO_SCOPE`
## Run locally

Clone repo

```bash
  git clone https://github.com/andersonvnieves/mangos.git
```

Navigate to project's directory

```bash
  cd mangos/frontend
```

Install dependencies

```bash
  npm install
```

Run server

```bash
  npm run dev
```

