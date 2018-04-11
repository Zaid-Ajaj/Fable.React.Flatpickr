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

/// Hides the calender so that users cannot select dates
let HideCalender (value: bool) = 
    { Value = value; IsConfig = true; Key = "noCalendar" }
    |> unbox<IFlatpickrOption>    

/// If set to true, makes sure that the picker is always set shown to the user
let AlwaysOpen (value: bool) = 
    { Value = value; IsConfig = true; Key = "inline" }
    |> unbox<IFlatpickrOption>   

[<Emit("$2[$0] = $1")>]
let private setProp (propName: string) (propValue: obj) (any: obj) : unit = jsNative
[<Emit("$0")>]
let private typed<'a> (x: obj) : 'a = jsNative
[<Emit("$0[$1]")>]
let private getAs<'a> (x: obj) (key: string) : 'a = jsNative

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
    
 