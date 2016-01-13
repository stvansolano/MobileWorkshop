
#Xamarin 4 Workshop

## Requirements

System requirements: 
https://developer.xamarin.com/guides/xamarin-forms/getting-started/installation/

## Getting Xamarin installed
Install Xamarin platform.

- For Windows/Mac: https://xamarin.com/download

- Or you can get it by installing Visual Studio 2015

Visual Studio 2015: https://www.visualstudio.com/en-us/downloads/download-visual-studio-vs.aspx

### Recommended Emulators for Android
[Xamarin Android Player](https://xamarin.com/android-player)

[Genymotion](https://www.genymotion.com/#!/download)

## Developing a Xamarin.Forms app from scratch

In Visual Studio:
-- *New Project -> Installed -> Visual C# -> Cross-Platform -> Blank App (Xamarin.Forms Portable)*

In Xamarin Studio:
-- *File -> New -> Solution -> Cross-platform -> App -> Xamarin.Forms App (Use Portable Class Library)*

![Setup](://stvansolano.github.io/2016/01/04/Workshop-de-Xamarin-4-en-BrainStation/setup.png)

Let's inspect the App.cs main code that which is responsible for supporting the UI for all the platforms running our app:

By doing so will get:
- A Xamarin.Forms project for sharing XAML/C# code between platforms
- Android project referencing Xamarin.Forms
- iOS project
- UWP project

Let's set the project structure to be used later in this tutorial:

![structure](://stvansolano.github.io/2016/01/04/Workshop-de-Xamarin-4-en-BrainStation/structure.png)

## Hello World, Xamarin.Forms!

![Hello World!](://stvansolano.github.io/2016/01/04/Workshop-de-Xamarin-4-en-BrainStation/hellowWorld.png)

This is the single code shared across those platforms:

![Hello World! Code](://stvansolano.github.io/2016/01/04/Workshop-de-Xamarin-4-en-BrainStation/helloWorldCode.png)

## Additional resources & links.
- [Introducing Xamarin 4](https://blog.xamarin.com/introducing-xamarin-4/)
- [Xamarin Forms Reference](https://developer.xamarin.com/guides/xamarin-forms/controls/)
- [Getting Xamarin license](https://developer.xamarin.com/guides/cross-platform/getting_started/beginning_a_xamarin_trial/)
- [Xamarin Test Cloud](https://testcloud.xamarin.com/)
- [Adding Material Design to Xamarin Apps](https://blog.xamarin.com/introduction-to-android-material-design/)
- [Comunidad Xamarin Costa Rica Mobile .Net Dev Group](http://xamarin.meetup.com/es-ES/)