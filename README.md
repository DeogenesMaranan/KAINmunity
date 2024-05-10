<p align="center">
  <img src="https://cdn-icons-png.flaticon.com/512/6295/6295417.png" width="100" />
</p>
<p align="center">
    <h1 align="center">KAINmunity</h1>
</p>
<p align="center">
    <em><code>Community Driven Initiative to Aid Food Insecurity and Waste Management</code></em>
</p>
<p align="center">
	<img src="https://img.shields.io/github/last-commit/baddddddddd/KAINmunity?style=flat&logo=git&logoColor=white&color=0080ff" alt="last-commit">
	<img src="https://img.shields.io/github/languages/top/baddddddddd/KAINmunity?style=flat&color=0080ff" alt="repo-top-language">
	<img src="https://img.shields.io/github/languages/count/baddddddddd/KAINmunity?style=flat&color=0080ff" alt="repo-language-count">
</p>
<p align="center">
	<b>CS-2202</b><br>
	<a href="https://github.com/baddddddddd">Vladimir M. Jocson</a><br>
	<a href="https://github.com/ratatatatcode">James Michael D. Magnaye</a><br>
	<a href="https://github.com/DeogenesMaranan">Deogames Gregorio S. Maranan</a><br>
	<a href="https://github.com/DonClarko">Clarence C. Zamora</a><br>
</p>
<hr>

##  Quick Links

> - [ Overview](#-overview)
> - [ Features](#-features)
> - [ Repository Structure](#-repository-structure)
> - [ Modules](#-modules)
> - [ Getting Started](#-getting-started)
>   - [ Installation](#-installation)
>   - [ Running KAINmunity](#-running-KAINmunity)
>   - [ Tests](#-tests)
> - [ Project Roadmap](#-project-roadmap)
> - [ Contributing](#-contributing)
> - [ License](#-license)
> - [ Acknowledgments](#-acknowledgments)

---

##  Overview

KAINmunity is a grassroots initiative dedicated to tackling the pressing issue of food scarcity within communities, aligning with Sustainable Development Goal 2.1. Our mission is to contribute towards the global effort to end hunger by 2030, ensuring equitable access to safe, nutritious, and ample food year-round, especially for vulnerable populations such as infants and those facing economic hardships.

At KAINmunity, we envision a future where every individual has consistent access to nourishing meals. Through community-driven action, we aim to address immediate food shortages and foster sustainable waste management practices, creating a holistic solution that uplifts both people and the planet.

<a href="https://docs.google.com/document/d/1VtrOqc4V38Y6yfGSq5DNijLHJk6MDnuU-LjbC3pNi-4/edit?usp=sharing">KAINmunity Paper</a>

---

##  Features

- **User Authentication:** Login/Signup

- **Donation Management:** Donate food items/View donation history

- **Request Management:** Request food items/View request history

- **Dashboard:** Overview of donations and requests

- **Feedback:** Provide feedback on the application

- **Leaderboards:** View top donors/View top contributors

- **User Interaction:** Access forums for transparency and community interaction

- **Profile Management:** Edit user profile information

---

##  Folder Structure

```sh
└── KAINmunity/
    ├── README.md
    └── src
        ├── KainmunityClient
        │   ├── Forms
        │   ├── KainmunityClient.sln
        │   ├── Models
        │   ├── Properties
        │   ├── Resources
        │   └── ServerAPI
        └── KainmunityServer
            ├── Controllers
            ├── DataAccess
            ├── KainmunityServer.sln
            ├── Models
            └── Properties
```

---

## Technical Requirements

The following technologies were used to develop KAINmunity

* **C#**: As the primary programming language, C# provides the backbone for KAINmunity's functionality, enabling developers to create powerful, performant code.
  
* **WinForms**: Leveraging WinForms for the user interface development ensures a responsive and intuitive user experience, with features designed to enhance user engagement and interaction.
  
* **ASP.NET Core**: This framework serves as the framework for building scalable and high-performance web applications, empowering KAINmunity to deliver dynamic content and services to its users across various devices and platforms.
  
* **MySQL**: As the database management system, MySQL offers robust data storage and retrieval capabilities, ensuring the secure management of user data and content within KAINmunity.
  
* **Aiven**: Aiven provides managed cloud services for open-source data infrastructure, offering KAINmunity reliable and scalable solutions for data storage, processing, and management.
  
* **GitHub**: GitHub serves as the collaboration platform for KAINmunity's development team, facilitating version control, code management, and seamless collaboration throughout the software development lifecycle.

---

##  Getting Started

***Requirements***

Ensure you have the following dependencies installed on your system:

* **Visual Studio 2022**
* **.NET Desktop Development**

###  Running the server

**Disclaimers**

Running the server requires having the environment variables to connect to our database. In order to obtain these environment variables, please contact the developers.

1. Copy the .env file that contains the database connection credentials in the project root directory.
2. Open the KainmunityServer.sln in Visual Studio
3. Run and build the application in "Release" mode
4. Accept all the firewall permissions that the application may request.

### Running the application

**Disclaimers**

If the application runs in a different computer from the server's host computer, make sure to connect to the same LAN network and obtain the IP Address of the host computer then paste it as the command line argument before running the app through Visual Studio.

1. Open the KainmunityClient.sln in Visual Studio
2. Run and build the application in "Release" mode
3. Accept all the firewall permissions that the application may request.

##  Acknowledgments

- Ma'am Fatima: Our beloved AOOP Professor
- Sa crush po ni James
- Sa ex ni Vlad
- Sa Girlfriend ni Deo
- Sa Girlfriend ni Clarence

Uno Cutie!!!
---
