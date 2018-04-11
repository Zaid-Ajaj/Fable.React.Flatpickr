module App.View

open App.Types

open Fulma
open Fulma.Elements
open Fulma.Components
open Fulma.Layouts
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Core.JsInterop

let menuItem page current label dispatch =
    li [ Common.classes [ "is-active", current = page ]; 
         OnClick (fun _ -> dispatch (View page)) ]
       [ a [ ] [ str label ] ]

let sidebar state dispatch = 
    Menu.menu [ ] 
        [ img [ Src "https://fable-elmish.github.io/elmish/img/logo.png" ] 
          Menu.label [ ] [ str "General" ]
          Menu.list [ ] 
               [ menuItem Introduction state.CurrentPage "Introduction" dispatch
                 menuItem Usage state.CurrentPage "Usage" dispatch ] ]

let introduction = 
    div [ ]  
        [ h1 [ Style [ FontSize 30 ] ] [ str "Fable.React.Flatpickr" ]
          hr [ ] 
          p  [ ] [ str "Fable binding for react-flatpickr that is ready to use within Elmish applications" ] ]

let main state dispatch = 
    match state.CurrentPage with 
    | Introduction -> introduction 
    | Usage -> Components.Flatpickr.View.render state.Flatpickr (FlatpickrMsg >> dispatch)

let spacing = Props.Style [ Props.Padding 20 ]

let render (state: State) dispatch = 
    Columns.columns [ ] 
        [ Column.column [ Column.Width (Column.All, Column.Is2) ] 
                        [ div [ spacing ] [ sidebar state dispatch ] ] 
          Column.column [ Column.Width (Column.All, Column.Is7) ] 
                        [ div [ spacing ] [ main state dispatch ]  ] ]