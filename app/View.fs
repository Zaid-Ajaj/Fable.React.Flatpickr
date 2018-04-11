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
                 menuItem Contributing state.CurrentPage "Contributing" dispatch ]
          Menu.label [ ] [ str "Components" ]
          Menu.list  [ ]  
               [ menuItem Flatpickr state.CurrentPage "Flatpickr" dispatch ] ] 

let introduction = 
    div [ ]  
        [ h1 [ ] [ str "Elmish Components" ]
          hr [ ] 
          p  [ ] [ str "Elmish components is an effort of porting many React components to high-quality Elmish components that are well documented and easy to showcase." ] ]

let contributing = 
    div [ ]  
        [ h1 [ ] [ str "Contributing" ]
          hr [ ] ]

let main state dispatch = 
    match state.CurrentPage with 
    | Introduction -> introduction 
    | Contributing -> contributing
    | Flatpickr -> Components.Flatpickr.View.render state.Flatpickr (FlatpickrMsg >> dispatch)

let spacing = Props.Style [ Props.Padding 20 ]

let render (state: State) dispatch = 
    Columns.columns [ ] 
        [ Column.column [ Column.Width (Column.All, Column.Is2) ] 
                        [ div [ spacing ] [ sidebar state dispatch ] ] 
          Column.column [ Column.Width (Column.All, Column.Is7) ] 
                        [ div [ spacing ] [ main state dispatch ]  ] ]