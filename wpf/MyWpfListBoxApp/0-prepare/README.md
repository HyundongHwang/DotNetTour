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
WPF를 잘 배우기 위한 예제로 여러장의 이미지와 텍스트컨텐츠가 리스팅 되는 어플리케이션을 제작해 보기로 한다. <br>
샘플데이타를 준비해서 바로 UI개발부터 진행할수도 있겠지만, 여기서는 실전과 유사하게 HTTP 요청을 수행하여 이미지와 텍스트가 포함된 리스트 데이타를 받는 과정부터 시작하도록 한다. <br>
이 장에서는 HTTP요청을 하고 그 테스트를 하는 과정을 학습해 보기로 한다. <br>

최종적인 결과물은 아래그립과 같다. <br>
![]((https://s10.postimg.org/j5pjmb5qx/screenshot_114.png))

이제부터 본격적인 개발을 시작해보자! <br>

<br>
<br>
<br>

## 프로젝트 생성
- 이름 : MyWpfListBoxApp
- 타입 : WPF App

<br>
<br>
<br>

## 다음 이미지검색 API 소개
다음 이미지검색 OPEN API를 직접 사용할수도 있겠지만, 예제를 간단히 하기 위해서 미리 데이타를 캐시해둔 서버를 준비해 두었다. <br>
이 서버는 `Azure Function` 으로 만들엇는데 나중에 자세히 소개하도록 하겠다. <br>
캐시서버의 API의 사용방법은 아래와 같다. <br>

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
HTTP GET 요청을 구현하는 방법은 여러가지가 있겠으나 자주 사용되는 `HttpClient` 클래스를 사용하기로 한다.<br>
`HttpClient` 는 `System.Net.Http.dll` 에 포함되어 있는데 이는 프로젝트 생성시 기본으로 참조추가 되어 있어서 별도의 참조추가 작업없이 바로 사용가능하다.<br>
UI코드에서 직접 구현하는 것보다는 쉽게 테스트 가능하도록 API클래스를 별도로 만들어 보자. <br>
먼저 이 API를 사용하기 쉽도록 `DaumImgSearchApi` 클래스를 따로 만들고 실행함수를 만든다.

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

- 001 : 검색어를 입력받고, 결과로 json문자열을 리턴하는 원본 API형태의 기본 함수형태로 시작한다. json문자열을 객체로 변환하는 것은 이후에 서술한다.
- 002 : HttpClient는 비관리객체, 즉 메모리 GC만으로는 정리작업이 완결되지 않는 객체이다. 이 때문에 추가적인 정리작업이 필요하고, 보통 C#에서는 이런 비관리객체는 IDisposable 인터페이스를 상속받게 하여 객체해제시 Dispose함수를 호출하도록 강제한다. 이 Dispose함수의 호출이 잊지않고 안전하게 이뤄지기 위해서 C#에서는 언어차원에서 using 블럭을 지원하며 이 블럭을 나갈때 Dispose함수가 자동으로 호출되므로 안전하고 편리하다. HttpClient는 내부에서 TCP소켓객체를 사용하고 이를 연결종료하는 추가적인 작업이 필요해서 비관리객체로 분류한다. 주로 파일I/O, 네트워크I/O, 스트림, 데이타베이스 관련객체들이 비관리객체들인데 사용자클래스라도 정리작업이 별도로 필요한경우 얼마든지 IDisposable을 상속받아서 정리작업을 구현하면 된다.

<br>
<br>
<br>

## API 호출 테스트
이렇게 API를 호출하는 기본구현이 되었으니 테스트를 해서 정상동작 여부를 확인해 보자. <br>
먼저 생각나는 방법은 WPF 어플리케이션이니 버튼클릭하면 동작하는 형태정도일텐데 이번에는 이런 방식보다는 우아하게 닷넷프레임워크에서 제공하는 유닛테스트 기능을 이용해 보자. <br>

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
- 004
  - 함수의 이름은 아무거나 상관이 없지만 자세히 표시할수록 관리가 편하다.
- 005
  - 유닛테스트 함수내에서 쉽게 테스트하기 위해서 동기호출을 통해서 테스트한다.

이렇게 만들어진 유닛테스트는 Test Explorer 에서 테스트 해 볼수 있다.

> Test Explorer가 보이지 않는 경우는 Menu > Test > Test Explorer 에서 활성화 시킬수 있다.
필자의 경우는 비주얼스튜디오 우측상단의 Quick Lauch 기능을 이용해서 활성화 시켰다.
메뉴가 많기 때문에 일일히 기억하기 어렵다. <br>
![](https://s9.postimg.org/jozh56bun/screenshot_110.png)

이렇게 Test Explorer가 활성화 되면 실제로 유닛테스트를 실행해 볼수 있다.  <br>
![](https://s9.postimg.org/3qqrfc7fj/screenshot_111.png) <br>
![](https://s9.postimg.org/3qqrfhs1r/screenshot_112.png)

<br>
<br>
<br>

## json문자열을 C#객체로 변환
응답을 json문자열로 수신했으므로 C#객체로 변환해주어야 한다. <br>
수작업으로 클래스 코딩해도 되겠지만 자동변환 기능을 사용하는 것을 권한다. <br>
아래 그림과 같이 json2csharp 사이트에서 json 응답 문자열을 입력하면, POJO 클래스를 자동생성할 수 있다. <br>
![](https://s9.postimg.org/ujcbtevb3/screenshot_108.png)

이제 C#객체의 타입이 준비되었으니 실제 변환작업이 필요한데, 이때 
json과 객체간 상호변환을 위해서 `Newtonsoft.Json` 라이브러리를 주로 사용하는데 이는 nuget을 통해서 참조추가할 수 있다. <br>
아래 그림과 같이 nuget package manager를 이용하여 nuget repository에서 다운로드하고 참조추가 하는 방식으로 사용한다. <br>
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
  - Response객체를 따로 클래스를 뺄수도 있지만 API와 함께 사용될것이라 API의 내부클래스로 만들었다. 


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
  - 테스트의 내용들도 ExecuteAsync 의 변경으로 빌드오류가 발생하니 올바른 테스트가 되도록 적절히 수정해 줘야 한다.