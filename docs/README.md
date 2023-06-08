# Yandex supports classes by Schizo

The library contains a class for playing text with 6 voices and 3 intonations, as well as a class that allows you to asynchronously download and upload files from the cloud.

# Adding to the project

#### .NET CLI
```CLI
> dotnet add package Hopex.Yandex --version 23.0.3
```

#### Package Manager
```CLI
PM> NuGet\Install-Package Hopex.Yandex -Version 23.0.3
```

#### PackageReference
```XML
<PackageReference Include="Hopex.Yandex" Version="23.0.3" />
```

#### Paket CLI
```CLI
> paket add Hopex.Yandex --version 23.0.3
```

#### Script & Interactive
```CLI
> #r "nuget: Hopex.Yandex, 23.0.3"
```

#### Cake
```
// Install Hopex.Yandex as a Cake Addin
#addin nuget:?package=Hopex.Yandex&version=23.0.3

// Install Hopex.Yandex as a Cake Tool
#tool nuget:?package=Hopex.Yandex&version=23.0.3
```

# How to use

### Yandex.Disk

```C#
public void YandeskDisk()
{
    // You should have oauth token from Yandex Passport, see https://tech.yandex.ru/oauth/
    string oauthToken = "<token hear>";

    // Create a disk instance
    Disk MyDisk = new Disk(oauthToken);
    
    // Upload file from local
    Disk.UploadFile(
        diskPath: "SomeFolder/MyDocs/Template.docx",
        localPath: @"C:\%USERPROFILE%\Desktop\Template.docx",
        isOwerwrite: false
    );
    
    // Download file from disk
    Disk.DownLoadFile(
        diskPath: "SomeFolder/MyDocs/Template.docx", 
        localPath: @"C:\%USERPROFILE%\Desktop\Template.docx"
    );
}
```

### Yandex.Speech

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
