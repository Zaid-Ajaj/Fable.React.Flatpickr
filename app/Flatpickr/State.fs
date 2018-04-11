module Components.Flatpickr.State

open System
open Elmish
open Components.Flatpickr.Types

let init() = { SelectedTime = DateTime.Now }, Cmd.none

let update msg state = 
    match msg with 
    | UpdateSelectedTime time ->
        let nextState = { state with SelectedTime = time }
        nextState, Cmd.none