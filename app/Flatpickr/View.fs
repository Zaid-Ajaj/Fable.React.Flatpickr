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
          p [ ] [ str "Pre-select a default value" ] 
          Flatpickr.flatpickr 
            [ Flatpickr.Value DateTime.Now 
              Flatpickr.OnChange (UpdateSelectedTime >> dispatch)  ]
          br [ ]
          br [ ]
          Common.highlight """Flatpickr.flatpickr [ Flatpickr.Value DateTime.Now ]""" 
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
      Flatpickr.Value DateTime.Now ]"""
          br [ ] 
          p [ ] [ str "Enable time to show a time picker as well" ]
          Flatpickr.flatpickr 
            [ Flatpickr.ClassName "input"
              Flatpickr.EnableTimePicker true
              Flatpickr.Value DateTime.Now ] 
          br [ ]
          br [ ]
          Common.highlight """Flatpickr.flatpickr 
    [ Flatpickr.ClassName "input"
      Flatpickr.EnableTimePicker true
      Flatpickr.Value DateTime.Now ]"""
          br [ ] 
          p [ ] [ str "Use a custom date format" ]
          Flatpickr.flatpickr 
            [ Flatpickr.ClassName "input"
              Flatpickr.DateFormat "d.m.Y"
              Flatpickr.Value DateTime.Now ] 
          br [ ]
          br [ ]
          Common.highlight """Flatpickr.flatpickr 
    [ Flatpickr.ClassName "input"
      Flatpickr.DateFormat "d.m.Y"
      Flatpickr.Value DateTime.Now ]"""
          br [ ]
          p [ ] [ str "Hide calender and only select time" ]
          Flatpickr.flatpickr 
            [ Flatpickr.ClassName "input"
              Flatpickr.HideCalender true
              Flatpickr.EnableTimePicker true
              Flatpickr.Value DateTime.Now ] 
          br [ ]
          br [ ]
          Common.highlight """Flatpickr.flatpickr 
    [ Flatpickr.ClassName "input"
      Flatpickr.HideCalender true
      Flatpickr.EnableTimePicker true
      Flatpickr.Value DateTime.Now ]"""
          br [ ]
          p [ ] [ str "Customize a min/max range for selection" ]
          Flatpickr.flatpickr 
            [ Flatpickr.ClassName "input"
              Flatpickr.MinimumDate (DateTime.Now.AddDays(-5.0))
              Flatpickr.MaximumDate (DateTime.Now.AddDays(5.0))
              Flatpickr.EnableTimePicker true
              Flatpickr.Value DateTime.Now ] 
          br [ ]
          br [ ]
          Common.highlight """Flatpickr.flatpickr 
    [ Flatpickr.ClassName "input"
      Flatpickr.MinimumDate (DateTime.Now.AddDays(-5.0))
      Flatpickr.MaximumDate (DateTime.Now.AddDays(5.0))
      Flatpickr.EnableTimePicker true
      Flatpickr.Value DateTime.Now ] """ ]
          