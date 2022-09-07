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
