<div id="top"></div>

<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/pippinmole/GetChain">
    <img src="https://github.com/pippinmole/GetChain/blob/main/product/logo/getchain-logo.png" alt="Logo" width="20%" >
  </a>

<h3 align="center">GetChain</h3>

  <p align="center">
    Monitor your Helium miners' uptime and get notified when they go down!
    <br />
    <a href="https://getchain.dev/api/v1/index.html"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://getchain.dev/">View Demo</a>
    ·
    <a href="https://github.com/pippinmole/GetChain/issues">Report Bug</a>
    ·
    <a href="https://github.com/pippinmole/GetChain/issues">Request Feature</a>
  </p>
</div>

<!-- ABOUT THE PROJECT -->
## About The Project

<p align="center">
<img src="images/site-screenshot.png" align="center" alt="Logo" width="2862" >
</p>

This website aggregates blockchain data from these blockchains:
1. Binance Smart Chain
2. Ethereum Chain
3. Goerli
4. Kovan
5. Rinkeby
6. Ropsten

into a single API endpoint and API key, mitigating the need to generate multiple API keys from different providers.

<p align="right">(<a href="#top">back to top</a>)</p>

### Built With

* [Razor Pages](https://learn.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-7.0&tabs=visual-studio)
* [Serilog](https://serilog.net/)
* [reCAPTCHA](https://www.google.com/recaptcha/about/)
* [MongoDB](https://www.mongodb.com/)
* [Bootstrap](https://getbootstrap.com)
* [JQuery](https://jquery.com)

<p align="right">(<a href="#top">back to top</a>)</p>

<!-- GETTING STARTED -->
## Getting Started

To get a local copy up and running follow these simple example steps.

### Installation

1. Clone the repository
   ```sh
   https://github.com/pippinmole/GetChain.git
   ```
2. Restore packages
   ```sh
   dotnet restore
   ```
    3. Set up user secrets
   ```sh
    dotnet user-secrets init
    dotnet user-secrets set "ApiKeys:BscScanKey" ""
    dotnet user-secrets set "ApiKeys:EtherScanKey" ""
    dotnet user-secrets set "ApiKeys:GoerliKey" ""
    dotnet user-secrets set "ApiKeys:KovanKey" ""
    dotnet user-secrets set "ApiKeys:RinkebyKey" ""
    dotnet user-secrets set "ApiKeys:RopstenKey" ""
    dotnet user-secrets set "ConnectionStrings:DatabaseConnectionString" "<Get this from your MongoDB dashboard>"
    dotnet user-secrets set "Jwt:Issuer" ""
    dotnet user-secrets set "Jwt:Secret" ""
    dotnet user-secrets set "MailSenderOptions:AddressFrom" "<The domain emails will come from>"
    dotnet user-secrets set "MailSenderOptions:Password" "<Get this from your MailGun dashboard>"
    dotnet user-secrets set "MailSenderOptions:Port" "<Get this from your MailGun dashboard>"
    dotnet user-secrets set "MailSenderOptions:SmtpHostAddress" "<Get this from your MailGun dashboard>"
    dotnet user-secrets set "Serilog:Datadog:ApiKey" "<Get this from your DataDog dashboard>"
    ```
4. Build the solution
   ```sh
   dotnet build
   ```
5. Finally, run
   ```sh
   dotnet run
   ```

<p align="right">(<a href="#top">back to top</a>)</p>

## Usage

Once you have executed ``dotnet run`` , a website at https://localhost:7086/ will be available. This site allows you to:
1. Create an account and sign in
2. Generate multiple API keys
3. Perform HTTP requests to the API using the API key as authentication

<p align="right">(<a href="#top">back to top</a>)</p>


<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` for more information.

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- CONTACT -->
## Contact

E-mail: jonathan.ruffles03@gmail.com

Project Link: [https://github.com/pippinmole/GetChain](https://github.com/pippinmole/GetChain)

<p align="right">(<a href="#top">back to top</a>)</p>



[//]: # (<!-- ACKNOWLEDGMENTS -->)

[//]: # (## Acknowledgments)

[//]: # ()
[//]: # (Use this space to list resources you find helpful and would like to give credit to. I've included a few of my favorites to kick things off!)

[//]: # ()
[//]: # (* [Choose an Open Source License]&#40;https://choosealicense.com&#41;)

[//]: # (* [GitHub Emoji Cheat Sheet]&#40;https://www.webpagefx.com/tools/emoji-cheat-sheet&#41;)

[//]: # (* [Malven's Flexbox Cheatsheet]&#40;https://flexbox.malven.co/&#41;)

[//]: # (* [Malven's Grid Cheatsheet]&#40;https://grid.malven.co/&#41;)

[//]: # (* [Img Shields]&#40;https://shields.io&#41;)

[//]: # (* [GitHub Pages]&#40;https://pages.github.com&#41;)

[//]: # (* [Font Awesome]&#40;https://fontawesome.com&#41;)

[//]: # (* [React Icons]&#40;https://react-icons.github.io/react-icons/search&#41;)

[//]: # (<p align="right">&#40;<a href="#top">back to top</a>&#41;</p>)



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[stars-shield]: https://img.shields.io/github/stars/pippinmole/GetChain.svg?style=for-the-badge
[stars-url]: https://github.com/pippinmole/GetChain/stargazers
[issues-shield]: https://img.shields.io/github/issues/pippinmole/GetChain.svg?style=for-the-badge
[issues-url]: https://github.com/pippinmole/GetChain/issues
[license-shield]: https://img.shields.io/github/license/pippinmole/GetChain.svg?style=for-the-badge
[license-url]: https://github.com/pippinmole/GetChain/blob/master/LICENSE
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/jonathan-ruffles-b44b30196/
[product-screenshot]: images/screenshot.png
