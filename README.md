# DotNetTour

<!-- TOC -->

- [DotNetTour](#dotnettour)
    - [소개](#%EC%86%8C%EA%B0%9C)
    - [대상독자](#%EB%8C%80%EC%83%81%EB%8F%85%EC%9E%90)
    - [선수과목](#%EC%84%A0%EC%88%98%EA%B3%BC%EB%AA%A9)
    - [목차](#%EB%AA%A9%EC%B0%A8)
    - [현재환경](#%ED%98%84%EC%9E%AC%ED%99%98%EA%B2%BD)

<!-- /TOC -->

<br>
<br>
<br>


## 소개
`DotNetTour`는 이책을 위한 가제목으로, 닷넷의 여러 부분을 패키지 관광상품처럼 편하면서도 실속있게 여행하는 기분으로 학습해보자는 취지로 생각한 이름이다. <br>
C#/WPF가 중심이 되어 윈도우 어플리케이션 개발에 대해 중점적으로 학습할 것이며, 예제를 구현하는데 필요한 웹서버, 클라우드, 스크립트도 함께 설명을 하기 위해 ASP.NET, Azure, PowerShell, NSIS, 기타 개발툴들도 설명할 것이다. <br>
UI가 필요없는 개념과 예제설명은 학습과정을 단순화 하기 위해 모두 C# ConsoleApp으로 실습한다. <br>
UWP는 학습할 분량이 많으나, 아직 활성화되지 않은 플랫폼이라 이 책에서는 다루지 않고, 다음에 기회 있으면 다루도록 한다. <br>
.NET Core, .NET Standard 등 신기술 흐름들도 아직 유동적인 상황이라 판단하여 이 책에서는 다루지 않고, 다음에 기회 있으면 다루도록 한다. <br>



<br>
<br>
<br>

## 대상독자
- 다양하고 실용적인 닷넷기반 윈도우 어플리케이션 예제를 학습하려는 독자
- C# 초급문법을 익히고 좀더 실용적인 개발을 해보고 싶은 독자
- 닷넷기반 윈도우 어플리케이션 개발을 이미 하고 있지만, 다양한 개발방식과 개발툴을 활용하여 개발생산성을 높이고 싶은 독자

<br>
<br>
<br>

## 선수과목
C# 문법 기초

<br>
<br>
<br>

## 목차
- hello .NET
    - [이론] 닷넷프레임워크 개요
        - 닷넷프레임워크 역사
        - 닷넷프레임워크 구성도
    - [이론] 이책에서 다루는 닷넷프레임워크 관련 기술들
        - C#
        - WPF
        - ASP.NET
        - PowerShell
    - [실습] VisualStudio 설치, 실행
        - VisualStudio 2017 Community Edition Preview
- C#
    - hello c#
        - [이론] C# 개요
        - [실습] HelloCsharpApp
            - 기본 콘솔프로젝트 생성
            - "hello c#" 출력
        - [이론] 프로젝트 구조 분석
            - vsproj 파일 분석
            - 자동생성 파일 분석
            - exe, dll 파일 배포 분석
    - json
        - [이론] 라이브러리 프로젝트, 종속성관리
        - [이론] nuget 소개
            - 라이브러리 설치, 삭제, 업데이트
            - 설치된 파일들 분석
        - [실습] json serialize/deserialize
    - async/await
        - [이론] 멀티스레드 프로그래밍, async/await
        - [이론] 멀티스레드 상황별 async/await 개발 패턴 소개
        - [실습] 각 개발패턴 구현
        - [이론] 자동생성 파일 분석
    - File
        - [이론] IDispose 소개
        - [실습] File read write
    - HTTP
        - [이론] HTTP 모듈들 비교분석
            - HttpWebRequest
            - WebClient
            - HttpClient
            - RestSharp
        - [실습] HttpClient 테스트
            - http://httpbin.org/ 타겟
            - HTTP GET
            - POST json
            - POST file
        - [실습] RestSharp 테스트
            - http://httpbin.org/ 타겟
            - HTTP GET
            - POST json
            - POST file
        - [이론] HTTPS 네트워크 보안 프로그래밍
            - HTTPS의 소개
            - MIM공격/차단
        - [실습] 공개인증서 확인을 통해 MIM공격시 접속차단
    - TcpSocket
        - [실습] TCP 텍스트 채팅프로그램
        - [실습] TCP SSL을 이용한 보안 채팅프로그램
    - LINQ
        - [이론] LINQ 소개
        - [실습] 다양한 LINQ 개발 패턴 구현
    - LINQ to SQL
        - [이론] LINQ to SQL 소개
        - [실습] Azure SQL Server 생성
        - [실습] DB생성, 테이블생성
        - [실습] CRUD 테스트
    - EntityFramework
        - [이론] EntityFramework 소개
        - [실습] CodeFirst 테이블생성
        - [실습] CodeFirst CRUD 테스트
        - [실습] DbFirst CRUD 테스트
    - Sqlite
        - [이론] Sqlite 소개
            - Sqlite
            - linq2db 프로젝트
        - [실습] 로컬 메모 어플리케이션
    - Mutex
        - [이론] Mutex 소개
        - [실습] 어플리케이션 다중실행 방지
    - 상호운용성
        - [이론] 닷넷, win32, COM 간의 상호운용성에 대한 설명
        - [실습] P/Invoke ( .NET -> Win32 )
            - Win32 MessageBox 호출
            - 커스톰 DLL 제작후 호출
        - [실습] COM Interop ( .NET -> COM )
            - excel COM 호출
            - 커스톰 COM 제작후 호출
        - [실습] COM Interop ( Win32 -> .NET )
    - 라이브러리
        - [실습] 라이브러리 프로젝트 생성, 개발, 테스트(LoggableStream)
        - [이론] nuget publish 소개
        - [실습] nuget publish 실습
            - nuget 라이브러리 설정파일 작성
            - nuget publish
            - nuget으로 설치/삭제/업데이트 테스트
    - roslyn
        - [이론] roslyn 소개
        - [실습] roslyn hello world 개발
    - 디스어셈블
        - [이론] Disasm 소개
        - [실습] 디스어셈블 실습
            - Disasm으로 HelloCsharpApp 디스어셈블
    - 서비스
        - [이론] 서비스 소개
        - [실습] 서비스로 구현한 간단한 웹서버
- Azure
    - hello Azure
        - [이론] Azure 소개
            - Azure 소개
            - Azure 구조
        - [이론] 이책에서 다루는 Azure 기술
            - Storage Service
                - Table
                - Blob
            - SQL Server
            - Function
            - Congnitive
        - [실습] Azure 계정만들기, Azure Portal 로그인
    - Azure Storage Service
        - [이론] Azure Storage Service 소개
        - [이론] Table Service 소개
        - [실습] Table Service 를 이용한 메모
        - [이론] Blob Service 소개
        - [실습] Blob Service 를 이용한 파일공유
    - Azure SQL Server
        - [이론] Azure SQL Server 소개
        - [실습] Azure SQL Server 실습
            - 비주얼스튜디오 SQL쿼리브라우져
            - 테이블 생성
            - CRUD 테스트
    - Azure Function
        - [이론] Azure Function 소개
        - [실습] 이미지 검색 Daum OpenAPI 를 이용한 캐시서버
    - Azure Congnitive
        - [이론] Azure Congnitive 소개
        - [실습] Azure Congnitive 실습
            - 음성인식
            - 이미지인식
            - OCR 테스트
- WPF
    - hello WPF
        - [이론] WPF 소개
            - WPF 아키텍쳐
        - [이론] Blend 소개
        - [실습] WPF hello world 개발
    - 데이타바인딩
        - [이론] DataBinding 소개
        - [실습] DataBinding을 이용한 계산기앱
        - [이론] ObservableCollection DataBinding 소개
        - [실습] ObservableCollection DataBinding 을 이용한 텍스트노트앱
    - UserControl
        - [이론] UserControl 소개
            - UserControl
            - DependancyProperty
        - [실습] UserControl 을 이용한 텍스트노트앱
    - ListBox
        - [이론] ListBox 소개
            - ListBox
            - ItemsTemplete
            - DataContext
        - [실습] ListBox 를 이용한 이미지검색앱
            - [준비](/wpf/MyWpfListBoxApp/0-prepare/README.md)
            - [기본 UI 개발](/wpf/MyWpfListBoxApp/1-basic-ui/README.md)
            - [커스톰 UserControl 개발](/wpf/MyWpfListBoxApp/2-custom-usercontrol/README.md)
            - [커스톰 Style 개발](/wpf/MyWpfListBoxApp/3-custom-style/README.md)
    - DataGrid
        - [이론] DataGrid 소개
        - [실습] DataGrid 를 이용한 실시간 증시앱
    - OpenCV
        - [이론] OpenCV 소개
        - [실습] OpenCV 를 이용한 얼굴인식
    - Chromium
        - [이론] Chromium 소개
        - [실습] Chromium, JavaScript Bridge를 이용한 메모장
    - Telerik
        - [이론] Telerik 소개
        - [실습] Telerik 샘플 3개
    - Scichart
        - [이론] Scichart 소개
        - [실습] Scichart 2D 샘플 2개
        - [실습] Scichart 3D 샘플 2개
    - Actipro
        - [이론] Actipro 소개
        - [실습] 미니 비주얼 스튜디오
            - Actipro C# IDE 와 roslyn 컴파일
- ASP.NET
    - hello ASP.NET
        - [이론] ASP.NET 소개
        - [실습] ASP.NET hello world
    - ASP.NET WebApi
        - [이론] ASP.NET WebApi 소개
        - [실습] 메모장 서버 REST 서버
        - [실습] Swagger 적용
        - [실습] REST API와 SinglePageApp 을 이용한 메모장 사이트
        - [실습] REST API와 WPF를 이용한 메모장 앱
    - SignalR
        - [이론] ASP.NET SignalR 소개
        - [실습] javascript 채팅프로그램
        - [실습] WPF 채팅프로그램
        - [실습] Fiddler를 이용한 채팅프로그램 네트워크 분석
- PowerShell
    - hello PowerShell
        - [이론] PowerShell 이란
        - [실습] 기본명령어들 (ls, cd, help, gcm, gal, sal ...)
        - [실습] profile.ps1 편집
    - Function, Script, Module
        - [이론] 소개
        - [실습] Function 샘플
        - [실습] Script 샘플
        - [실습] Module 샘플
    - .NET dll 호출
        - [이론] 소개
        - [실습] .NET dll 호출 샘플
    - Module 사용
        - [이론] 소개
        - [실습] 검색, 설치, 업데이트, 삭제
        - [실습] FastFilePub 설치, 사용
    - Module 배포
        - [이론] 소개
        - [실습] Module 샘플 구현후 배포
- 설치, 삭제, 업데이트, 빌드/배포 자동화
    - hello install, uninstall, update
        - [이론] 설치/삭제/업데이트 프로그램 소개
    - NSIS simple
        - [이론] nsis 소개
        - [실습] MyApp 설치/삭제 프로그램
    - NSIS pluging
        - [이론] 플러그인 소개
        - [실습] 설치프로그램에서 닷넷프레임워크 버전체크후 다운로드후 설치
    - 배포, 롤백 스크립트
        - [이론] 배포/롤백 자동화 스크립트 소개
        - [실습] 자동화 스크립트 소개
    - updater
        - [이론] 업데이터 소개
        - [실습] MyApp 업데이트 서버 준비(AzureStorageBlob)
        - [실습] MyAppUpdater.exe 구현
        - [실습] 업데이트 
    - 코드사인
        - [이론] 코드사인의 원리
        - [실습] 테스트 인증서 생성
        - [실습] exe, dll에 코드사인
        - [실습] 각 환경별 코드사인 확인
    - 난독화
        - [이론] 난독화 소개
        - [실습] Dotfuscator 사용하여 바이너리 난독화하기
            - ildasm 이용하여 디스어셈블 성공
            - Dotfuscator 사용하여 바이너리 난독화하기
            - ildasm 이용하여 디스어셈블 실패
    - 바이러스 검사
        - [이론] 배포전 바이러스검사, 인터넷 백신 virustotal 소개
        - [실습] virustotal 로 배포전 검사하기
    - 빌드/배포 자동화
        - [이론] appveyor CI 소개
        - [실습] appveyor CI 실습
            - sample WPF 프로젝트 준비
            - 서비스가입
            - appveyor.yaml 설정파일 작성
            - git push 연동하여 빌드, 배포 자동화 테스트
- 기타 개발툴
    - hello tools
        - [이론] 개발툴과 생산성 소개
    - git
        - [이론] git 소개
        - [실습] Powershell 에서 git 의 기본명령어 사용
        - [실습] git log, diff 명령어 Powershell Function으로 커스토마이즈
    - Fiddler
        - [이론] Fiddler 소개
        - [실습] http 모니터링
        - [실습] http 요청 생성
        - [실습] https 모니터링
    - WireShark
        - [이론] WireShark 소개
        - [실습] TCP 모니터링
        - [실습] pcap 파일 저장후 Fiddler에서 로드
    - VsCode
        - [이론] VsCode 소개
        - [실습] 유용한 플러그인 설치
        - [실습] 단축키
    - markdown
        - [이론] markdown 소개
        - [실습] VsCode 에서 문서작성
    - PostImage
        - [이론] PostImage 소개
        - [실습] 이미지 캡쳐, 편집, 업로드
    - WebSequenceDiagrams
        - [이론] WebSequenceDiagrams 소개
        - [실습] 시퀀스 다이어그램 문서 작성
    - HockeyApp
        - [이론] HockeyApp 크래시레포트 라이브러리 소개
        - [실습] WPF에서 크래시 레포트 수집 테스트 
    - BlackBox
        - [이론] BlackBox 클라우드기반 로그 라이브러리 소개
        - [실습] WPF에서 로그 수집
        - [실습] Powershell에서 로그 확인, 조회, 삭제
    - FastFilePub
        - [이론] FastFilePub 클라우드기반 파일공유 스크립트 소개
        - [실습] FastFilePub 파일업로드, 조회, 삭제 테스트
    - VS CodeSnippet
        - [이론] CodeSnippet 소개
        - [실습] DependancyProperty 를 위한 VS CodeSnippet 작성하기, 적용하기
    - other windows useful util ...

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
