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