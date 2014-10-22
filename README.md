Meduza.net
==========

.NET wrapper for [Meduza.io](https://Meduza.io) API. [Meduza.io](https://Meduza.io) is the news project of the old [Lenta.ru](http://en.wikipedia.org/wiki/Lenta.ru) team.

Reversed API documentation
--------------------------
[/api/v1/index](https://Meduza.io/api/v1/index)
```json
{
  root: [{
      "title": "[Title]",
      "screen_type": "[screenType]",
      collection: [{
        "[uri]"
      }],
      "updated_at": 1413818419
  }],
  documents: {
    "[uri]": {
      "url": "[uri]",
      "title": "[title]",
      "second_title": "[secondTitle]",
      "authors": [
        ["Author"]
      ],
      "document_type": "[documentType]",
      "version":[versionInt],
      "published_at":1413814542,
      "updated_at":1413814542,
      "full":[isFullBoolean],
      "source": {
        "url": "[sourceUrl]",
        "name": "[sourceName]",
        "quote": "[sourceQuote]"
      },
      "image": {
        "original_url": "[originalImageUri]",
        "large_url": "[largeImageUri]",
        "small_url": "[smallImageUri]",
        "caption": "[caption]",
        "credit": "[credit]"
      }
    }
  }
}
```
`[screenType]` can be `news`, `topic`, `cards`, `articles`, `fun`.

`[documentType]` can be `feature`, `news`, `card`, `fun`, `topic`.

`[funType]` can be `video`, `coub`, `picture`, `infographics`.

### Additional JSON base on `[screenType]
#### Is contained in `root` property

`news`
```json
"main": "[uri]"
```

### Additional JSON based on `[documentType]`
#### Is contained in `documents` property

`card`
```json
"chapters_count":[chaptersQuantityInt],
"table_of_contents":[
  "[chapterName]"
],
"thesis": "[thesis]",
"chapters": [{
  "title": "[title]",
  "content": "[content]"
}],
"layout_url": "[layoutUrl]",
"bg_image": {
  "large_url": "[largeBgUri]",
  "small_url": "[smallBgUri]",
  "caption": "[caption]",
  "credit": "[credit]"
}
```

`fun`
```json
"fun_type": "[funType]"
```

`topic`
```json
"content": [
  "[uri]"
]
```
