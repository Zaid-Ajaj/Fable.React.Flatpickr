module App.View

open App.Types

open Fulma
open Fable.React
open Fable.React.Props
open Fable.Core.JsInterop


let introduction =
    div [ ]
        [ h1 [ Style [ FontSize 30 ] ] [ str "Fable.React.Flatpickr" ]
          p  [ ] [ str "Fable binding for react-flatpickr that is ready to use within Elmish applications" ]
          br [ ]
          Common.highlight """type State = { SelectedTime : DateTime }

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
          """
          br [ ]
          hr [ ]
          h1 [ Style [ FontSize 30 ] ] [ str "Examples and configurations" ]
          br [ ] ]

let spacing = Props.Style [ Props.Padding 20 ]

let render (state: State) dispatch =
  div [ Style [ Padding 20.0 ] ] [
    Components.Flatpickr.View.render state.Flatpickr (FlatpickrMsg >> dispatch)
  ]
  