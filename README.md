# Data Generator
Data generator allows you to create many objects with one or more fields, containing randomly generated data, depending on selected data type and all of available constraints.

At the end of the preparation of the generated object structure, you can select the type of object representation (JSON or XML). After that, the object is available for generation.

## Getting Started
These instructions will help you to get a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites
You must install this software to run the application:
- .Net Core 2.2 (Runtime + SDK). [Download](https://dotnet.microsoft.com/download/visual-studio-sdks)
- Erlang OTP 22.0 or older. [Download](https://www.erlang.org/downloads)
- Redis 3.2.100 or older. [[Download](https://github.com/MicrosoftArchive/redis/releases)] [[Installation Guide](https://redislabs.com/blog/redis-on-windows-8-1-and-previous-versions)]
- RabbitMQ Server 3.7.16 or older. [[Download](https://www.rabbitmq.com/download.html)] [[Installation Guide](https://www.rabbitmq.com/install-windows-manual.html)]
- PostgreSQL 11.3.4 or older. [[Download](https://www.enterprisedb.com/downloads/postgres-postgresql-downloads)] [[Installation Guide](http://www.postgresqltutorial.com/install-postgresql/)]
- MongoDB 4.0.10 or older. [[Download](https://www.mongodb.com/download-center/community)] [[Installation Guide](https://medium.com/@LondonAppBrewery/how-to-download-install-mongodb-on-windows-4ee4b3493514)]

### Installing
First of all, you should download backend repository on your local machine.
1. Open project in Visual Studio
2. Build solution
3. Publish **HiQoDatagenerator.Web** project
4. Install **Scheduler**
5. Install **Scheduler Subscriber**

#### Publishing
1. Right click on the project name in **Solution Explorer**
2. In the popup menu select **Publish** 
3. Select **Folder** in **Pick a publish target** window
4. Choose the path to the publish folder
5. In **Publish Profile** open publish **configuration**
6. Select **Settings** tab and choose your **Target Runtime**
8. Click **Save** button
5. And finally click **Publish** button

#### Scheduler installing
1. Publish **HiQoDatagenerator.Scheduler** project
2. Run command promt **as administrator**
3. Open your publish folder in command promt
4. Paste the following command :
```
HiQoDataGenerator.Scheduler.exe install
``` 
5. Then you can start installed **Windows service** (The service name is **HiQoScheduler**)

#### Scheduler Subscriber installing
1. Publish **HiQoDatagenerator.SchedulerSubscriber** project
2. Run command promt **as administrator**
3. Open your publish folder in command promt
4. Paste the following command :
```
HiQoDataGenerator.SchedulerSubscriber.exe install
``` 
5. Then you can start installed **Windows service** (The service name is **HiQoSchedulerSubscriber**)

#### How to start Windows Service ?
1. Open **Task Manager**
2. Select **Services** tab
3. Find the required service
4. Right-click on it
5. In the popup menu select **Start**

#### How to start Windows Service from command line ?
1. Run command promt **as administrator**
2. Paste the following command:
```
sc start ServiceName
``` 

### Configuration
This application contains configuration files which can help you to configure the logging, database connection, as well as services.\
**Notice:** You must change **database connection strings** before starting the application

#### Web configuration
If you want to configure **logging** or **database connection** you can modify *appsettings.json* file in **HiQoDataGenerator.Web** publish folder.
Here you can find the description for all configuration parameters :

| Name                         | Description                                                                            |
| ----------------------- |  --------------------------------------------------------------- |
| AllowedHosts              |  The value is a semicolon-delimited list of host names, supported by Host Filtering Middleware, without port numbers  | 
| LogLevel->Default |  This property specifies the minimum level to log for selected categories. In the example, System and Microsoft categories log at Information level, and all others log at Debug level. All available log levels you can see [here](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.loglevel?view=aspnetcore-2.2) |
| PostgreConnection | PostgreSQL connection string                                                   |
| RedisConnection | Redis connection string                                                                 |
| MongoConnection| MongoDB connection string                                                       |
| FileSystem->Root | The name of the root directory for all resource files                        |
| GeneratedObjectsDirectory | The name of the root directory for generated object files |
| HttpStatusesForLogging | The value is a list of all HTTP status codes, which will be logged by Elmah Middleware |

#### Scheduler configuration
To configure **Scheduler** you can modify *settings.json* file  in **HiQoDataGenerator.Scheduler** publish folder. 

| Name                         | Description                                                                            |
| ----------------------- |  --------------------------------------------------------------- |
| RabbitMqQueueName | The name of RabbitMQ queue. Can take any nonempty value |
| publishEventjob->cronExpression | Cron expression that defines the interval for publishing events on RabbitMQ bus. You can find cron expression generator [here](http://www.cronmaker.com/)|
#### Scheduler Subscriber configuration
If you want to configure **Scheduler Subscriber** service you can modify *settings.json* file  in **HiQoDataGenerator.SchedulerSubscriber** publish folder. 

| Name                         | Description                                                                            |
| ----------------------- |  --------------------------------------------------------------- |
| FilesReadingLimit      | The limit on the number of files read at a time when an event is received from Scheduler |

### Start Up
1. First of all you should start **PostgreSQL Server**
2. Then you should start **MongoDB Server**
3. Start **Redis**
4. Start **RabbitMQ Server**
5. Now you should start the server . Just open *HiQoDataGenerator.Web.exe*  in **HiQoDataGenerator.Web** publish folder
6. Wait for migration to be completed
7. Finally, you can start **Scheduler** and **Scheduler Subscriber** services\
**Note:** all of this servers has its own Windows Services, so in order to start the server you just need to start the corresponding service in Task Manager.\
**Note:** you can aslo use **Swagger** to send requests to the server and check its functionality. Just input *https://hostName:port//swagger*  in your browser address bar.\
**Note:** to see all errors, logged by **Elmah**, just open *https://hostName:port//elmah*  in your browser.


### Usefull Links
1. What is Redis? [link](https://redis.io/topics/introduction)
2. Implementing an event bus with RabbitMQ. [link](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/rabbitmq-event-bus-development-test-environment )
3. MongoDB Manual. [link](https://docs.mongodb.com/manual/tutorial/getting-started/)
4. xUnit tutorial. [link](https://www.programmingwithwolfgang.com/xunit-getting-started/)
5. Swagger. [link](https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-2.2)
