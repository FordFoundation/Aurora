# Aurora Upload Utility (AUU)

The Aurora Upload Utility (AUU) is an application designed to allow users to apply RAC required metadata to a digital record transfer. The utility enables users to select a folder(s) or file(s) with the same metadata and push it to the RAC Aurora repository. 

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

    1) Windows 8 or above
	  2) Microsoft .NET Framework 4.6.2 or above
	  3) python 3.4 or later is required
	  4) Access to SFTP Share location (RAC will provide SFTP information)
	  5) SFTP Port should be open in user system (RAC will provide SFTP port information)

### Installing

Copy [RACAUU] (https://github.com/FordFoundation/Aurora/RACAUU) folder to your local drive and change 

Below information needs to update in the RACAUU.exe.config file in [RACAUU] folder:
    <add key="HostName" value="HostURL"/>  <!--SFTP URL-->
    <add key="SFTPUserName" value="SFTPusername"/>
    <add key="SFTPPassword" value="SFTPPassword"/>
    <add key="SFTPPort" value="PortNo"/>  
    <add key="SFTPDirectory" value="./upload"/>  <!--SFTP Directory to upload files-->
    <add key="PythonExePath" value="cd C:/python34"/>  <!--python installation folder path on your local machine-->
    <add key="PythonDirectory" value="C:"/>        <!--python installed directory on your local machine-->
    <add key="Profile_Json" value="http://aurora.dev.rockarch.org/api/bagit_profiles/5.json"/> <!--Profile path for validate-->
    <add key="SourceOrganization" value="OrganizationName"/>  <!--Your Organization Name -->
    
## Running the tests

Explain how to run the automated tests for this system

### Break down into end to end tests

Explain what these tests test and why

```
Give an example
```

### And coding style tests

Explain what these tests test and why

```
Give an example
```

## Deployment

Add additional notes about how to deploy this on a live system

## Built With

* [Dropwizard](http://www.dropwizard.io/1.0.2/docs/) - The web framework used
* [Maven](https://maven.apache.org/) - Dependency Management
* [ROME](https://rometools.github.io/rome/) - Used to generate RSS Feeds

## Contributing

Please read [CONTRIBUTING.md](https://gist.github.com/PurpleBooth/b24679402957c63ec426) for details on our code of conduct, and the process for submitting pull requests to us.

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/your/project/tags). 

## Authors

* **Billie Thompson** - *Initial work* - [PurpleBooth](https://github.com/PurpleBooth)

See also the list of [contributors](https://github.com/your/project/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Hat tip to anyone whose code was used
* Inspiration
* etc
