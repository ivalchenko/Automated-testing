set pathMSBuild="C:\Windows\Microsoft.NET\Framework\v4.0.30319\"
@echo off
cls
pushd %pathMSBuild%
msbuild.exe "D:\GitHubAutomation\GitHubAutomation.sln" /p:configuration=debug
pause
msbuild.exe "C:\GitHubAutomation\GitHubAutomation\CopyAutomation.csproj" /t:RunTests 
pause

