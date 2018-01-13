module Wyvern.Engine

open Microsoft.Xna.Framework

type private GameEngine(loadContent: unit -> unit, unloadContent: unit -> unit) as this =
  inherit Game()

  do this.IsFixedTimeStep <- false
  do this.Content.RootDirectory <- "Content"
  let graphics = new GraphicsDeviceManager(this)
  // @TODO Set vsync based on user settings.
  do graphics.SynchronizeWithVerticalRetrace <- false

  override __.Initialize() =
    base.Initialize()

  override __.LoadContent() =
    loadContent()

  override __.UnloadContent() =
    unloadContent()

  override __.Update gameTime =
    base.Update gameTime

  override __.Draw gameTime =
    base.Draw gameTime

let init loadContent unloadContent =
  // @TODO: The engine never gets disposed, so this may create the possibility
  // for a memory leak. Will need to investigate further to determine whether
  // it is actually an issue.
  let engine = new GameEngine(loadContent, unloadContent)
  
  let run () =
    engine.Run()

  let exit () =
    engine.Exit()

  run, exit
