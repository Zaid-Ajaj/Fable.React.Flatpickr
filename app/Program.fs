module Program

open Elmish
open Elmish.React
open Fable.Core.JsInterop
importAll "bulma/css/bulma.css"
importAll "flatpickr/dist/themes/material_green.css"
importAll "highlight.js/styles/ocean.css"

open App.State
open App.View

Program.mkProgram init update render
|> Program.withConsoleTrace
|> Program.withReactSynchronous "elmish-app"
|> Program.run