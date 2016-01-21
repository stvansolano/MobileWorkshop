
#Xamarin 4 Workshop

## Requirements

System requirements: 
https://developer.xamarin.com/guides/xamarin-forms/getting-started/installation/

## Getting Xamarin installed
Install Xamarin platform.

- For Windows/Mac: [https://xamarin.com/download](https://xamarin.com/download)
- Or you can get it incorporated as part of Visual Studio 2015:  [VS 2015 Community Edition](https://www.visualstudio.com/en-us/downloads/download-visual-studio-vs.aspx)

### Recommended Emulators for Android

- Xamarin Android Player [download link](https://xamarin.com/android-player)
- Genymotion [download link](https://www.genymotion.com/#!/download)

## Developing a Xamarin.Forms app from scratch

In Visual Studio:

- *New Project -> Installed -> Visual C# -> Cross-Platform -> Blank App (Xamarin.Forms Portable)*

In Xamarin Studio:

- *File -> New -> Solution -> Cross-platform -> App -> Xamarin.Forms App (Use Portable Class Library)*

![Setup](http://stvansolano.github.io/2016/01/04/Workshop-de-Xamarin-4-en-BrainStation/setup.png)

Let's inspect the App.cs main code that which is responsible for supporting the UI for all the platforms running our app:

By doing so will get:

- A Xamarin.Forms project for sharing XAML/C# code between platforms
- Android project referencing Xamarin.Forms
- iOS project
- UWP project

Let's set the project structure to be used later in this tutorial:

![structure](http://stvansolano.github.io/2016/01/04/Workshop-de-Xamarin-4-en-BrainStation/structure.png)

## Hello World, Xamarin.Forms!

![Hello World!](http://stvansolano.github.io/2016/01/04/Workshop-de-Xamarin-4-en-BrainStation/helloWorld.png)

This is the single code shared across those platforms:

![Hello World! Code](http://stvansolano.github.io/2016/01/04/Workshop-de-Xamarin-4-en-BrainStation/helloWorldCode.png)

## Bringing Material Design for your Android app

### Adding Material Design basics
For basic Material Design do the following:

- Include values/colors.xml file under the Android.csproj /Resources folder
- Include values/style.xml file under the Android.csproj /Resources folder
- Include values-v21/style.xml file under the Android.csproj /Resources folder
- Use *Xamarin.Forms.Platform.Android.FormsAppCompatActivity* for MainActivity instead.

### Adding Connectivity (aka WebServices):

- Add Connectivity NuGet package (Xam.Plugin.Connectivity)
*In Xamarin Studio:* 

PCL -> Packages folder section-> Add Package -> Xam.Plugin.Connectivity

## Additional resources & links.
- [Introducing Xamarin 4](https://blog.xamarin.com/introducing-xamarin-4/)
- [Xamarin Forms Reference](https://developer.xamarin.com/guides/xamarin-forms/controls/)
- [Getting Xamarin license](https://developer.xamarin.com/guides/cross-platform/getting_started/beginning_a_xamarin_trial/)
- [Xamarin Test Cloud](https://testcloud.xamarin.com/)
- [Comunidad Xamarin Costa Rica Mobile .Net Dev Group](http://xamarin.meetup.com/es-ES/)

### Android Material Design links

- [Adding Material Design to Xamarin.Forms Apps](https://blog.xamarin.com/material-design-for-your-xamarin-forms-android-apps/)
- [Material Design for Android apps](https://blog.xamarin.com/introduction-to-android-material-design/)
- [Extending the Android ToolBar](https://blog.xamarin.com/android-tips-hello-toolbar-goodbye-action-bar/)
