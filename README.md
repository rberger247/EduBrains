# EduBrains


### Adding facebook login

navigate to facebook [developer tutorial](https://developers.facebook.com/docs/apps/register)
and [here](https://developers.facebook.com/)

*  In package manager Install-Package Microsoft.Owin.Security.Facebook
* https://stackoverflow.com/questions/46850461/cant-load-url-the-domain-of-this-url-isnt-included-in-the-apps-domains-in-fa
* update newtonsoft.json



### Adding Paypal 

* Add nuget package called Paypal
* add to webConfig
```

  <paypal>
    <settings>
      <add name="mode" value="sandbox" />
      <add name="clientId" value="" />
      <add name="clientSecret" value="" />
    </settings>
  </paypal>
  
  ```
