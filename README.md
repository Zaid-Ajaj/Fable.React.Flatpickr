# Fable.React.Flatpickr [![Build Status](https://travis-ci.org/Zaid-Ajaj/Fable.React.Flatpickr.svg?branch=master)](https://travis-ci.org/Zaid-Ajaj/Fable.React.Flatpickr) [![Nuget](https://img.shields.io/nuget/v/Fable.React.Flatpickr.svg?maxAge=0&colorB=brightgreen)](https://www.nuget.org/packages/Fable.React.Flatpickr)


A complete binding for [react-flatpickr](https://github.com/coderhaoxin/react-flatpickr) that is ready to use within [Elmish](https://github.com/fable-elmish/elmish) applications

## Installation
- Install this library from nuget
```
paket add Fable.React.Flatpickr --project /path/to/Project.fsproj
```
- Install the actual Flatpickr library from npm
```
npm install flatpickr react-flatpickr --save
```
- You will also need css module loaders for Webpack because we are going to import the styles directly from npm `css-loader` and `style-loader`, install them :
```
npm install css-loader style-loader --save-dev
```
- Now from your Webpack, use the loaders:
```
{
    test: /\.(sa|c)ss$/,
    use: [
        "style-loader",
        "css-loader"
    ]
}
```

## Usage 

[Live Demo with examples](https://zaid-ajaj.github.io/Fable.React.Flatpickr/)

```fs
type State = { SelectedTime : DateTime }

type Msg = UpdateSelectedTime of DateTime 

let init() = { SelectedTime = DateTime.Now }, Cmd.none

let update msg state = 
    match msg with 
    | UpdateSelectedTime time ->
        let nextState = { state with SelectedTime = time }
        nextState, Cmd.none

let render state dispatch = 
    Flatpickr.flatpickr 
        [ Flatpickr.Value state.SelectedTime 
          Flatpickr.OnChange (UpdateSelectedTime >> dispatch)
          Flatpickr.ClassName "input" ]


// Somewhere before you app starts
// you must import the CSS theme

importAll "flatpickr/dist/themes/material_green.css"

// or any of the other themes in the dist directory of flatpickr
```