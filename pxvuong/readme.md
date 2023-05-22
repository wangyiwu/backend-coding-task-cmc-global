# Cloning Source Code and Running Docker Compose
This guide provides step-by-step instructions on how to clone the source code repository and run Docker Compose to set up and run the application.

## Prerequisites

Before you begin, ensure that you have the following prerequisites installed on your system:

[Git](https://git-scm.com/) - Version control system for cloning the source code repository.

[Docker](https://www.docker.com/)- Containerization platform for running the application with Docker Compose.

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

2. Inside folder backend-coding-task-cmc-global, change to the directory to pxvuong

```
cd pxvuong
```

3. In the terminal, execute the following command to start the application using Docker 
```
docker-compose up
```

## Access the Application


### Access to api swagger

In broser aceess to url: http://localhost:7084/swagger/index.html (make sure you are using http, currrenty this application doesn't config https)

![img1](https://i.imgur.com/iG5537Y.png)

#### As a consumer of the API, I want to be able to add ships to the system.

Step 1: to to swagger

Step2: Press try it out
![img1](https://i.imgur.com/FqDhfIC.png)

Step3: Press Execute

![img1](https://i.imgur.com/XpgZifP.png)

See the result:
![img1](https://i.imgur.com/HsAPNLG.png)


#### As a consumer of the API, I want to be able to see the closest port to a ship with estimated arrival time to the port together with relevant details.


Step 1: to to swagger

Step2: Press try it out
![img1](https://i.imgur.com/sJA5i72.png)

Step3: Press Execute and Enter Ship Name

then wait and see the result:
![img1](https://i.imgur.com/iWW1NXR.png)



### Access to UI

In broser aceess to url: http://localhost:7084/index.html   (make sure you are using http, currrenty this application doesn't config https)

You can view the port and the closest port to ship.





The red line indicates that this is the shortest path from the ship to the harbour.

<img src="https://raw.githubusercontent.com/FortAwesome/Font-Awesome/6.x/svgs/solid/anchor.svg" width="50" height="50"> icon indicates that this is the Port . </br>

<img src="https://github.com/FortAwesome/Font-Awesome/raw/0698449d50f2b95517562295a59d414afc68b369/js-packages/%40fortawesome/fontawesome-free/svgs/solid/ship.svg" width="50" height="50"> Ship icon indicates that this is the Ship.


![img1](https://i.imgur.com/TGIGdEm.png)