#Xamarin 4 Workshop

## Getting Xamarin installed

## Recommended Emulators for Android
[Xamarin Android Player](https://xamarin.com/android-player)
[Genymotion](https://www.genymotion.com/#!/download)

## Developing a Xamarin.Forms app from scratch
Pick the Xamarin.Forms template from the available list inside Visual Studio/Xamarin Studio:

![setup](http://stvansolano.github.io/2015/12/01/Xamarin4-has-everything-you-need-to-create-great-mobile-apps/setup.png)

In Visual Studio:  New Project -> Installed -> Visual C# -> Cross-Platform -> Blank App (Xamarin.Forms Portable)
In Xamarin Studio: File -> New -> Solution -> Cross-platform -> App -> Xamarin.Forms App (Use Portable Class Library)
Set project name to "MobileWorkshop"

By doing so will get:
- A Xamarin.Forms project for sharing XAML/C# code between platforms
- Android project referencing Xamarin.Forms
- iOS project
- UWP project

Then let's use a MVVM folder structure like the following

![structure](http://stvansolano.github.io/2015/12/01/Xamarin4-has-everything-you-need-to-create-great-mobile-apps/structure.png)

## Adding  Material Design to your Android application 
 Xamarin for Android allows you to easily incorporate *Material Design* into your Android apps. This can be done by adding the [Support Design Library](https://components.xamarin.com/gettingstarted/xamandroidsupportdesign) available as a package from NuGet.

## Additional resources & links.
[Introducing Xamarin 4](https://blog.xamarin.com/introducing-xamarin-4/)

[Adding Material Design to Xamarin Apps](https://blog.xamarin.com/introduction-to-android-material-design/)

[Lucky Winner source code](https://github.com/stvansolano/lucky-winner)
