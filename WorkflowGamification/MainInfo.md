Проект  состоит из 2 частей:
Frontend реализован с помощью react ts;
Backend рализован с помощью Asp net core и состоит из:
1) Сервиса аутентификации (UserAutheticationService), который создает, аутентифицирует и создает пользователя
2) Сервиса, реализующего рабочее пространство пользоваеля (
3) Сервиса, реализующего магазин компании
4) Сервиса, отвечающего за кошелек пользователя
5) Брокер сообщений, реализующий паттерн Saga с помощью фреймворка mass transit, с помощью которого простые запросы разворачиваются с помощью конечных автоматов в сложные
6) Api шлюза, который позволяет клиенту обращаться через него к необходимым сервисам и брокеру

для запуска контейнеров в случае если visual studio ну запускает их, можно либо запустить проекты локально все,
либо docker-compose run {сервис из docer-compose.uml} для всех проектов, которые не зависят от баз данных и  docker-compose run {сервис из docer-compose.uml}  dotnet ef database update