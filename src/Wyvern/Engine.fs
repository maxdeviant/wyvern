module Wyvern.Engine

open Microsoft.Xna.Framework
open Units

type DeltaTime = float<s>

type private GameEngine(loadContent: unit -> unit, unloadContent: unit -> unit, update: DeltaTime -> unit, render: DeltaTime -> unit) as this =
  inherit Game()

  do this.IsFixedTimeStep <- false
  do this.Content.RootDirectory <- "Content"
  let graphics = new GraphicsDeviceManager(this)
  // @TODO Set vsync based on user settings.
  do graphics.SynchronizeWithVerticalRetrace <- false

  let getDeltaTime (gameTime: GameTime): DeltaTime =
    LanguagePrimitives.FloatWithMeasure gameTime.ElapsedGameTime.TotalSeconds

  override __.Initialize() =
    base.Initialize()

  override __.LoadContent() =
    loadContent()

  override __.UnloadContent() =
    unloadContent()

  override __.Update gameTime =
    update (getDeltaTime gameTime)
    base.Update gameTime

  override __.Draw gameTime =
    render (getDeltaTime gameTime)
    base.Draw gameTime

let init loadContent unloadContent update render =
  let run () =
    use engine = new GameEngine(loadContent, unloadContent, update, render)
    engine.Run()

  run
