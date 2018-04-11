module Components.Flatpickr.View

open Components.Flatpickr.Types

open Fable.Helpers.React
open Fable.Helpers.React.Props
open System

let render (state: State) dispatch = 
    div [ ] 
        [ p [ ] [ str "Basic Flatpicker witout config:" ]
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
              Flatpickr.HideCalendar true
              Flatpickr.EnableTimePicker true
              Flatpickr.Value DateTime.Now ] 
          br [ ]
          br [ ]
          Common.highlight """Flatpickr.flatpickr 
    [ Flatpickr.ClassName "input"
      Flatpickr.HideCalendar true
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
      Flatpickr.Value DateTime.Now ] """
          br [ ]
          p [ ] [ str "Enable week numbers on calendar" ]
          Flatpickr.flatpickr 
            [ Flatpickr.ClassName "input"
              Flatpickr.EnableTimePicker true
              Flatpickr.EnableWeekNumbers true
              Flatpickr.Value DateTime.Now ] 
          br [ ]
          br [ ]
          Common.highlight """Flatpickr.flatpickr 
    [ Flatpickr.ClassName "input"
      Flatpickr.EnableTimePicker true
      Flatpickr.EnableWeekNumbers true
      Flatpickr.Value DateTime.Now ] """
          br [ ]
          p [ ] [ str "Disable specific dates" ]
          Flatpickr.flatpickr 
            [ Flatpickr.ClassName "input"
              Flatpickr.DisableDates [DateTime.Now.AddDays(-1.0); DateTime.Now; DateTime.Now.AddDays(1.0) ] ] 
          br [ ]
          br [ ]
          Common.highlight """Flatpickr.flatpickr 
    [ Flatpickr.ClassName "input"
      Flatpickr.DisableDates 
        [ DateTime.Now.AddDays(-1.0)
          DateTime.Now
          DateTime.Now.AddDays(1.0) ] ]"""
          br [ ]
          p [ ] [ str "Disable specific date ranges" ]
          Flatpickr.flatpickr 
            [ Flatpickr.ClassName "input"
              Flatpickr.DisableRanges 
                [ DateTime.Now.AddDays(-1.0), DateTime.Now.AddDays(1.0)
                  DateTime.Now.AddDays(10.0), DateTime.Now.AddDays(15.0) ] ] 
          br [ ]
          br [ ]
          Common.highlight """Flatpickr.flatpickr 
    [ Flatpickr.ClassName "input"
      Flatpickr.DisableRanges 
        [ DateTime.Now.AddDays(-1.0), DateTime.Now.AddDays(1.0)
          DateTime.Now.AddDays(10.0), DateTime.Now.AddDays(15.0) ] ] """
          br [ ]
          p [ ] [ str "Disable dates by a generic predicate" ]
          Flatpickr.flatpickr 
            [ Flatpickr.ClassName "input"
              Flatpickr.DisableBy (fun date -> date.DayOfWeek = DayOfWeek.Sunday) ] 
          br [ ]
          br [ ]
          Common.highlight """Flatpickr.flatpickr 
    [ Flatpickr.ClassName "input"
      Flatpickr.DisableBy (fun date -> date.DayOfWeek = DayOfWeek.Sunday) ]"""
          br [ ]
          p [ ] [ str "Enable the dates that pass a certain criteria" ]
          Flatpickr.flatpickr 
            [ Flatpickr.ClassName "input"
              Flatpickr.EnableBy (fun date -> date.DayOfWeek = DayOfWeek.Sunday 
                                           || date.DayOfWeek = DayOfWeek.Saturday) ] 
          br [ ]
          br [ ]
          Common.highlight """Flatpickr.flatpickr 
    [ Flatpickr.ClassName "input"
      Flatpickr.EnableBy (fun date -> date.DayOfWeek = DayOfWeek.Sunday 
                                   || date.DayOfWeek = DayOfWeek.Saturday) ]"""
          br [ ]
          p [ ] [ str "Change selection mode to multple (then use OnManyChanged event handler)" ]
          Flatpickr.flatpickr 
            [ Flatpickr.ClassName "input"
              Flatpickr.SelectionMode Flatpickr.Mode.Multiple
              Flatpickr.OnManyChanged (fun x -> Fable.Import.Browser.console.log(x)) ] 
          br [ ]
          br [ ]
          Common.highlight """Flatpickr.flatpickr 
    [ Flatpickr.ClassName "input"
      Flatpickr.SelectionMode Flatpickr.Mode.Multiple
      Flatpickr.OnManyChanged (fun (dates: list<DateTime>) -> (* do stuff *)) ]"""
          br [ ]
          p [ ] [ str "Change selection mode to range (then use OnManyChanged event handler)" ]
          Flatpickr.flatpickr 
            [ Flatpickr.ClassName "input"
              Flatpickr.SelectionMode Flatpickr.Mode.Range
              Flatpickr.OnManyChanged (fun x -> Fable.Import.Browser.console.log(x)) ] 
          br [ ]
          br [ ]
          Common.highlight """Flatpickr.flatpickr 
    [ Flatpickr.ClassName "input"
      Flatpickr.SelectionMode Flatpickr.Mode.Range
      Flatpickr.OnManyChanged (fun (dates: list<DateTime>) -> 
           match dates with 
           | [ singleChoice ] -> unit 
           | [ fromDate; toDate ] -> doSomethingInteresting
           | moreValues -> (* you get the idea *)) ]""" ]
          