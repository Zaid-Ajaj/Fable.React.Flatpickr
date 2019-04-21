[<RequireQualifiedAccess>]
module Flatpickr

open Fable.React
open Fable.React.Props
open Fable.Core.JsInterop
open Fable.Core
open System

type IFlatpickrOption = interface end
type IFlatpickrLocale = interface end

type private OptionType = {
    Value : obj
    Key : string
    IsConfig : bool
}

[<StringEnum>]
type Mode =
    | Single
    | Multiple
    | Range

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

/// A placeholder text for the input. It will be shown when no date value is selected.
let Placeholder (placeholder: string) =
    { Value = placeholder; IsConfig = false; Key = "placeholder" }
    |> unbox<IFlatpickrOption>

/// Defines the id of the input
let Id (id: string) =
    { Value = id; IsConfig = false; Key = "id" }
    |> unbox<IFlatpickrOption>

/// Defines a custom property with key and value and flag that tells whether the option is from the flatpickr library or just an attribute of the input element
let custom key value config =
    { Value = unbox value; IsConfig = config; Key = key }
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
    { Value = unbox (fun (dates: DateTime[]) ->
        // sometimes the library emits a null causing all kinds of errors
        // if that's the case, we ignore it
        if isNull (unbox<obj> dates) || Array.isEmpty dates
        then ()
        else callback dates.[0])
      IsConfig = false;
      Key = "onChange" }
    |> unbox<IFlatpickrOption>

/// Registers an event handler for Flatpickr that is triggered when the user selects a new datetime value
let OnManyChanged (callback: DateTime list -> unit) =
    { Value = unbox (fun (dates: DateTime[]) -> callback (List.ofArray dates));
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

/// The selection mode changes wether the use can select a single value, multiple values or an inclusive range of dates.
let SelectionMode (mode: Mode) =
    { Value = mode; IsConfig = true; Key = "mode" }
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

/// Adjusts the step for the minute input (incl. scrolling)
let MinuteIncrement (min: int) =
    { Value = min; IsConfig = true; Key = "minuteIncrement" }
    |> unbox<IFlatpickrOption>

/// Adjusts the step for the hour input (incl. scrolling)
let HourIncrement (hours: int) =
    { Value = hours; IsConfig = true; Key = "hourIncrement" }
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

/// Allows using a custom date formatting function instead of the built-in handling for date formats using dateFormat.
let FormatDateBy (map: DateTime -> string) =
    { Value = map; IsConfig = true; Key = "formatDate" }
    |> unbox<IFlatpickrOption>

/// Displays time picker in 24 hour mode without AM/PM selection when enabled.
let TimeTwentyFour (cond: bool) =
    { Value = cond; IsConfig = true; Key = "time_24hr" }
    |> unbox<IFlatpickrOption>
    

/// Show the month using the shorthand version (ie, Sep instead of September).
let UseShorthandMonthNames (cond: bool) =
    { Value = cond; IsConfig = true; Key = "shorthandCurrentMonth" }
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

/// Localize the instance
let Locale (loc: IFlatpickrLocale) =
    { Value = loc; IsConfig = true; Key = "locale" }
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


type Locales =
    static member inline russian : IFlatpickrLocale = import "Russian" "flatpickr/dist/l10n/ru.js"
    static member inline bulgarian : IFlatpickrLocale = import "Bulgarian" "flatpickr/dist/l10n/bg.js"
    static member inline czech : IFlatpickrLocale = import "Czech" "flatpickr/dist/l10n/cs.js"
    static member inline italian : IFlatpickrLocale = import "Italian" "flatpickr/dist/l10n/it.js"
    static member inline japanese : IFlatpickrLocale = import "Japanese" "flatpickr/dist/l10n/ja.js"
    static member inline korean : IFlatpickrLocale = import "Korean" "flatpickr/dist/l10n/ko.js"
    static member inline french : IFlatpickrLocale = import "French" "flatpickr/dist/l10n/fr.js"
    static member inline spanish : IFlatpickrLocale = import "Spanish" "flatpickr/dist/l10n/es.js"
    static member inline estonian : IFlatpickrLocale = import "Estonian" "flatpickr/dist/l10n/et.js"
    static member inline persian : IFlatpickrLocale = import "Persian" "flatpickr/dist/l10n/fa.js"
    static member inline finnish : IFlatpickrLocale = import "Finnish" "flatpickr/dist/l10n/fi.js"
    static member inline greek : IFlatpickrLocale = import "Greek" "flatpickr/dist/l10n/gr.js"
    static member inline hebrew : IFlatpickrLocale = import "Hebrew" "flatpickr/dist/l10n/hr.js"
    static member inline hindi : IFlatpickrLocale = import "Hindi" "flatpickr/dist/l10n/hi.js"
    static member inline croatian : IFlatpickrLocale = import "Croatian" "flatpickr/dist/l10n/hr.js"
    static member inline indonesian : IFlatpickrLocale = import "Indonesian" "flatpickr/dist/l10n/id.js"
    static member inline dutch : IFlatpickrLocale = import "Dutch" "flatpickr/dist/l10n/nl.js"
    static member inline norwegian : IFlatpickrLocale = import "Norwegian" "flatpickr/dist/l10n/no.js"
    static member inline polish : IFlatpickrLocale = import "Polish" "flatpickr/dist/l10n/pl.js"
    static member inline portuguese : IFlatpickrLocale = import "Portuguese" "flatpickr/dist/l10n/pt.js"
    static member inline romanian : IFlatpickrLocale = import "Romanian" "flatpickr/dist/l10n/ro.js"
    static member inline slovak : IFlatpickrLocale = import "Slovak" "flatpickr/dist/l10n/sk.js"
    static member inline slovenian : IFlatpickrLocale = import "Slovenian" "flatpickr/dist/l10n/sl.js"
    static member inline albanian : IFlatpickrLocale = import "Albanian" "flatpickr/dist/l10n/sq.js"
    static member inline serbian : IFlatpickrLocale = import "Serbian" "flatpickr/dist/l10n/sr.js"
    static member inline thai : IFlatpickrLocale = import "Thai" "flatpickr/dist/l10n/th.js"
    static member inline turkish : IFlatpickrLocale = import "Turkish" "flatpickr/dist/l10n/tr.js"
    static member inline ukrainian : IFlatpickrLocale = import "Ukrainian" "flatpickr/dist/l10n/uk.js"
    static member inline vietnamese : IFlatpickrLocale = import "Vietnamese" "flatpickr/dist/l10n/vn.js"
    static member inline Mandarin : IFlatpickrLocale = import "Mandarin" "flatpickr/dist/l10n/zh.js"
    static member inline german : IFlatpickrLocale = import "German" "flatpickr/dist/l10n/de.js"
    static member inline catalan : IFlatpickrLocale = import "Catalan" "flatpickr/dist/l10n/cat.js"
