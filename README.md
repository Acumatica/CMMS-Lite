# CMMS-Lite

## Installation for Development

Installation of Acumatica build 23.106.0050 is required
1. Download installer from [builds.acumatica.com](http://acumatica-builds.s3.amazonaws.com/index.html?prefix=builds/23.1/23.106.0050/AcumaticaERP/ "builds.acumatica.com")
2. Create .bat file with the following content
```bash
@echo off
msiexec /a "C:\Users\[user_profile]\Downloads\AcumaticaERPInstall.msi" TARGETDIR="C:\Acumatica\23.106.0050"
```
3. Run the newly created .bat file as administrator to install Acumatica ERP
4. Open Visual Studio and choose "continue without code"
5. Within VS navigate to Git --> "Clone Repository"and input the following information
	Respository Location : https://github.com/Acumatica/CMMS-Lite
	Path : C:\Projects\CMMS [Solution root directory on local machine]
6. On completion of repository clone, navigate to the root folder of the solution (C:\Projects\CMMS)
7. Delete any folder similar to CMMS_22_111_0020 EXCEPT "CMMS".
8. Open previously installed Acumatica ERP configuration wizard.  This will be located at _C:\Acumatica\23_106_0050\Acumatica ERP\Data\AcumaticaConfig.exe_.
9. Create instance named 23r1 installed in the root folder of the solution.  The full path should be C:\Projects\CMMS\23r1.  The database name, instance name, virtual directory and Application Pool can be named anything, but a suggested option is CMMS_23R1 for the database and application pool and CMMS for the virtual directory.  Be sure to check the box for _Do Not Compile the Site_.
10. Ensure the following 3 entries in web.config match the proper paths shown and that the folders exist:
```
    <add key="CustomizationTempFilesPath" value="C:\Projects\CMMS\Customization\23r1" />
    <add key="SnapshotsFolder" value="C:\Projects\CMMS\Snapshots\23r1" />
    <add key="BackupFolder" value="C:\Projects\CMMS\BackUp\Sites\23r1" />
```
11. Open the project in Visual Studio, and navigate to the desired branch for development.  (By default, this would be Development)
12. Copy the _project folder from C:\Projects\CMMS\Package\CMMS to C:\Projects\CPE\CMMS[23.106.0050][0000]
13. Open the new website and create a customization project called CMMS[23.106.0050][0000] and go into the project.
14. On the Source Control menu, select Open Project from Folder, and select C:\Projects\CPE\CMMS[23.106.0050][0000] for the folder.
15. Rebuild the project in Visual Studio to get the .DLL file.
16. Refresh the browser to reload with the new .DLL in memeory.
17. Open the Files section and Detect Modified Files to pick up the newly compiled .DLL.
18. Publish the customization project.

## Development process
1. Within VS nagivate to Git --> "Manage Branches"
2. Right click on remote "development" branch and click "new local branch from"
3. branch name should follow one of the following patterns, where the number is the next free in the series under the catagory
	1. feature/0000-description
	2. update/0000-description
	3. bugfix/0000-description
4. do your work on your new branch
5. Commit changes
6. Create pull request between your current branch and the development branch for code review
7. As reviewers make comments resolve issues on your current branch and push the changes, the open PR will reflect the changes automatically

## Functional Spec Documentation
[CMMS.Lite.Functional.Specification.docx](https://github.com/Acumatica/CMMS-Lite/files/10138464/CMMS.Lite.Functional.Specification.docx)

[Computerized.Maintenance.Management.Software.CMMS.docx](https://github.com/Acumatica/CMMS-Lite/files/10138466/Computerized.Maintenance.Management.Software.CMMS.docx)
