namespace Minesweeper.Gtk
module Program =

    open System
    open Minesweeper

    [<EntryPoint>]
    [<STAThread>]
    let Main(args) = 
        let app = new Eto.Forms.Application(Eto.Platforms.Gtk)
        app.Run(new MainForm())
        0