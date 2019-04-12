module App.Types

type Page =
    | Introduction
    | Usage

type State = {
    CurrentPage : Page
    Flatpickr : Components.Flatpickr.Types.State
}

type Msg =
    | View of Page
    | FlatpickrMsg of Components.Flatpickr.Types.Msg
