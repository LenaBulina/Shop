## Online Shop

Учебный проект интернет-магазина, созданный для тренировки навыков разработки **full-stack приложений** с использованием **Angular** и **ASP.NET Core**.
Проект включает backend API, frontend приложение и unit-тесты для проверки бизнес-логики и работы базы данных.
 
 ## Описание проекта

Online Shop — это демонстрационное веб-приложение интернет-магазина.
Проект предназначен для практики следующих технологий:

* Angular (frontend)
* ASP.NET Core Web API (backend)
* Entity Framework Core (работа с базой данных)
* NUnit (unit-тестирование)

## Frontend

Frontend часть приложения разработана на Angular и основана на учебном проекте из курса на Udemy (https://www.udemy.com/course/angular-9/).
В оригинальном курсе в качестве backend использовалась база данных Firebase.
В данном проекте Firebase был заменён на собственный backend, реализованный на ASP.NET Core и Entity Framework Core.
Frontend был адаптирован для работы с REST API.

## Backend
Серверная часть приложения разработана самостоятельно.
Backend реализован с использованием:
- ASP.NET Core Web API
- Entity Framework Core
- NUnit для unit-тестирования
Сервер предоставляет REST API для работы с товарами, заказами и клиентами.



## Структура проекта

MyShop 
│ 
├── MyShop.Backend 
  │ ├── MyShop.Backend            # ASP.NET Core Web API 
  │ └── MyShop.Backend.Tests      # Unit tests (NUnit) 
│ 
└── MyShop.Frontend               # Angular web application

## Запуск Backend

Перейти в папку backend проекта и открыть командную строку.
Запустить сервер:
dotnet run
После запуска сервер будет доступен по адресам:
http://localhost:5000
https://localhost:5001

## Запуск Frontend (Angular)
В VS Code открыть папку MyShop.Frontend.
Установить зависимости:
npm install
Запустить приложение:
ng serve

После запуска Angular приложение будет доступно по адресу:
http://localhost:4200

Frontend взаимодействует с backend API через HTTP-запросы.

## Запуск тестов

Unit-тесты написаны с использованием NUnit.
Для запуска тестов выполнить:
dotnet test

Тесты проверяют:
* корректность моделей
* работу Entity Framework Core
* связи между сущностями
* базовую бизнес-логику

## Основные сущности системы

Проект содержит следующие основные модели:

* Product — товар магазина
* Order — заказ пользователя
* Customer — клиент

Между Product и Order реализована связь **Many-to-Many**,
а между Customer и Order — **One-to-Many**.

## Цель проекта

Проект создан для:

* практики разработки REST API
* работы с Entity Framework Core
* написания unit-тестов
* разработки frontend на Angular
* понимания взаимодействия frontend и backend

## Автор
Учебный проект для практики Full-Stack разработки.

## TO DO
* написать юнит тесты для фронтенд части
* обновить пакеты
* обновить верстку и стили


