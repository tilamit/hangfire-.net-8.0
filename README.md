<h2 align="center">
    <a style="text-decoration:none;" href="https://github.com/tilamit/hangfire-.net-8.0">
      Hangfire With .NET 8.0
    </a>
    <br/>
</h2>

## Project Goal

To demonstrate background job using Hangfire with .NET

<p align="center">
    <img src="https://i.ibb.co.com/hKGFxkh/Screenshot-2024-10-29-130319.png" alt="hangfire-.net-8.0" />
</p>

 <h4>Image Ref: 
  <a style="text-decoration:none;" href="https://www.hangfire.io">
      Hangfire
  </a>
 </h4>


<p align="center">
    <img src="https://i.ibb.co.com/vw0rkZS/Screenshot-2024-10-29-135829.png" alt="hangfire-.net-8.0" />
</p>

 <h4>Image Ref: 
  <a style="text-decoration:none;" href="https://www.youtube.com/watch?v=OkpXpMBUG9c">
      Programming with Felipe Gavilan
  </a>
 </h4>

## When to Use Hangfire with C#

In the world of **C#** and **ASP.NET**, efficient job handling is key. While real-time operations keep things smooth, sometimes you need to offload tasks to the background. Hangfire — a robust library for background job processing in .NET comes into play. Let’s dive into when you should use Hangfire and how it can enhance your applications.

### 1. Offloading Heavy Tasks

When your application needs to perform heavy tasks—like data processing, generating reports, or complex calculations—doing them in real-time could bog down performance. Hangfire allows you to queue these tasks as background jobs, ensuring your app remains responsive.

**Example**: 

Imagine a reporting tool where users can request complex data reports. Instead of making them wait, schedule a Hangfire job to process and generate the report in the background, and notify the user once it’s ready.

### 2. Scheduled Jobs

If your application requires periodic tasks like sending out daily reports, cleaning up old data, or syncing with an external API, Hangfire’s recurring jobs feature can handle this seamlessly.

**Example**: 

Suppose you have to take database backup every morning. You configure a windows service and run it at a specific time. Instead of windows service, Hangfire can do the job at ease with .NET.

### 3. Reliable Job Execution

In scenarios where job reliability is critical—where tasks must be executed even if the system crashes or restarts—Hangfire shines. It ensures job persistence and retries, providing a robust solution for critical operations.

**Example**: 

Payment processing in an e-commerce application. Ensure each payment attempt is reliably processed, with automatic retries in case of failure.

### 4. Fire-and-Forget Tasks

Sometimes, you need to execute tasks without waiting for them to complete. Hangfire’s fire-and-forget feature is perfect for these quick, independent tasks that don’t require immediate feedback.

**Example**: 

Sending confirmation emails after user registration. Users don’t need to wait for the email to be sent; queue it up and let Hangfire handle it in the background.

**Example For This Project**: In this project, we would create a scheduled job that'll take database backup everyday in a specific time.

## Built With

#### Environment & Development Tools：

* .NET Version: 8.0
* IDE: Visual Studio 2022
* Framework: .NET Web Api
* Backend: C# 12, SMO - SQL Server Management Objects 
* Database: MS SQL Server 2019

## Getting Started

Initially the project will restore all the required nuget packages for the project. If not, the following will help to make it done manually. 

For example, to install SMO and Hangfire package from nuget, the following command will download the specific version for the project.

### Prerequisites

* Nuget Package Manager

```sh
PM> Install-Package Microsoft.SqlServer.SqlManagementObjects
```

```sh
PM> Install-Package Hangfire
```

* SQL Server Database

In this example, SQL Server database is used to take the database backup as script. To take it as script, SMO package has been integrated. Just use the above command if nuget doesn't restore it by itself. 

* Hangfire

Hangfire is the one that takes care of the scheduled job in the background. After running the project, you can access the Hangfire dashboard as follows:

It's pretty handy and you can install it using nuget package manager.


Hangfire Dashboard             |
:-------------------------:|:-------------------------:
![](https://i.ibb.co.com/nR6ggkm/Screenshot-2024-10-29-142040.png)  |

## Authors

* **Amit Kanti Barua** - *Remote Software Engineer* - [Amit Kanti Barua](https://github.com/tilamit) - *Built ReadME Template*

## Acknowledgements

* [Amit Kanti Barua](https://github.com/tilamit)
