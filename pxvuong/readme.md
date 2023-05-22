# Cloning Source Code and Running Docker Compose
This guide provides step-by-step instructions on how to clone the source code repository and run Docker Compose to set up and run the application.

## Prerequisites

Before you begin, ensure that you have the following prerequisites installed on your system:

[Git](https://git-scm.com/) - Version control system for cloning the source code repository.

[Git](https://www.docker.com/)- Containerization platform for running the application with Docker Compose.

## Clone the Source Code

1. Open a terminal or command prompt on your system.

2. Change to the directory where you want to clone the source code.

3. Execute the following command to clone the source code repository:

```
git clone https://github.com/wangyiwu/backend-coding-task-cmc-global.git
```

4. Wait for the cloning process to complete. Once finished, you will have a local copy of the source code.

## Run Docker Compose

1. Change to the directory where the source code repository has been cloned.

```
cd <repository-directory>
```

Replace <repository-directory> with the name of the directory where the source code was cloned.

2. Change to the directory to pxvuong

```
cd pxvuong
```

3. In the terminal, execute the following command to start the application using Docker 
```
docker-compose up
```

## Access the Application


### Access to api swagger

In broser aceess to url: http://localhost:7084/swagger/index.html

### Access to UI

In broser aceess to url: http://localhost:7084/index.html

You can view the port and the closest port to ship.

*The red line indicates that this is the shortest path from the ship to the harbour.*

![img1](https://i.imgur.com/TGIGdEm.png)