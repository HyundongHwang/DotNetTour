<!-- TOC -->

- [MyWpfListBoxApp 개발준비](#mywpflistboxapp-%EA%B0%9C%EB%B0%9C%EC%A4%80%EB%B9%84)
    - [프로젝트 생성](#%ED%94%84%EB%A1%9C%EC%A0%9D%ED%8A%B8-%EC%83%9D%EC%84%B1)
    - [다음 이미지검색 API 소개](#%EB%8B%A4%EC%9D%8C-%EC%9D%B4%EB%AF%B8%EC%A7%80%EA%B2%80%EC%83%89-api-%EC%86%8C%EA%B0%9C)
    - [API 호출 구현](#api-%ED%98%B8%EC%B6%9C-%EA%B5%AC%ED%98%84)
    - [API 호출 테스트](#api-%ED%98%B8%EC%B6%9C-%ED%85%8C%EC%8A%A4%ED%8A%B8)
    - [json문자열을 C#객체로 변환](#json%EB%AC%B8%EC%9E%90%EC%97%B4%EC%9D%84-c%EA%B0%9D%EC%B2%B4%EB%A1%9C-%EB%B3%80%ED%99%98)

<!-- /TOC -->

<br>
<br>
<br>

# MyWpfListBoxApp 개발준비
WPF를 빠르고 쉽게 학습하기 위한 예제로 여러장의 이미지와 간단한 텍스트가 혼합된 리스트컨트롤 예제를 준비했다. <br>
샘플데이타를 하드코딩해서 바로 UI개발부터 진행할수도 있겠지만, 이번장에서는 실전과 유사하게 HTTP 요청을 직접 수행하여 데이타를 준비하는 것부터 시작하도록 한다. <br>

최종적인 어플리케이션의 모습은 아래그립과 같다. <br>
![](https://s10.postimg.org/j5pjmb5qx/screenshot_114.png)

이제부터 본격적인 코딩으로 들어가 보자! <br>

<br>
<br>
<br>

## 프로젝트 생성
아래의 내용대로 WPF 프로젝트를 생성한다.
- 이름 : MyWpfListBoxApp
- 타입 : WPF App

<br>
<br>
<br>

## 다음 이미지검색 API 소개
이미지와 텍스트가 포함된 데이타는 `다음 OpenAPI`를 이용하기로 한다. <br>
독자들이 `다음 OpenAPI` 의 계정을 만들어서 직접 호출해 볼수도 있겠지만, 개발과정을 간단히 하기 위해서 필자가 계정이 필요없는 캐시서버를 준비했다. <br>
이 캐시서버는 `Azure Function` 으로 만들었는데, 이는 나중에 `Azure Function` 장에서 자세히 소개하도록 하겠다. <br>
이미지검색 API의 사용방법은 아래와 같다. <br>

```json
GET https://hhdfuncopenapicache.azurewebsites.net/api/DaumImgSearchApi?query={검색어}

{
  "channel": {
    "result": "10",
    "pageCount": "3988",
    "item": [
      {
        "image": "http://cdnau.ibtimes.com/sites/au.ibtimes.com/files/styles/v2_article_large/public/2016/09/24/microsoft.jpg",
        "thumbnail": "https://search2.kakaocdn.net/argon/130x130_85_c/c6WEs1MeI9",
        "cpname": "블로그스팟",
        "width": "740",
        "link": "https://cyberog.blogspot.kr/2016/11/microsoft-surface-phone.html",
        "title": "&lt;b&gt;Microsoft&lt;/b&gt; Surface Phone",
        "cp": "805300",
        "pubDate": "20161124134900",
        "height": "493"
      },
 ...
    ],
    "lastBuildDate": "Fri, 22 Dec 2017 12:10:42 +0900",
    "link": "http://dna.daum.net/apis",
    "description": "Daum Open API search result",
    "generator": "Daum Open API",
    "title": "Search Daum Open API",
    "totalCount": "977200"
  }
}
```

<br>
<br>
<br>

## API 호출 구현
HTTP GET 요청을 구현하는 방법은 여러가지가 있겠으나 이번장에서는 `HttpClient` 클래스를 사용하기로 한다.<br>
`HttpClient` 는 `System.Net.Http.dll` 에 포함되어 있는데 이는 프로젝트 생성시 기본으로 참조추가 되어 있어서 별도의 참조추가 작업없이 바로 사용가능하다.<br>
UI코드에서 직접 구현하는 것보다는 쉽게 테스트 가능하도록 API클래스를 별도로 만들어 보자. <br>
먼저 이 API를 사용하기 쉽도록 `DaumImgSearchApi` 클래스를 따로 만들고 실행함수를 만든다.

> ** 닷넷에서 HTTP를 다루는 라이브러리 **
> 닷넷에서 HTTP를 다루는 라이브러리는 BCL로 제공되는 HttpWebRequest, WebClient, HttpClient 3가지와 3rd party로 제공되는 RestSharp 이렇게 4가지가 있다.
> 다양해서 혼란스럽기도 하지만 각각의 특성을 이해하고 적절한 상황에 사용한다면 더 좋은 코드를 작성할 수 있을것이다.
> - HttpWebRequest
>   - 네임스페이스 : System.Net
>   - 어셈블리 : System.dll
>   - 버전지원 : 닷넷 2.0 이상
>   - 가장 원시적인 형태의 HTTP 기능
>   - 가장 큰 유연성 제공
>   - 상세하게 제어가 가능하지만 그만큼 구현시 코드가 길어진다.
> - WebClient
>   - 네임스페이스 : System.Net
>   - 어셈블리 : System.dll
>   - 버전지원 : 닷넷 2.0 이상
>   - HttpWebRequest 보다 높은수준의 추상화를 제공하여 단순하고 편리하고 안정성이 높다.
> - HttpClient
>   - 네임스페이스 : System.Net.Http
>   - 어셈블리 : System.Net.Http.dll
>   - 버전지원 : 닷넷 4.5 이상
>   - WebClient 보다 HTTP에 가깝도록 설계됨.
>       - WebClient 는 HTTP, FTP의 클라이언트로 동작할 수 있지만 HttpClient는 HTTP 클라이언트로만 동작할 수 있다.
>   - 모든 I/O 메소드가 비동기임.
>   - HttpWebRequest의 유연성과 WebClient의 단순성을 결합한 설계철학
>   - BCL로 구현가능한 가장 좋은 솔루션이지만, 닷넷 4.5 이상에서만 사용가능하기 때문에 리거시시스템을 고려할때는 선택하기 어렵다.
> - RestSharp
>   - nuget : RestSharp
>   - 버전지원 : 닷넷 3.5 이상
>   - HTTP REST API 에 가장 최적화됨
>   - json, xml 시리얼라이즈 자동지원
>   - 멀티파트 업로드 지원
>   - OAuth 1.0, OAuth 2.0, Basic 등 대부분의 인증체계 지원, 인증기능 커스토마이즈 가능하다.
>   - 기능적으로도 REST를 위한 모든 기능이 총망라된 강력한 솔루션이고 버전지원도 충분하다. 이번장 이후로는 RestSharp으로 예제를 작성할 예정이다.

```csharp
public class DaumImgSearchApi
{
    //(001)
    public async Task<string> ExecuteAsync(string query)
    {
        var url = $"https://hhdfuncopenapicache.azurewebsites.net/api/DaumImgSearchApi?query={query}";
        var resStr = "";

        //(002)
        using (var client = new HttpClient())
        {
            resStr = await client.GetStringAsync(url);
        }

        return resStr;
    }
}
```

- 001
    - 검색어를 입력받고, 결과로 json문자열을 리턴하는 원본 API형태를 거의 유지한 형태로 함수를 만들었다. 
    - json문자열을 객체로 변환하는 것은 이후에 서술하도록 하겠다.
- 002
    - HttpClient는 비관리객체, 즉 메모리 GC만으로는 정리작업이 완결되지 않는 객체이다. 
        - 이 때문에 추가적인 정리작업이 필요하고, 보통 C#에서는 이런 비관리객체는 IDisposable 인터페이스를 상속받게 하여 객체해제시 Dispose함수를 호출하도록 강제한다. 
        - 이 Dispose함수의 호출이 잊혀지지 않고 안전하게 이뤄지기 위해서 C#에서는 언어차원에서 using 이라는 키워드를 만들어 놓았다. 개발자가 using구문을 작성하고 그 내부에 구현하면 구문을 실행후 이 블럭을 나갈때 닷넷프레임워크는 using 선언문에 정의된 객체의 Dispose함수를 호출하게 된다. 
        - 이렇게 개발자는 안전한 코드를 편리하게 작성할 수 있게 된다. 
    - 추가적으로 HttpClient는 내부에서 TCP소켓객체를 사용하고 이를 연결종료하는 추가적인 작업이 필요해서 비관리객체가 된 것이다. 
        - 비슷한 사유로 BCL클래스 중에는 파일I/O, 네트워크I/O, 스트림, 데이타베이스 관련객체들이 비관리객체들이 되는데 사용자클래스라도 정리작업이 별도로 필요한경우 얼마든지 IDisposable을 상속받아서 Dispose 함수에 정리작업을 구현하면 using을 통한 정리구현을 강제할 수 있다.

<br>
<br>
<br>

## API 호출 테스트
이렇게 API를 호출하는 기본구현이 되었으니 실제로 서버에 HTTP 요청을 보내는 테스트를 해서 정상동작 여부를 확인해 보자. <br>
먼저 생각나는 방법은 WPF 어플리케이션이니 버튼클릭하면 동작하는 형태정도일텐데 이번에는 우아하게 닷넷프레임워크에서 제공하는 유닛테스트 기능으로 테스트코드를 작성해 보자. <br>

유닛테스트를 이용하려면 먼저 `Microsoft.VisualStudio.QualityTools.UnitTestFramework` 어셈블리를 추가해야 한다. <br>
개발자 로컬환경에 이미 설치되어 있으니 정확한 경로를 찾아서 참조추가 해 줄수 있다. <br>
`C:\Program Files (x86)\Microsoft Visual Studio\Preview\Community\Common7\IDE\ReferenceAssemblies\v2.0\Microsoft.VisualStudio.QualityTools.UnitTestFramework.dll` <br>

필자는 위 경로가 길고 외우기는 힘들어서, Add Reference 의 찾기기능에 `unittest` 검색어를 입력하여 참조추가 했다. <br>
![](https://s9.postimg.org/rvmvjgf8v/screenshot_109.png)

이렇게 유닛테스트를 위한 참조추가가 완료되면 아래와 같이 테스트 클래스를 작성한다. <br>

```csharp
//(003)
[TestClass]
public class MyTests
{
    //(004)
    [TestMethod]
    public void daum_img_search_api()
    {
        var api = new DaumImgSearchApi();
        //(005)
        var res = api.ExecuteAsync("microsoft").Result;
        Assert.IsTrue(res.Length > 0);
    }
}
```

- 003
  - 테스트 클래스와 메소드를 [TestClass], [TestMethod] 의 어트리뷰트를 붙여서 작성한다. 이렇게 작성된 클래스와 메소드는 비주얼스튜디오에서 유닛테스트로 인식되어 실행가능하다.
  - 또한 테스트 클래스의 한정자는 꼭 public 으로 변경해 주어야 비주얼스튜디오 유닛테스트에서 이 테스트가 인식된다.
    - 클래스 한정자 기본값은 생략된 형태 즉 internal인데 이걸 public으로 변경해 주어야 외부 프로세스인 비주얼스튜디오 유닛테스트가 테스트를 인식하고 실행가능한 상태가 된다.
- 004
  - 함수의 이름은 아무거나 상관이 없지만 자세히 표시할수록 관리가 편하다.
- 005
  - 유닛테스트 함수내에서 쉽게 테스트하기 위해서 동기호출을 통해서 테스트한다.

이렇게 만들어진 유닛테스트는 Test Explorer 에서 테스트 해 볼수 있다.

> Test Explorer가 보이지 않는 경우는 Menu > Test > Test Explorer 에서 활성화 시킬수 있다.
> 필자의 경우는 비주얼스튜디오 우측상단의 Quick Lauch 기능을 이용해서 활성화 시켰다.
> 메뉴가 많기 때문에 일일히 기억하기 어렵다. <br>
> ![](https://s9.postimg.org/jozh56bun/screenshot_110.png)

이렇게 Test Explorer가 활성화 되면 실제로 유닛테스트를 실행해 볼수 있다.  <br>
![](https://s9.postimg.org/3qqrfc7fj/screenshot_111.png) <br>
![](https://s9.postimg.org/3qqrfhs1r/screenshot_112.png)

<br>
<br>
<br>

## json문자열을 C#객체로 변환
응답을 json문자열로 수신했으므로 C#객체로 변환해주어야 한다. <br>
수작업으로 응답클래스를 코딩해도 되겠지만 안전하고 간편하게 자동변환 기능을 사용하는 것을 권한다. <br>
필자는 json문자열을 자동변환하기 위해서 http://json2csharp.com/ 사이트를 주로 이용한다. <br>
아래 그림과 같이 json 응답 문자열을 입력하면, C# POJO 클래스를 자동생성할 수 있다. <br>
![](https://s9.postimg.org/ujcbtevb3/screenshot_108.png)

이제 C#객체의 타입이 준비되었으니 실제 변환작업을 해야할 차례이다.
닷넷에서 json과 객체간 상호변환을 위해서 `Newtonsoft.Json` 라이브러리를 주로 사용하는데 이는 nuget을 통해서 참조추가할 수 있다. <br>
아래 그림과 같이 nuget package manager를 이용하여 nuget repository에서 다운로드하고 참조추가 하는 방식으로 사용한다. <br>
nuget을 통해 라이브러리를 설치, 삭제, 업데이트, 배포 하는 방식은 부록을 통해 자세히 설명하도록 하겠다. <br>
![](https://s9.postimg.org/mctit6mj3/screenshot_113.png)


```csharp
public class DaumImgSearchApi
{
    //(006)
    public class Response
    {
        public Channel channel { get; set; }

        public class Item
        {
            public string image { get; set; }
            public string thumbnail { get; set; }
            public string cpname { get; set; }
            public string width { get; set; }
            public string link { get; set; }
            public string title { get; set; }
            public string cp { get; set; }
            public string pubDate { get; set; }
            public string height { get; set; }
        }

        public class Channel
        {
            public string result { get; set; }
            public string pageCount { get; set; }
            public List<Item> item { get; set; }
            public string lastBuildDate { get; set; }
            public string link { get; set; }
            public string description { get; set; }
            public string generator { get; set; }
            public string title { get; set; }
            public string totalCount { get; set; }
        }
    }

    public async Task<Response> ExecuteAsync(string query)
    {
        var url = $"https://hhdfuncopenapicache.azurewebsites.net/api/DaumImgSearchApi?query={query}";
        var resStr = "";

        using (var client = new HttpClient())
        {
            resStr = await client.GetStringAsync(url);
        }

        var res = JsonConvert.DeserializeObject<Response>(resStr);
        return res;
    }
}
```

- 006
  - 필자는 Response가 API에 종속된다고 판단해서 inner class로 설계했다.
    - 이렇게 설계하면 Response를 외부에서 접근할 때 DaumImgSearchApi.Response 가 되어 타입이 분명해서 가독성이 좋아진다.


```csharp
[TestClass]
public class MyTests
{
    [TestMethod]
    public void daum_img_search_api()
    {
        var api = new DaumImgSearchApi();
        var res = api.ExecuteAsync("microsoft").Result;
        //(007)
        Assert.IsTrue(res.channel.item.Count > 0);
    }
}
```

- 007
    - ExecuteAsync 의 리턴타입이 json문자열에서 DaumImgSearchApi.Response 로 변경되어 테스트코드에서 빌드에러가 난다.
    - 위와 같이 테스트코드를 수정해 주어야 한다.