module App.State 

open App.Types
open Elmish

let init() = 
    let initFlatpickrState, initFlatpickrCmd = Components.Flatpickr.State.init()
    
    { CurrentPage = Introduction
      Flatpickr = initFlatpickrState }, Cmd.batch [ Cmd.none ]

let update msg state = 
    match msg with 
    | View page -> { state with CurrentPage = page }, Cmd.none
    | FlatpickrMsg msg -> 
        let nextFlatpickrState, nextFlatpickrCmd = 
            Components.Flatpickr.State.update msg state.Flatpickr 
        let nextState = { state with Flatpickr = nextFlatpickrState }
        nextState, Cmd.map FlatpickrMsg nextFlatpickrCmd