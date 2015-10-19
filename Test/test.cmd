PUSHD 
CD /d %~dp0 
CLS



@REM == C#

del "%CD%\Output\C#\*.html"
xcopy "%CD%\Input" "%CD%\Output\C#"

for %%i in ("%CD%\Output\C#\*.html") DO "%CD%\..\Bin-Console\hc.exe" "%%i"


@REM == Java

del "%CD%\Output\Java\*.html"
xcopy "%CD%\Input" "%CD%\Output\Java"

for %%i in ("%CD%\Output\Java\*") DO java -jar "%CD%\Java\hc.jar" -o "%%i" "%%i"



POPD 