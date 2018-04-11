module Components.Flatpickr.Types

open System 

type State = {
    SelectedTime : DateTime 
}

type Msg = 
    | UpdateSelectedTime of DateTime 