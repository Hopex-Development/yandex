# Yandex supports classes by Schizo

The library contains a class for playing text with 6 voices and 3 intonations, as well as a class that allows you to asynchronously download and upload files from the cloud.

## How to use Yandex.Disk

```C#
public void YandeskDisk()
{
    // You should have oauth token from Yandex Passport, see https://tech.yandex.ru/oauth/
    string oauthToken = "<token hear>";

    // Create a disk instance
    Disk MyDisk = new Disk(oauthToken);
    
    // Upload file from local
    Disk.UpLoad(
        diskPath: "SomeFolder/MyDocs/Template.docx",
        localPath: @"C:\%USERPROFILE%\Desktop\Template.docx",
        isOwerwrite: false
    );
    
    // Download file from disk
    Disk.DownLoad(
        diskPath: "SomeFolder/MyDocs/Template.docx", 
        localPath: @"C:\%USERPROFILE%\Desktop\Template.docx"
    );
}
```

## How to use Yandex.Speech

```C#
public void YandeskSpeech()
{
    // You should have oauth token from Yandex Passport, see https://tech.yandex.ru/oauth/
    string oauthToken = "<token hear>";

    // Create a speech instance
    Speech MySpeech = new Speech();
    
    // Speech by simple system voice (Is't Yandex.Speech)
    MySpeech.NewSpeech("Some text for speech", 0);
    
    // Speech in any voice and intonation
    MySpeech.NewSpeech(
        oauthToken,
        "Some text for speech",
        Speakers.Jane,
        Emotions.Evil
    );
}
```

## Contributors
- [YandexDisk.Client](https://github.com/raidenyn/yandexdisk.client)
- [NAudio](https://github.com/naudio/NAudio)

## License
MIT License
