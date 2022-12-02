# CMMS-Lite

## Installation

Installation of Acumatica build 22.111.0020 is required
1. Download installer from [builds.acumatica.com](http://acumatica-builds.s3.amazonaws.com/index.html?prefix=builds/22.1/22.111.0020/AcumaticaERP/ "builds.acumatica.com")
2. Create .bat file with the following content
```bash
@echo off
msiexec /a "C:\Users\user_profile\Downloads\AcumaticaERPInstall.msi" TARGETDIR="C:\Program Files\Acumatica\22_111_0020"
```
3. Run the newly created .bat file as administrator to install Acumatica ERP
4. Open Visual Studio and choose "continue without code"
5. Within VS navigate to Git --> "Clone Repository"and input the following information
	Respository Location : https://github.com/Acumatica/CMMS-Lite
	Path : C:\Projects\CMMS [Solution root directory on local machine]
6. On completion of repository clone, navigate to the root folder of the solution
7.  Delete folder CMMS_22_111_0020
8. Open previously installed Acumatica ERP configuration wizard
9. Create instance named CMMS_22_111_0020 installed in the root folder of the solution, replacing the folder just deleted in the previous step
10. Publish current customization project

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
