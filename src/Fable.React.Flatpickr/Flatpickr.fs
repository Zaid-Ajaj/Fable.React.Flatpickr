[<RequireQualifiedAccess>]
module Flatpickr

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Core.JsInterop
open Fable.Core
open System

type IFlatpickrOption = interface end

[<Pojo>]
type private OptionType = {
    Value : obj
    Key : string
    IsConfig : bool
}

[<Pojo>]
type private DateRange = { 
    ``to``: DateTime 
    from: DateTime
}


[<Emit("$2[$0] = $1")>]
let private setProp (propName: string) (propValue: obj) (any: obj) : unit = jsNative
[<Emit("$0")>]
let private typed<'a> (x: obj) : 'a = jsNative
[<Emit("$0[$1]")>]
let private getAs<'a> (x: obj) (key: string) : 'a = jsNative

/// Sets the initial value for the Flatpickr component
let Value (date: DateTime) = 
    { Value = date; IsConfig = false; Key = "value" }
    |> unbox<IFlatpickrOption> 

/// Determines whether or not the date picker also contains a time picker
let EnableTimePicker (cond: bool) =  
    { Value = cond; IsConfig = true; Key = "enableTime" }
    |> unbox<IFlatpickrOption>    

/// Enables seconds in the time picker
let EnableSecondsPicker (cond: bool) =  
    { Value = cond; IsConfig = true; Key = "enableSeconds" }
    |> unbox<IFlatpickrOption>  

/// The minimum date that a user can start picking from (inclusive).
let MinimumDate (date: DateTime) =  
    { Value = date; IsConfig = true; Key = "minDate" }
    |> unbox<IFlatpickrOption> 

/// The minimum date that a user can start picking from (inclusive).
let MaximumDate (date: DateTime) =  
    { Value = date; IsConfig = true; Key = "maxDate" }
    |> unbox<IFlatpickrOption> 

/// Sets the initial value of the hour element (12 by default) 
let DefaultHour (hour: int) =  
    { Value = hour; IsConfig = true; Key = "defaultHour" }
    |> unbox<IFlatpickrOption> 

/// Sets the initial value of the minute element (0 by default) 
let DefaultMinute (min: int) =  
    { Value = min; IsConfig = true; Key = "defaultMinute" }
    |> unbox<IFlatpickrOption> 

/// Enables display of week numbers in calendar.
let EnableWeekNumbers (cond: bool) =  
    { Value = cond; IsConfig = true; Key = "weekNumbers" }
    |> unbox<IFlatpickrOption> 

/// Registers an event handler for Flatpickr that is triggered when the user selects a new datetime value 
let OnChange (callback: DateTime -> unit) =  
    { Value = unbox (fun (dates: DateTime[]) -> callback dates.[0]); 
      IsConfig = false;
      Key = "onChange" }
    |> unbox<IFlatpickrOption>

/// Defines the class attribute for the Flatpickr element. Keep in mind that Flatpickr is implmented as wrapper around an `<input />` element. 
let ClassName name = 
    { Value = name; IsConfig = false; Key = "className" }
    |> unbox<IFlatpickrOption>

/// Defines the inline styles of the Flatpickr element
let Style (props: CSSProp list) = 
    { Value = keyValueList CaseRules.LowerFirst props; IsConfig = false; Key = "style" }
    |> unbox<IFlatpickrOption>

/// Defines whether or not the Flatpickr element is disabled.
let Disabled (value: bool) = 
    { Value = value; IsConfig = false; Key = "disabled" }
    |> unbox<IFlatpickrOption>

/// Defines how the date is displayed on the component
let DateFormat (value: string) = 
    { Value = value; IsConfig = true; Key = "dateFormat" }
    |> unbox<IFlatpickrOption>

/// Hides the calendar so that users cannot select dates
let HideCalendar (value: bool) = 
    { Value = value; IsConfig = true; Key = "noCalendar" }
    |> unbox<IFlatpickrOption>    

/// If set to true, makes sure that the picker is always set shown to the user
let AlwaysOpen (value: bool) = 
    { Value = value; IsConfig = true; Key = "inline" }
    |> unbox<IFlatpickrOption> 

/// Disallow the user to select the given dates 
let DisableDates (dates: list<DateTime>) = 
    let datesArray = Array.ofList dates 
    { Value = datesArray; IsConfig = true; Key = "disable" }
    |> unbox<IFlatpickrOption> 

/// Disallow the user to select the dates using a predicate
let DisableBy (pred: DateTime -> bool) = 
    { Value = [| pred |]; IsConfig = true; Key = "disable" }
    |> unbox<IFlatpickrOption> 

/// Disallow the user to select the dates that are between the given ranges
let DisableRanges (ranges: list<DateTime * DateTime>) =
    let rangeObjects = 
        ranges 
        |> List.map (fun (fromDate, toDate) -> 
            let range = obj() 
            setProp "to" toDate range
            setProp "from" fromDate range
            range)
        |> Array.ofList
    { Value = rangeObjects; IsConfig = true; Key = "disable" }
    |> unbox<IFlatpickrOption> 

/// Enable only the given list of dates
let EnableDates (dates: list<DateTime>) = 
    let datesArray = Array.ofList dates 
    { Value = datesArray; IsConfig = true; Key = "enable" }
    |> unbox<IFlatpickrOption> 

/// Enable only the dates that pass a given criteria
let EnableBy (pred: DateTime -> bool) = 
    { Value = [| pred |]; IsConfig = true; Key = "enable" }
    |> unbox<IFlatpickrOption> 

/// Enable only the given list of date ranges
let EnableRanges (ranges: list<DateTime * DateTime>) =
    let rangeObjects = 
        ranges 
        |> List.map (fun (fromDate, toDate) -> 
            let range = obj() 
            setProp "to" toDate range
            setProp "from" fromDate range
            range)
        |> Array.ofList
    { Value = rangeObjects; IsConfig = true; Key = "enable" }
    |> unbox<IFlatpickrOption> 


/// Initializes Flatpickr, a lightweight DateTime picker. 
let flatpickr (options: IFlatpickrOption list) = 
    let props = obj() 
    let propOptions = obj() 
    
    for option in unbox<list<OptionType>> options do
        if option.IsConfig
        then setProp option.Key option.Value propOptions
        else setProp option.Key option.Value props 
    
    setProp "options" propOptions props 
    ofImport "default" "react-flatpickr" props [ ]
    
 