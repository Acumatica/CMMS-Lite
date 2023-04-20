@ECHO OFF
COLOR 2

SETLOCAL ENABLEDELAYEDEXPANSION ENABLEEXTENSIONS

SET PackageDir=

REM This will find the greatest package number
FOR /D %%D IN ("C:\Users\Public\CMMS[23.101.0071]*") DO (
	SET PackageDir=%%D
)

RMDIR ..\Package\CMMS /S /Q
XCOPY !PackageDir!\_project ..\Package\CMMS\_project\ /S /Q /E /Y
XCOPY !PackageDir!\ReportsCustomized ..\Package\CMMS\ReportsCustomized\ /S /Q /E /Y
XCOPY !PackageDir!\ReportsDefault ..\Package\CMMS\ReportsDefault\ /S /Q /E /Y

PAUSE