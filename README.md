# DotNetTour

<!-- TOC -->

- [DotNetTour](#dotnettour)
    - [소개](#%EC%86%8C%EA%B0%9C)
    - [도서샘플](#%EB%8F%84%EC%84%9C%EC%83%98%ED%94%8C)
    - [목차](#%EB%AA%A9%EC%B0%A8)
    - [현재환경](#%ED%98%84%EC%9E%AC%ED%99%98%EA%B2%BD)

<!-- /TOC -->

<br>
<br>
<br>

## 소개
`DotNetTour`는 이책을 위한 가제목으로, 닷넷의 여러 부분을 패키지 관광상품처럼 편하면서도 실속있게 여행하는 기분으로 학습해보자는 취지로 생각한 이름이다. <br>
WPF중심으로 닷넷프로그래밍 전반, 윈도우어플리케이션 개발 일부에 대해 다룰것이다. <br>
간단하지만 실용적인 예제가 항상 함께 제공될 것이며, 실제기능구현에 초점을 맞춰서 이를 따라하면서 그 기본과 원리를 배워보도록 한다. <br>
이 문서는 이 책의 목차에 해당하는데 집필과정중 변경될 수 있다. <br>
목차에 하이퍼링크가 걸려 있는 경우가 있는데 이는 연관된 내용이 필자의 블로그글로 존재하는 경우 연결한 것이다. <br>
이 문서는 현재 github 사이트에 공개되어 있지만 실제 출판사와 집필계약에 따라 비공개로 변경될 수 있다. <br>

<br>
<br>
<br>


## 도서샘플
실제 집필을 하는 마음으로 한챕터를 작성해 보았다. <br>
[WPF/MyWpfListBoxApp/준비](/wpf/MyWpfListBoxApp/0-prepare/README.md)


<br>
<br>
<br>


## 목차
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
- 설치, 업데이트
    - hello install, update
    - NSIS simple
    - NSIS pluging
    - updater
- Tools
    - [hello tools](/tools-hello-tools/README.md)
    - [git](/tools-git/README.md)
    - [resharper](/tools-resharper/README.md)
    - [markdown](/tools-md/README.md)
    - [code2flow](/tools-code2flow/README.md)
    - [windows useful exe](/tools-win-useful-exe/README.md)

<br>
<br>
<br>


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
