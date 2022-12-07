# Notes


## HTML en self-closing tags

```html
<img src="" />
```

HTML 1.0
HTML+
...
HTML 4.01 - 1998


---- XHTML: `<img /> <input /> <link />`

HTML5 - 2012

"void elements"

Zelfsluitende notatie werkt ook gewoon niet, bijv.:
```html
<script src="bla.js" />
<textarea />
```

En content is sowieso niet toegestaan in deze elementen:

```html
<br>bla</br>
<hr>bla</hr>
<input>
<link>
<img>
```

## Blazor

- Microsoft
- Niet Blake Zorro
- Steve Sanderson
  - Knockout.js
- Daniel Roth

- .NET in de browser
- Concurrent van SPA-libraries: React, Svelte, Angular, Vue
- Minder JavaScript
- Gewoon C#
- Performance
- geinterpreteerde taal < gecompileerde taal

- Blazor
  - Hosten


edities Blazor:
- Blazor WebAssembly
  - jouw code draait in de browser
  - .NET moet even op worden gestuurd
  - ~7MB
    - Compressie: gzip brotli
  - .NET Core => Mono

  - ASP.NET Core hosted
    - meteen een backend
      - CORS
      - compressie
      - Server-side rendering
        - Hydration
          - Partial hydration


- Blazor Server
  - jouw code draait op de server
  - WebSocket - SignalR
    - automatic reconnecting
    - groeperen
  - veel sneller met laden


.NET MAUI?
- het nieuwe Xamarin

appdevelopment:
- .NET MAUI
  - Blazor mobile bindings
- Flutter
- Xamarin
- React Native
- Avollonia

## UI-zaken

Material Design - designfilosofie van Google, bedoeld voor Android

Implementaties:
- React
  - MUI
- Vue
  - Vuetify
- Angular
  - Angular Material
- Algemeen
  - Material Design Components
- Blazor
  - MudBlazor
  - MatBlazor
  - Zie [awesome-blazor](https://github.com/AdrienTorris/awesome-blazor) voor langere lijst aan component libraries

IBM Carbon
Windows Fluent

## Dependency injection

- leuk
- je hoeft niet de precieze implementatie te weten
- een vorm van Inversion of Control
- grootste voordelen?
  - testbaarheid

## JP's onofficiele lijstje van wanneer je niet hoeft te unittesten:

- als je stagiaire/tester alle tests te laat schrijven

- als je x% code coverage probeert te halen
  - 80%

- als jouw project < 6 maanden duurt
  - advent of code
  - schoolprojecten

  "niets is zo permanent als een tijdelijke oplossing"

```cs
try {
	controller.Do();
}
catch(Exception ex) {

}
```

## Lifecycles

```cs
// wat Blazor doet:
var comp = new JouwComponent();
comp.Getal = elem.GetAttribute("Getal"); // initializatie
comp.OnInitialized();
```

## Test-driven development

Voordelen TDD?
- kost veel tijd (WERD GEROEPEN)
- code is instant testbaar
- alle functionaliteit getest
- geforceerd nadenken over alle opties
- "technical debt"
- vorm van uitvoerbare documentatie


Test-driven development

1. Schrijf een test
2. Run de test en zie dat hij faalt
3. Schrijf code
4. Run de test en zie dat hij slaagt
5. Refactor

Repeat.

RED-GREEN-REFACTOR



Testframeworks:
- MSTest - Microsoft
- NUnit - begint met een N, niet van Microsoft
- xUnit - NUnit, maar dan met een X


verschillen OOIT:
- `[TestMethod]`
- `[Test]`
- `[Fact]`/`[Theory]`

```cs
[ExpectedException(...)]
public void Test()
{
	
}
// vs
Assert.Throws<MijnException>(() => controller.Do());
```

Subtiel verschil xUnit/MSTest:
```cs
Assert.AreEqual("hoi", "doei");
// "hoi" does not match "doei"

Assert.Equal("hoi", "doei");
/*
These do not match:

"hoi"
"doei"
 ^
*/
```

Met FluentAssertions zijn de verschillen nog kleiner.
