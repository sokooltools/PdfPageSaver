:: Run this command file to build the PdfPageSaver mini-application.
::
:: NOTE: Modfiying this solution requires that lines 83 thru 90 below also be modified to reflect the change(s)...
::
@echo off
title Performing Build...
set DEBUG=false

set LN=========================================================================================================

echo.
echo %LN%
echo Preparing .Net environment...
echo.
::if not defined DOCUMENTS set DOCUMENTS=%USERPROFILE%\Documents
::call "C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\Tools\vsdevcmd.bat" x86

echo.
echo %LN%
echo Preparing for build...
if not exist "bin\" (
	echo.
	echo Creating directory "bin\"
	mkdir bin\
)
if not exist "obj\Debug\" (
	echo.
	echo Creating directory "obj\Debug\"
	mkdir obj\Debug\
)

echo.
echo %LN%
echo Generating Resource files...
echo.
"C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6 Tools\resgen.exe" ^
	/useSourcePath ^
	/r:"Externals\PdfSharp.dll" ^
	/r:"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5.2\mscorlib.dll" ^
	/r:"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5.2\System.Core.dll" ^
	/r:"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5.2\System.Data.dll" ^
	/r:"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5.2\System.Deployment.dll" ^
	/r:"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5.2\System.dll" ^
	/r:"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5.2\System.Drawing.dll" ^
	/r:"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5.2\System.Windows.Forms.dll" ^
	/r:"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5.2\System.Xml.dll" ^
	/compile MainForm.resx,obj\Debug\PdfPageSaver.MainForm.resources Properties\Resources.resx,obj\Debug\PdfPageSaver.Properties.Resources.resources

echo.
echo %LN%
echo Compiling...
echo.
"C:\Program Files (x86)\MSBuild\14.0\bin\csc.exe" ^
	/noconfig ^
	/nowarn:1701,1702,2008 ^
	/nostdlib+ ^
	/errorreport:prompt ^
	/warn:4 ^
	/define:DEBUG;TRACE ^
	/main:PdfPageSaver.Program ^
	/errorendlocation ^
	/preferreduilang:en-US ^
	/highentropyva+ ^
	/reference:"Externals\PdfSharp.dll" ^
	/reference:"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5.2\mscorlib.dll" ^
	/reference:"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5.2\System.Core.dll" ^
	/reference:"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5.2\System.Data.dll" ^
	/reference:"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5.2\System.Deployment.dll" ^
	/reference:"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5.2\System.dll" ^
	/reference:"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5.2\System.Drawing.dll" ^
	/reference:"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5.2\System.Windows.Forms.dll" ^
	/reference:"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5.2\System.Xml.dll" ^
	/debug+ ^
	/debug:full ^
	/filealign:512 ^
	/optimize- ^
	/out:obj\Debug\PdfPageSaver.exe ^
	/ruleset:"C:\Program Files (x86)\Microsoft Visual Studio 14.0\Team Tools\Static Analysis Tools\\Rule Sets\AllRules.ruleset" ^
	/subsystemversion:6.00 ^
	/resource:obj\Debug\PdfPageSaver.MainForm.resources ^
	/resource:obj\Debug\PdfPageSaver.Properties.Resources.resources ^
	/target:winexe ^
	/utf8output ^
	/win32icon:app.ico ^
	FileProperties.cs ^
	MainForm.cs ^
	MainForm.Designer.cs ^
	Program.cs ^
	Properties\AssemblyInfo.cs ^
	TextBoxEx.cs ^
	Properties\Resources.Designer.cs ^
	Properties\Settings.Designer.cs ^
	"%USERPROFILE%\AppData\Local\Temp\.NETFramework,Version=v4.5.2.AssemblyAttributes.cs" 

echo.
echo %LN%
echo Copying files marked as local...
echo.
echo Copying file from "Externals\PdfSharp.dll" to "bin\PdfSharp.dll"...
xcopy /y/q/d "Externals\PdfSharp.dll"  "bin\*"
echo.

if %DEBUG%==true (
	echo Copying file from "Externals\PdfSharp.pdb" to "bin\PdfSharp.pdb"...
	xcopy /y/q/d "Externals\PdfSharp.pdb"  "bin\*"
	echo.
	echo Copying file from "Externals\PdfSharp.xml" to "bin\PdfSharp.xml"...
	xcopy /y/q/d "Externals\PdfSharp.xml"  "bin\*"
	echo.
)

echo.
echo %LN%
echo Copying files to output folder...
echo.
echo Copying file from "obj\Debug\PdfPageSaver.exe" to "bin\PdfPageSaver.exe"...
xcopy /y/q/d  "obj\Debug\PdfPageSaver.exe" "bin\*"
echo.

if %DEBUG%==true (
	echo Copying file from "obj\Debug\PdfPageSaver.pdb" to "bin\PdfPageSaver.pdb"...
	xcopy /y/q/d  "obj\Debug\PdfPageSaver.pdb" "bin\*"
	echo.
)

echo.
echo %LN%
echo Copying Application Configuration file...
echo.
echo Copying file from "app.config" to "bin\*"...
xcopy /y/q/d  "app.config" "bin\*"
echo.
if exist "bin\app.config" ( 
	echo Copying file from "bin\app.config" to "bin\PdfPageSaver.exe.config"...
	move /y "bin\app.config" "bin\PdfPageSaver.exe.config"
	echo.
)

echo.
echo %LN%
echo Done.
echo.

pause
