module Components.Flatpickr.View

open Components.Flatpickr.Types

open Fable.Helpers.React
open Fable.Helpers.React.Props
open System

let render (state: State) dispatch = 
    div [ ] 
        [ h1 [ ] [ str "Flatpickr" ]
          hr [ ] 
          p [ ] [ str "Basic Flatpicker witout config:" ]
          Flatpickr.flatpickr [ ]
          br [ ] 
          br [ ] 
          Common.highlight "Flatpickr.flatpickr [ ]" 
          br [ ]
          p [ ] [ str "Using a default value" ] 
          Flatpickr.flatpickr 
            [ Flatpickr.Value DateTime.Now 
              Flatpickr.OnChange (UpdateSelectedTime >> dispatch)  ]
          br [ ]
          br [ ]
          Common.highlight """Flatpickr.flatpickr 
    [ Flatpickr.Value DateTime.Now
      Flatpickr.OnChange (UpdateSelectedTime >> dispatch)  ]""" 
          br [ ]
          p [ ] [ str "Customizing the input with ClassName" ] 
          Flatpickr.flatpickr 
            [ Flatpickr.ClassName "input"
              Flatpickr.OnChange (UpdateSelectedTime >> dispatch)  ]
          br [ ]
          br [ ]
          Common.highlight "Flatpickr.flatpickr [ Flatpickr.ClassName \"input\" ]"
          br [ ] 
          p [ ] [ str "Disabling user input" ]
          Flatpickr.flatpickr 
            [ Flatpickr.ClassName "input"
              Flatpickr.Disabled true
              Flatpickr.Value DateTime.Now
              Flatpickr.OnChange (UpdateSelectedTime >> dispatch) ] 
          br [ ]
          br [ ]
          Common.highlight """Flatpickr.flatpickr 
            [ Flatpickr.ClassName "input"
              Flatpickr.Disabled true
              Flatpickr.Value DateTime.Now
              Flatpickr.OnChange (UpdateSelectedTime >> dispatch) ]""" ]
          