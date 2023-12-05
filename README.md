
# About ReadSense :
Millions of individuals worldwide have central visual impairment, a medical condition where the center field of their
vision is blurred. This creates challenges and produces difficulties when they read. To address this, a project ’Reading
the Reader’ aims to use Machine Learning models to interpret and adapt settings for optimal reading experience for
the user. A smaller component of the project ReadSense was
developed. 
ReadSense is a personalized reading experience
analyzer that can be used across various devices including
e-readers, tablet, and smartphones, and in different contexts
such as place, brightness and environment. It aims to analyse user reading patterns and preferences through collecting
data points through logging interactions with the application.
The project underwent several low-fidelity iterations, user
testing through informal evaluations and an experiment, and
then was developed as a high-fidelity functional prototype.


## Development Setup
Peoject comprise of 2 components 
 1. Website 
 2. ReadSnese Api

Find The description and devlopement setup of each component in their respective readme files [Website](./website/README.md), [ReadSenseApi](./ReadSenseApi/README.md).

## Deployment
Currently this project is deployed to Azure Cloud. You can visit it using this url https://readsense.azurewebsites.net/

>Note: As we are using Azure App Service Free tier to deploy this website, azure will stop the server in case of long time inactivity, and it will start running again when we are trying to access the website. So sometimes, in this scenerio, it can take long time to load the website.

In the production deployment, we are using Azure App Service to deploy both website and ReadSensApi services. For database we are using [Azure SQL Database for free](https://learn.microsoft.com/en-us/azure/azure-sql/database/free-offer?view=azuresql).

