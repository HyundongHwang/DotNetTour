# DotNetTour

<!-- TOC -->

- [DotNetTour](#dotnettour)
    - [소개](#%EC%86%8C%EA%B0%9C)
    - [현재환경](#%ED%98%84%EC%9E%AC%ED%99%98%EA%B2%BD)
    - [로드맵](#%EB%A1%9C%EB%93%9C%EB%A7%B5)

<!-- /TOC -->

## 소개

- .NET 기술을 이용해서 실용적이고 단순한 예제를 만들고 설명을 추가
- 책을 집필하는 자세로 정성껏 기록하되 매일 조금이라도 작성하는게 목표
- 아름다운 .NET 코드로 우아하고 재미있는 프로그래밍!!!

## 현재환경
- Windows 10
- Visual Studio 2017 Community Edition Preview
- Visual Studio Code
- PowerShell 5

```powershell
PS C:\> $PSVersionTable

Name                           Value
----                           -----
PSVersion                      5.1.16299.98
PSEdition                      Desktop
PSCompatibleVersions           {1.0, 2.0, 3.0, 4.0...}
BuildVersion                   10.0.16299.98
CLRVersion                     4.0.30319.42000
WSManStackVersion              3.0
PSRemotingProtocolVersion      2.3
SerializationVersion           1.1.0.1
```

## 로드맵
- [hello .NET](/hello-dot-net/README.md)
- C#
    - hello c#
    - [json](/cs-json/README.md)
    - [async/await](/cs-async-await/README.md)
    - file i/o
    - http
    - https
    - socket server/client
    - LINQ
    - LINQ to SQL
    - [EntityFramework](/cs-ef/README.md)
    - [win32 DLL <-> .NET EXE/DLL ... p/invoke interop](/cs-win32-pinvoke/README.md)
    - [win32 COM DLL <-> .NET EXE/DLL ... COM interop](/cs-win32-com-dot-net-interop/README.md)
    - [win32 EXE/DLL <-> .NET COM DLL COM ... COM interop](/cs-win32-dot-com-net-interop/README.md)
    - codesign
    - library
    - nuget publish
    - [roslyn](/cs-roslyn/README.md)
    - [sample LoggableStream](/cs-sample-loggablestream/README.md)
- Azure
    - hello Azure
    - Storage Blob
    - Storage Table
    - VM
    - SQL Server
    - [Function](/azure-function/README.md)
    - Congnitive
- WPF
    - hello WPF
    - MyWpfListBoxApp 
        - [준비](/wpf/MyWpfListBoxApp/0-prepare/README.md)
        - [기본 UI 개발](/wpf/MyWpfListBoxApp/1-basic-ui/README.md)
        - [커스톰 UserControl 개발](/wpf/MyWpfListBoxApp/2-custom-usercontrol/README.md)
        - [커스톰 Style 개발](/wpf/MyWpfListBoxApp/3-custom-style/README.md)
    - image processing
- ASP.NET
    - hello ASP.NET
    - [WebApi](/asp-net-web-api/README.md)
    - SPA
    - [SignalR](/asp-net-signalr/READMD.md)
- PowerShell
    - [hello PowerShell](/ps-hello-ps/README.md)
    - ls, cd, help, gcm, gal, sal ...
    - my profile.ps1
    - function
    - script
    - call .NET dll
    - ps gallery publish
- Tools
    - [hello tools](/tools-hello-tools/README.md)
    - [git](/tools-git/README.md)
    - [resharper](/tools-resharper/README.md)
    - [markdown](/tools-md/README.md)
    - [code2flow](/tools-code2flow/README.md)
    - [windows useful exe](/tools-win-useful-exe/README.md)