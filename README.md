# Toasty
<div align="center">
	<img src="https://raw.githubusercontent.com/GrenderG/Toasty/master/art/web_hi_res_512.png" width="128">
</div>

The usual Toast, but with steroids (ported from https://github.com/GrenderG/Toasty) . **(Screenshots at the end of the file.)**

Add AndToasty to your references in Xamarin.Android project

Usage
--

Each method always returns a `Toast` object, so you can customize the Toast much more. **DON'T FORGET THE `Show()` METHOD!**

To display an error Toast:

``` C#
Toasty.Error(yourContext, "This is an error toast.").Show();
```
To display a success Toast:

``` C#
Toasty.Success(yourContext, "Success!").show();
```
To display an info Toast:

``` C#
Toasty.Info(yourContext, "Here is some info for you.").Show();
```
To display a warning Toast:

```  C#
Toasty.Warning(yourContext, "Beware of the dog.").Show();
```
To display the usual Toast:

```  C#
Toasty.Normal(yourContext, "Normal toast w/o icon").Show();
```
To display the usual Toast with icon:

```  C#
Toasty.Normal(yourContext, "Normal toast w/ icon", yourIconDrawable).Show();
```

You can also create your custom Toasts with the `custom()` method:
```  C#
Toasty.Custom(yourContext, "I'm a custom Toast", yourIconDrawable, textColor, tintColor, duration, withIcon, true).Show();
```

There are variants of each method, feel free to explore this library.

Screenshots
--

<img src="https://raw.githubusercontent.com/GrenderG/Toasty/master/art/scr1.png" width="250">
<img src="https://raw.githubusercontent.com/GrenderG/Toasty/master/art/scr2.png" width="250">
<img src="https://raw.githubusercontent.com/GrenderG/Toasty/master/art/scr3.png" width="250">
<img src="https://raw.githubusercontent.com/GrenderG/Toasty/master/art/scr4.png" width="250">
<img src="https://raw.githubusercontent.com/GrenderG/Toasty/master/art/scr5.png" width="250">
<img src="https://raw.githubusercontent.com/GrenderG/Toasty/master/art/scr6.png" width="250">
