# DogApi
This repo contains the Dog Api solution.

 
---

# Table of Contents

* [Features](#features)
* [Prerequisites](#prerequisites)
* [Installation - Getting Started!](#installation)
* [Special Thanks](#special-thanks)

# Features

- **ASP.NET Core 2.0**
  - Web API
- **VueJS 2**
  - Vuex (State Store)
- **Webpack 2**
  - HMR (Hot Module Replacement/Reloading)

# Prerequisites:
 * nodejs > 6
 * VS2017
 * dotnet core 2.0

# Installation / Getting Started:
 * Clone this repo
 * At the repo's root directory run `dotnet restore`
 * Restore Node dependencies by running `npm install`
 * Run the application (`dotnet run` or `npm run dev`)
 
 or
 
 * Run the application in VSCode or Visual Studio 2017 (Hit `F5`)

 * If no data present you might have to run migrations/seed.
 * - dotnet ef database update

For deploying to web server I used this guide to build docker image to a free heroku.
https://blog.devcenter.co/deploy-asp-net-core-2-0-apps-on-heroku-eea8efd918b6

# Extras

- Get Chrome DevTools for Vue [here](https://chrome.google.com/webstore/detail/vuejs-devtools/nhdogjmejiglipccpnnnanhbledajbpd)


# Found a Bug? Want to Contribute?

If you have any good ideas, or want to contribute, feel free to either make an Issue with the Proposal, or just make a PR from your Fork.

----

### Special Thanks

This repo contains an aspnetcore + Vue.js 2 starter template (VS2017). 
