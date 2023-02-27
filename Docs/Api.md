# Buber Dinner API

## Contents

- [Buber Dinner API](#buber-dinner-api)
    - [Contents](#contents)
    - [Auth](#auth)
        - [Register](#register)
            - [Register Request](#register-request)
            - [Register Response](#register-response)
        - [Login](#login)
            - [Login Request](#login-request)
            - [Login Response](#login-response)

<hr>

## Auth

### Register

```js
POST {{host}}/auth/register
```

#### Register Request

```json
{
  "firstName": "Abdel",
  "lastName": "Raoof",
  "email": "aro@gmail.com",
  "password": "Pa$s01@3"
}
```
#### Register Response
```json
200 OK
```
```json
{
  "id":"c7566a84-89e5-4fb3-8a63-c0f89cae3d9a",  
  "firstName": "Abdel",
  "lastName": "Raoof",
  "email": "aro@gmail.com",
  "token": "a1c364e2f405"
}
```
### Login
```js
POST {{host}}/auth/login
```
#### Login Request
```json
{
  "email": "aro@gmail.com",
  "password": "Pa$s01@3"
}
```
#### Login Response
```json
200 OK
```
```json
{
  "id":"c7566a84-89e5-4fb3-8a63-c0f89cae3d9a",  
  "firstName": "Abdel",
  "lastName": "Raoof",
  "email": "aro@gmail.com",
  "token": "a1c364e2f405"
}