# ASP.NET-Timesheets
ASP.NET Core WebApi Timesheets

![Time](/Timesheets/TimeIsCash.png)

## Сервис учета рабочего времени

Предназначен для учета затраченного рабочего времени по контрактам и формирования счетов-фактур на основании ведомостей.
Доступ к сервису предоставляется только для авторизованных пользователей.
Для хранения данных использована БД PostgreSQL вместе с Entity Framework.

### Функционал:
- Создание, удаление, обновление, получение экземпляра или списка экземпляров объектов из БД.
- Управление ролями пользователей с целью разграничения прав доступа. 
- Авторизация пользователей.
- Формирование счетов-фактур по контракту за период.
- Учет ведомостей, по которым выставлены счета-фактуры, для исключения повторного учета.
Объекты: пользователи, сотрудники, сервисы, клиенты, контракты, ведомости, счета-фактуры.
Для опробования сервиса реализован [Swagger]. 

<img src="/Timesheets/swagger_Timesheets.png" alt="Swagger" align="middle" width="700"/>

### Алгоритм работы:

По средствам HTTP-запросов от имени авторизованных пользователей осуществляется создание, обновление, удаление или получение объектов в соответствии с правами пользователя.
Назначение каждого запроса и возможные варианты ответа сервера с трактовкой приведены в Swagger.

Структура БД:

<img src="/Timesheets/dBTimesheetsGraph.jpg" alt="dBGraph" width="1000"/>

Стрелками показаны связи в виде внешних ключей _FK - foreign key_.
В качестве первичных ключей _PK - primary key_ использован статистически уникальный 128-битный идентификатор - _GUID_ ( в таблицах БД uuid).

Описание таблиц БД:
- **users** - пользователи с ролями и паролями (хранятся в хэшированном виде); 
- **employees**  - сотрудники и их должности;
- **services** - сервисы компании;
- **clients** - клиенты компании;
- **contracts** - контракты компании;
- **sheets** - ведомости оказанных услуг;
- **invoices** - счета-фактуры за оказанные услуги.

Для управления пользователями и изменения, удаления любого экземпляра объекта  необходима роль "manager" или "admin".

Клиенту компании назначается пользователь с правами на просмотр/получение счетов-фактур по id.

При формировании счет-фактуры за период учитываются sheets за период со свойством _IsApproved_: _false_. После формирования и расчета стоимости оказанных услуг в **sheets** меняются свойства _IsApproved_ на _true_,  _ApprovedDate_ на текущую дату и _FK InvoiceId_ на соответствующий _uuid_ (_GUID_). 

#### Прочее:

Для настройки доступа к новой БД необходимо в файле appsettings.json указать _User Id, Password, Server, Port, Database_.
При необходимости создать миграцию или использовать существующую.
Затем выполнить обновление базы данных. 

При реализации проекта написаны 5 Unit-tests для агрегатов Invoice и Sheets.
