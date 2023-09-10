Установка проекта в контейнере Docker

Откройте PowerShell
Перейдите в корневую папку проекта, где лежит файл docker-compose.yml

Выполнить команду

docker-compose up 
запустить миграцию EF для Rider

dotnet restore
dotnet ef
dotnet ef migrations add Drinks --project VendingMachine
dotnet ef database update Drinks --project VendingMachine

чтобы удалить миграцию:
dotnet ef migrations remove --project VendingMachine

В файле appsettings.json пропишите путь к файлу для сохранения картинок

В базе данных создайте монеты 1,2,5,10 и напитки 

запустите проект VendingMachine
Запустится Swagger 
В методе User введите депозит монет 
На данный момент нет проверки на правильность монет 

в базе данных увеличится количество введенных монет, также уменьшится количество напитков 