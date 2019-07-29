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

*Copy [RACAUU](https://github.com/FordFoundation/Aurora/tree/master/RACAUU) folder to your local drive and change.

*Create 3 below folders in main RACAUU folder, you can change these folder names/path using configuration file

	*Bag
	*BagArchive
	*Logs

*Below information needs to update in the RACAUU.exe.config file in [RACAUU](https://github.com/FordFoundation/Aurora/tree/master/RACAUU) folder:

    ```
    *<add key="HostName" value="HostURL"/>  <!--SFTP URL, RAC will provide this information-->
     <add key="SFTPUserName" value="SFTPusername"/> <!--SFTP User Name, RAC will provide this information-->
     <add key="SFTPPassword" value="SFTPPassword"/> <!--SFTP Password, RAC will provide this information-->
     <add key="SFTPPort" value="PortNo"/>  <!--SFTP Port Number, RAC will provide this information-->
     <add key="SFTPDirectory" value="./upload"/>  <!--SFTP Directory to upload files-->
     <add key="PythonExePath" value="cd C:/python34"/>  <!--python installation folder path on your local machine-->
     <add key="PythonDirectory" value="C:"/>        <!--python installed directory on your local machine-->
     <add key="Profile_Json" value="http://aurora.dev.rockarch.org/api/bagit_profiles/5.json"/> <!--Profile path for validate-->
     <add key="SourceOrganization" value="OrganizationName"/>  <!--Your Organization Name -->]
    
    ```
    
   
## Running the application (How to use it)

Once the AUU is setup on your machine, you can begin using it. 
 
Step 1: Open the utility and make sure that the "Record Type" field is populated with your organization's record types (these will be different for each organization)
 
Step 2: Ensure the size of the records you want to accession does not exceed 2 GB. If it does exceed 2 GB you will have to break up the bag and send it in multiple transfers
 
Step 3: Choose to transition either Files or Folders and click the "Choose Files/Folders" button to select the file(s) or folder(s) you want to include in the bag. If you want to include both you must add each type (files or folders) to the bag separately.
 
Step 4: Provide the remaining metadata for the material you are transfering
	Internal Sender Description
	Title
	Start Date
	End Date
	Record Type (record series)
	External ID (this is the organization's ID)
	Bag count (to be used only if a single accession or bag needs to be split and sent in two transfers)
	Bag Group Identifier (to be used only if a single accession or bag needs to be split and sent in two transfers)
	Record Creator (this refers to the creators of the business record NOT the AUU record)
	Language
 
Step 4: Click the "Create and Validate" button 
 
You should receive a message that the bag transfer was successful. If the transfer failed, you should run it again. 


## Development 

Download the source code [AUU](https://github.com/FordFoundation/Aurora/) to your location machine and open the solution/project in Visual Studio 2017 or later versions.
Update the App.config according to your organization requirements as mentioned in How to use it steps. 

## Build

* [Visual Studio 2017 or later versions](https://docs.microsoft.com/en-us/dotnet/core/tutorials/with-visual-studio) - IDE
* [.NET Command-Line Interface](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-options/command-line-building-with-csc-exe) - From command line interface
* [Jenkins MSBuild.exe](https://www.c-sharpcorner.com/article/integrate-jenkins-with-msbuild/) - Jenkins

## Build With

* .NET C#
* Python
 
## Contributing


Ford Foundation is not looking to enhance the AUU based on other organizations use and that we are not soliciting contributions. 


## Authors

[Ford Foundation](https://www.fordfoundation.org/)

## License

This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/FordFoundation/Aurora/blob/master/LICENSE) file for details

## Acknowledgments

This project consumed huge amount of work, research and dedication. Still, implementation would not have been possible if we did not have a support of Ford Foundation and RAC. Therefore we would like to extend our sincere gratitude to Ford Foundation.
